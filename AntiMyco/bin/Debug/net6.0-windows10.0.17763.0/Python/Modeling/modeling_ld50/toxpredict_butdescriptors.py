from rdkit import Chem
from rdkit.Chem import AllChem, Descriptors, Descriptors3D, rdMolDescriptors
from rdkit.Chem.EState import EState_VSA
import os
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.preprocessing import MinMaxScaler
from sklearn import model_selection as cross_validation
from sklearn.model_selection import train_test_split
from sklearn.metrics import mean_squared_error
from keras import Sequential
from keras import regularizers as rgr
from keras.layers import Dropout, Dense, GRU, Conv1D, Bidirectional
from keras.callbacks import ReduceLROnPlateau, EarlyStopping
from keras.optimizers import RMSprop

# os.environ['CUDA_VISIBLE_DEVICES'] = ''

# set random seed for reproducibility
from numpy.random import seed

seed(8)
from tensorflow import random

random.set_seed(8)

total_descs = 262

smi = "CCO"
m = Chem.MolFromSmiles(smi)

modeled_property = "LD50"


# Plot Train History
def plot_history(history):
    lw = 2
    fig, ax1 = plt.subplots()
    ax1.plot(history.epoch, history.history['mean_absolute_error'], c='b', label="Train", lw=lw)
    ax1.plot(history.epoch, history.history['val_loss'], c='g', label="Val", lw=lw)
    plt.ylim([0.0, max(history.history['mean_absolute_error'])])
    ax1.set_xlabel('Epochs')
    ax1.set_ylabel('Loss')
    ax2 = ax1.twinx()
    ax2.plot(history.epoch, history.history['learning_rate'], c='r', label="Learning Rate", lw=lw)
    ax2.set_ylabel('Learning rate')
    plt.legend()
    plt.show()


def valid_smiles(smiles):
    try:
        m = Chem.MolFromSmiles(smiles)
        tpsa = rdMolDescriptors.CalcTPSA(m)
        peoe = rdMolDescriptors.PEOE_VSA_(m)
        smr = rdMolDescriptors.SMR_VSA_(m)
        slogp = rdMolDescriptors.SlogP_VSA_(m)
        evsa = EState_VSA.EState_VSA_(m)
        autocorr = rdMolDescriptors.CalcAUTOCORR2D(m)

        molwt = Descriptors.ExactMolWt(m)
        fpd1 = Descriptors.FpDensityMorgan1(m)
        fpd2 = Descriptors.FpDensityMorgan2(m)
        fpd3 = Descriptors.FpDensityMorgan3(m)
        minabpc = Descriptors.MinAbsPartialCharge(m)
        maxabpc = Descriptors.MaxAbsPartialCharge(m)
        maxpc = Descriptors.MaxPartialCharge(m)
        minpc = Descriptors.MinPartialCharge(m)
        gast = Descriptors.rdPartialCharges.ComputeGasteigerCharges(m)

        chi0n = rdMolDescriptors.CalcChi0n(m)
        chi1n = rdMolDescriptors.CalcChi1n(m)
        chi2n = rdMolDescriptors.CalcChi2n(m)
        chi3n = rdMolDescriptors.CalcChi3n(m)
        chi4n = rdMolDescriptors.CalcChi4n(m)

        chi0v = rdMolDescriptors.CalcChi0v(m)
        chi1v = rdMolDescriptors.CalcChi1v(m)
        chi2v = rdMolDescriptors.CalcChi2v(m)
        chi3v = rdMolDescriptors.CalcChi3v(m)
        chi4v = rdMolDescriptors.CalcChi4v(m)

        kappa1 = rdMolDescriptors.CalcKappa1(m)
        kappa2 = rdMolDescriptors.CalcKappa2(m)
        kappa3 = rdMolDescriptors.CalcKappa3(m)

        labute = rdMolDescriptors.CalcLabuteASA(m)

        return 1
    except:
        return None


# Calculate Fingerprints
# хотя здесь это и не используется
def morgan_fp(smiles):
    try:
        m = Chem.MolFromSmiles(smiles)
        fp = AllChem.GetMorganFingerprintAsBitVect(m, 3, 1024)
        return np.array(list(fp.ToBitString())).astype('int8')
    except:
        print("fingerprinting failed")
        return None


