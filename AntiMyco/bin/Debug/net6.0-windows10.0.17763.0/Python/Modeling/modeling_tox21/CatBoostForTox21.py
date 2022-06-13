import os
from sys import argv

import pandas as pd
import numpy as np
from numpy.random import seed
import seaborn as sns
import matplotlib.pyplot as plt

from rdkit import Chem
from rdkit import DataStructs
from rdkit.Chem import AllChem

from sklearn import metrics
from sklearn.model_selection import cross_val_score
from sklearn.model_selection import train_test_split
from sklearn.metrics import classification_report, roc_auc_score, roc_curve
from catboost import CatBoostClassifier, Pool
from imblearn.over_sampling import ADASYN

import joblib

seed(8)


modeled_property = "NR-AR"
modeled_properties = ["NR-AR", "NR-AR-LBD", "NR-AhR", "NR-Aromatase", "NR-ER",
                      "NR-ER-LBD", "NR-PPAR-gamma", "SR-ARE", "SR-ATAD5", "SR-HSE", "SR-MMP", "SR-p53"]

props = []
aucs = []
f1scores = []


def valid_smiles(smiles):
    # If a smiles string is gonna cause an error, use this to cut it out
    # of the dataset ahead of time
    try:
        m = Chem.MolFromSmiles(smiles)
        fp = Chem.RDKFingerprint(m)
        return 1
    except:
        return None


def auc_calc(x_val, y_val, model):
    # Probability predictions using validation data
    prob = model.predict_proba(x_val)
    # Correct probability predictions
    prob = prob[:, 1]
    # Calculate area under the curve with validation data labels and correct predicted probabilities
    auc = metrics.roc_auc_score(y_val, prob)
    # Return the AUC score with 6 figures
    return auc


def f1score(x_val, y_val, model):
    # predictions made on validation data
    predictions = model.predict(x_val)
    # generating the classification report
    clrpt = classification_report(y_val, predictions, output_dict = True)
    # accessing the weighted average in the dict
    d = clrpt["weighted avg"]
    # calling the f1_score
    f1 = d['f1-score']
    return f1

# матрица показывающая сколько положительных значений прогнозированы как положительные и отрицательные,
# и тоже самое для отрицательных значений
def plot_cm(cm_val, score_val):
    plt.figure(figsize=(9, 9))
    sns.heatmap(cm_val, annot=True, fmt=".3f", linewidths=.5, square=True, cmap='Blues_r')
    plt.ylabel('Actual label')
    plt.xlabel('Predicted label')
    all_sample_title = 'Accuracy Score: {0}'.format(score_val.mean())
    plt.title(all_sample_title, size=15)

    plt.show()


def plot_roc_curve(model, trainX, trainY, testX, testY, valX, valY):
    pred_train = model.predict_proba(trainX)[:, 1]
    pred_val = model.predict_proba(valX)[:, 1]
    pred_test = model.predict_proba(testX)[:, 1]

    auc_train = roc_auc_score(trainY, pred_train)
    auc_val = roc_auc_score(valY, pred_val)
    auc_test = roc_auc_score(testY, pred_test)

    print(modeled_property + " AUC, Train:%0.3F Test:%0.3F Val:%0.3F" % (auc_train, auc_test, auc_val))

    fpr_train, tpr_train, _ = roc_curve(trainY, pred_train)
    fpr_val, tpr_val, _ = roc_curve(valY, pred_val)
    fpr_test, tpr_test, _ = roc_curve(testY, pred_test)

    plt.figure()
    lw = 2
    plt.plot(fpr_train, tpr_train, color='b', lw=lw, label='Train ROC (area = %0.2f)' % auc_train)
    plt.plot(fpr_val, tpr_val, color='g', lw=lw, label='Val ROC (area = %0.2f)' % auc_val)
    plt.plot(fpr_test, tpr_test, color='r', lw=lw, label='Test ROC (area = %0.2f)' % auc_test)

    plt.plot([0, 1], [0, 1], color='navy', lw=lw, linestyle='--')
    plt.xlim([0.0, 1.0])
    plt.ylim([0.0, 1.05])
    plt.xlabel('False Positive Rate')
    plt.ylabel('True Positive Rate')
    plt.title('Receiver operating characteristic of %s' % modeled_property)
    plt.legend(loc="lower right")
    plt.show()


def save_model(model, property, modeltype):
    # Save to file in the current working directory
    joblib_file = modeltype+"_"+property+".pkl"
    joblib.dump(model, joblib_file)

def main():
    csv_path = argv[1]
    valid_part = float(argv[2]) / 100
    test_part = float(argv[3]) / 100
    iter_num = int(argv[4])
    depth_num = int(argv[5])

    for curr_property in modeled_properties:
        #try:
        global modeled_property
        modeled_property = curr_property
        print("predicting " + curr_property)
        data = pd.read_csv(csv_path)
        data = data[data[curr_property].notnull()]
        data["valid"] = data["smiles"].apply(valid_smiles)
        data = data[data["valid"].notnull()]
        print('ok')
        # Generate rdkit fingeprints in a list
        fps = [Chem.RDKFingerprint(Chem.MolFromSmiles(s)) for s in data['smiles']]

        # Convert the RDKit explicit vectors into numpy arrays
        fp_arrs = []
        for fp in fps:
          arr = np.zeros((1,))
          DataStructs.ConvertToNumpyArray(fp, arr)
          fp_arrs.append(arr)

        y = data[curr_property].values.astype('int8')

        # Cut % off to be validation set
        trainX, valX, trainY, valY = train_test_split(fp_arrs, y, test_size=valid_part,
                                                      random_state=1, shuffle=True)
        # Cut % off for test set
        trainX, testX, trainY, testY = train_test_split(trainX, trainY, test_size=test_part,
                                                        random_state=1, shuffle=True)

        # add artificial positives to the training set to balance the dataset for better training results
        trainX, trainY = ADASYN().fit_resample(trainX, trainY)

        print('ok_train')

        train_dataset = Pool(data=trainX,
                             label=trainY)

        eval_dataset = Pool(data=testX,
                            label=testY)

        # just a silly amount of iterations
        model = CatBoostClassifier(iterations=iter_num, depth=depth_num, od_type='Iter',
                                   od_wait=100, eval_metric='AUC')
        print('ok_const')
        # perform 10 fold crossvalidation to estimate accuracy of the model using the training data
        accuracy = model.fit(trainX, trainY, use_best_model=True, eval_set=eval_dataset)

        #get the mean of each fold
        print("Accuracy of Model with Cross Validation is:", str(accuracy.get_best_score()))

        #predicting using the validation set and creating a confusion matrix
        pred_val = model.predict(valX)
        print("done predicting")

        #confustion matrix for validation set predictions
        cm_val = metrics.confusion_matrix(valY, pred_val)
        score_val = cross_val_score(model, valX, valY)
        f1 = f1score(valX, valY, model)
        auc = auc_calc(valX, valY, model)

        props.append(curr_property)
        aucs.append(auc)
        f1scores.append(f1)

        model.save_model(os.getcwd() + "\\catboost_models\\catboost_" + curr_property)
        #except:
            #print("Failed to model " + curr_property)


    for i in range(len(props)):
        print(props[i])
        print("AUC: %.3f" % aucs[i])
        print("f1-score: %.3f" % f1scores[i])


if __name__ == '__main__':
    main()

#plot_cm(cm_val, score_val)
#plot_roc_curve(model, trainX, trainY, testX, testY, valX, valY)