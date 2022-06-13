from rdkit import Chem
from rdkit.Chem import AllChem
import os
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.preprocessing import MinMaxScaler
from sklearn.ensemble import RandomForestRegressor
from sklearn.model_selection import train_test_split
from sklearn.metrics import mean_squared_error
import math

os.environ['CUDA_VISIBLE_DEVICES'] = ''

#set random seed for reproducibility
from numpy.random import seed
seed(8)
from tensorflow import set_random_seed
set_random_seed(8)

fold = 1024
modeled_property = "LD50"

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
data["valid"] = data["smiles"].apply(valid_smiles)
data = data[data["valid"].notnull()]
print(np.shape(data))

print()
#scale ld50
scaler = MinMaxScaler()

#data[modeled_property] = scaler.fit_transform(data[modeled_property].to_numpy().reshape(-1,1))

XList = []
YList = []
for row in data.itertuples():
	# 2 is LD50
	# 3 is SMILES
	fp = morgan_fp(row[2])
	if fp is not None:
		XList.append(fp)
		YList.append(row[1])

scaler2 = MinMaxScaler()

X = np.array(XList)
X = scaler2.fit_transform(X)

Y = np.array(YList)

train_x, val_x, train_y, val_y  = train_test_split(X, Y, test_size=0.1,random_state=1)
train_x, test_x, train_y, test_y = train_test_split(train_x, train_y, test_size=0.2, random_state=1)

model = RandomForestRegressor().fit(train_x, train_y)

pred_train = model.predict(train_x)
pred_val = model.predict(val_x)
pred_test = model.predict(test_x)

train_y = np.expand_dims(train_y, 1)
#train_y = scaler.inverse_transform(train_y)
pred_train = np.expand_dims(pred_train, 1)
#pred_train = scaler.inverse_transform(pred_train)
test_y = np.expand_dims(test_y, 1)
#test_y = scaler.inverse_transform(test_y)
pred_test = np.expand_dims(pred_test, 1)
#pred_test = scaler.inverse_transform(pred_test)
val_y = np.expand_dims(val_y, 1)
#val_y = scaler.inverse_transform(val_y)
pred_val = np.expand_dims(pred_val, 1)
#pred_val = scaler.inverse_transform(pred_val)

rmse_train = math.sqrt(mean_squared_error(train_y, pred_train))
rmse_val = math.sqrt(mean_squared_error(val_y, pred_val))
rmse_test = math.sqrt(mean_squared_error(test_y, pred_test))

print("RMSE, Train:%0.3F Test:%0.3F Val:%0.3F" % (rmse_train, rmse_test, rmse_val))







