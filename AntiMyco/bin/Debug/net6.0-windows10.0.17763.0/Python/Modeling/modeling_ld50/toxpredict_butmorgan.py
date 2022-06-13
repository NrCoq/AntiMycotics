from rdkit import Chem
from rdkit.Chem import AllChem
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

# чтобы не использовать графический процессор
# хотя если не рекуррентная модель,
# может быть на нвидиа гпу было бы быстрее.
os.environ['CUDA_VISIBLE_DEVICES'] = ''

#set random seed for reproducibility
from numpy.random import seed
seed(8)
from tensorflow import set_random_seed
set_random_seed(8)

fold = 1024
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
	ax2.plot(history.epoch, history.history['lr'], c='r', label="Learning Rate", lw=lw)
	ax2.set_ylabel('Learning rate')
	plt.legend()
	plt.show()


def valid_smiles(smiles):
	try:
		m = Chem.MolFromSmiles(smiles)
		fp = AllChem.RDKFingerprint(m)
		return 1
	except:
		return None


# Calculate Fingerprints
def morgan_fp(smiles):
	try:
		m = Chem.MolFromSmiles(smiles)
		fp = AllChem.GetMorganFingerprintAsBitVect(m, 3, fold)
		return np.array(list(fp.ToBitString())).astype('int8')
	except:
		print("fingerprinting failed")
		return None


data = pd.read_csv("toxld50oralrats.csv")
print(np.shape(data))
data["valid"] = data["smiles"].apply(valid_smiles)
data = data[data["valid"].notnull()]
print(np.shape(data))

print()
#scale ld50
scaler = MinMaxScaler()

data[modeled_property] = scaler.fit_transform(data[modeled_property].to_numpy().reshape(-1,1))

XList = []
YList = []
for row in data.itertuples():
	# 2 is LD50
	# 3 is SMILES
	fp = morgan_fp(row[3])
	if fp is not None:
		XList.append(fp)
		YList.append(row[2])

X = np.array(XList)
Y = np.array(YList)
Y = np.expand_dims(Y, 1)

traindata, valdata = train_test_split(data, test_size=0.1,random_state=1)
traindata, testdata = train_test_split(traindata, test_size=0.2, random_state=1)

trainsmiles = traindata["smiles"].to_numpy()
testsmiles = testdata["smiles"].to_numpy()
valsmiles = valdata["smiles"].to_numpy()
trainprop = traindata[modeled_property].to_numpy()
testprop = testdata[modeled_property].to_numpy()
valprop = valdata[modeled_property].to_numpy()

trainfplist = []
testfplist = []
valfplist = []
trainproplist = []
testproplist = []
valproplist = []

for i in range(trainsmiles.shape[0]):
	fp = morgan_fp(trainsmiles[i])
	if fp is not None:
		trainfplist.append(fp)
		trainproplist.append(trainprop[i])

for i in range(testsmiles.shape[0]):
	fp = morgan_fp(testsmiles[i])
	if fp is not None:
		testfplist.append(fp)
		testproplist.append(testprop[i])

for i in range(valsmiles.shape[0]):
	fp = morgan_fp(valsmiles[i])
	if fp is not None:
		valfplist.append(fp)
		valproplist.append(valprop[i])



train_x = np.array(trainfplist)
test_x = np.array(testfplist)
val_x = np.array(valfplist)

train_y = np.array(trainproplist)
train_y = np.expand_dims(train_y, 1)
test_y = np.array(testproplist)
test_y = np.expand_dims(test_y, 1)
val_y = np.array(valproplist)
val_y = np.expand_dims(val_y, 1)

# Set network hyper parameters
l1 = 0.000
l2 = 0.008
dropout = 0.5
hidden_dim = 80

# Build neural network
model = Sequential()
model.add(Dense(fold, input_shape=(fold,), activation='tanh'))
model.add(Dropout(0.3))
model.add(Dense(fold, activation='tanh'))
model.add(Dropout(0.3))
model.add(Dense(256, activation='tanh'))
model.add(Dropout(0.3))
model.add(Dense(1, activation='sigmoid'))
model.compile(loss='mean_absolute_error', optimizer=RMSprop(lr=0.0001), metrics=["mean_absolute_error"])

print(model.summary())
# можно добавить, посмотреть если поможет.
#model.add(Bidirectional(GRU(45, input_shape=[fold, 1], return_sequences=True,
#			  recurrent_activation='tanh', recurrent_regularizer=rgr.l2(l2))))
#model.add(Bidirectional(GRU(30, recurrent_activation='tanh', recurrent_dropout=.5)))


early_stop = EarlyStopping(monitor='val_mean_absolute_error', min_delta=0.001, patience=50, verbose=1, mode='min')
reduce_lr = ReduceLROnPlateau(monitor='val_mean_absolute_error', factor=0.3, patience=50, min_lr=0.00001, verbose=1)
history = model.fit(train_x, train_y, epochs=500, batch_size=100,
					validation_data=(test_x, test_y), verbose=1, callbacks=[early_stop, reduce_lr])

# сохраняем модель которую мы натренировали
model.save(modeled_property+"_" + modeled_property+ '.h5')
model.save_weights(modeled_property+"_"+modeled_property)

pred_train = model.predict(train_x)
pred_val = model.predict(val_x)
pred_test = model.predict(test_x)

mse_train = mean_squared_error(train_y, pred_train)
mse_val = mean_squared_error(val_y, pred_val)
mse_test = mean_squared_error(test_y, pred_test)

print("AUC, Train:%0.3F Test:%0.3F Val:%0.3F" % (mse_train, mse_test, mse_val))


#plot_history(history)