def calc_descs(smiles):
    # There are 263 separate values here
    m = Chem.MolFromSmiles(smiles)
    descs = []

    tpsa = rdMolDescriptors.CalcTPSA(m)
    descs.append(tpsa)

    peoe = rdMolDescriptors.PEOE_VSA_(m)
    for x in peoe:
        descs.append(x)

    smr = rdMolDescriptors.SMR_VSA_(m)
    for x in smr:
        descs.append(x)

    slogp = rdMolDescriptors.SlogP_VSA_(m)
    for x in slogp:
        descs.append(x)

    evsa = EState_VSA.EState_VSA_(m)
    for x in evsa:
        descs.append(x)

    autocorr = rdMolDescriptors.CalcAUTOCORR2D(m)
    for x in autocorr:
        descs.append(x)

    molwt = Descriptors.ExactMolWt(m)
    descs.append(molwt)
    fpd1 = Descriptors.FpDensityMorgan1(m)
    descs.append(fpd1)
    fpd2 = Descriptors.FpDensityMorgan2(m)
    descs.append(fpd2)
    fpd3 = Descriptors.FpDensityMorgan3(m)
    descs.append(fpd3)
    minabpc = Descriptors.MinAbsPartialCharge(m)
    descs.append(minabpc)
    maxabpc = Descriptors.MaxAbsPartialCharge(m)
    descs.append(maxabpc)
    maxpc = Descriptors.MaxPartialCharge(m)
    descs.append(maxpc)
    minpc = Descriptors.MinPartialCharge(m)
    descs.append(minpc)
    gast = Descriptors.rdPartialCharges.ComputeGasteigerCharges(m)
    descs.append(gast)

    chi0n = rdMolDescriptors.CalcChi0n(m)
    descs.append(chi0n)
    chi1n = rdMolDescriptors.CalcChi1n(m)
    descs.append(chi1n)
    chi2n = rdMolDescriptors.CalcChi2n(m)
    descs.append(chi2n)
    chi3n = rdMolDescriptors.CalcChi3n(m)
    descs.append(chi3n)
    chi4n = rdMolDescriptors.CalcChi4n(m)
    descs.append(chi4n)

    chi0v = rdMolDescriptors.CalcChi0v(m)
    descs.append(chi0v)
    chi1v = rdMolDescriptors.CalcChi1v(m)
    descs.append(chi1v)
    chi2v = rdMolDescriptors.CalcChi2v(m)
    descs.append(chi2v)
    chi3v = rdMolDescriptors.CalcChi3v(m)
    descs.append(chi3v)
    chi4v = rdMolDescriptors.CalcChi4v(m)
    descs.append(chi4v)

    kappa1 = rdMolDescriptors.CalcKappa1(m)
    descs.append(kappa1)
    kappa2 = rdMolDescriptors.CalcKappa2(m)
    descs.append(kappa2)
    kappa3 = rdMolDescriptors.CalcKappa3(m)
    descs.append(kappa3)

    return np.array(descs)


data = pd.read_csv("toxld50oralrats.csv")
print(np.shape(data))
data["valid"] = data["smiles"].apply(valid_smiles)
data = data[data["valid"].notnull()]
print(np.shape(data))

desc_list = []
for row in data['smiles']:
    descs = calc_descs(row)
    if len(descs) != total_descs:
        print(str(len(descs)) + " instead of " + str(total_descs))
    desc_list.append(descs)

X = np.array(desc_list)
Y = data["LD50"].to_numpy()
Y = np.expand_dims(Y, 1)

# scale ld50 and descriptors
# scaler = MinMaxScaler()
# X = scaler.fit_transform(X)
# Y = scaler.fit_transform(Y)

trainX, valX, trainY, valY = train_test_split(X, Y, test_size=0.1, random_state=1)
trainX, testX, trainY, testY = train_test_split(trainX, trainY, test_size=0.2, random_state=1)

# Set network hyper parameters
l1 = 0.000
l2 = 0.008
dropout = 0.5
hidden_dim = 80
fold = 1024

# Build neural network
model = Sequential()
model.add(Bidirectional(GRU(45, input_shape=[fold, 1], return_sequences=True,
                            recurrent_activation='tanh', recurrent_regularizer=rgr.l2(l2))))
model.add(Bidirectional(GRU(30, recurrent_activation='tanh', recurrent_dropout=.5)))
# model.add(Dense(total_descs, input_shape=(total_descs,), activation='relu'))
# model.add(Dense(9000, activation='tanh'))
model.add(Dropout(0.3))
# model.add(Dense(1500, activation='tanh'))
# model.add(Dense(32, activation='tanh'))
model.add(Dense(1, activation='sigmoid'))
model.compile(loss='mean_absolute_error', optimizer=RMSprop(lr=0.05), metrics=["mean_absolute_error"])

print(model.summary())

# можно попробовать с этими компонентами, хотя неизвестно если они помогут
# model.add(Bidirectional(GRU(45, input_shape=[fold, 1], return_sequences=True,
#			  recurrent_activation='tanh', recurrent_regularizer=rgr.l2(l2))))
# model.add(Bidirectional(GRU(30, recurrent_activation='tanh', recurrent_dropout=.5)))


early_stop = EarlyStopping(monitor='val_mean_absolute_error', min_delta=0.001, patience=120, verbose=1, mode='min')
reduce_lr = ReduceLROnPlateau(monitor='val_mean_absolute_error', factor=0.3, patience=50, min_lr=0.00001, verbose=1)
history = model.fit(trainX.astype('float32'), trainY.astype('float32'), epochs=100, batch_size=100,
                    validation_data=(testX.astype('float32'), testY.astype('float32')), verbose=1,
                    callbacks=[early_stop, reduce_lr])

# сохраняем полученную модель
model.save(modeled_property + "_" + modeled_property + '.h5')
model.save_weights(modeled_property + "_" + modeled_property)

pred_train = model.predict(trainX.astype('float32'))
pred_val = model.predict(valX.astype('float32'))
pred_test = model.predict(testX.astype('float32'))

mse_train = mean_squared_error(trainY.astype('float32'), pred_train)
mse_val = mean_squared_error(valY.astype('float32'), pred_val)
mse_test = mean_squared_error(testY.astype('float32'), pred_test)

print("AUC, Train:%0.3F Test:%0.3F Val:%0.3F" % (mse_train, mse_test, mse_val))

plot_history(history)
