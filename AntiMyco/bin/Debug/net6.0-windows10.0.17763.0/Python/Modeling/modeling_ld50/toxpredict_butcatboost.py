from rdkit import Chem
from rdkit.Chem import AllChem
import os
import pandas as pd
import numpy as np
import math
import matplotlib.pyplot as plt
from sklearn.preprocessing import MinMaxScaler
from sklearn.ensemble import RandomForestRegressor, AdaBoostRegressor
from sklearn.model_selection import train_test_split
from sklearn.metrics import mean_squared_error
from catboost import CatBoostRegressor, Pool

os.environ['CUDA_VISIBLE_DEVICES'] = ''

# в какой базе делаем лог на прогнозированных значениях
# используется для того чтобы результаты были более линейными
power = 1.7

# выбираем рандом число чтобы результаты были одни и те же
# когда проводим последовательные попытки
from numpy.random import seed
seed(8)
from tensorflow import set_random_seed
set_random_seed(8)

# какой размер отпечатков мы хотим (актуально для морган отпечатков)
fold = 1024
modeled_property = "LD50"

# для проверки что SMILES нотация не сломана
def valid_smiles(smiles):
	try:
		m = Chem.MolFromSmiles(smiles)
		fp = AllChem.RDKFingerprint(m)
		return 1
	except:
		return None


# для вычисления молекулярных отпечатков
def morgan_fp(smiles):
	try:
		m = Chem.MolFromSmiles(smiles)
		fp = Chem.RDKFingerprint(m)
		return np.array(list(fp.ToBitString())).astype('int8')
	except:
		print("fingerprinting failed")
		return None

# для вычисления молекулярного веса молекулы
def getMolWt(smiles):
	try:
		m = Chem.MolFromSmiles(smiles)
		return AllChem.CalcExactMolWt(m)
	except:
		print("calculating molar weight failed")
		return None

# какое значение прогнозируем. Используется как название csv файла который мы
# загружаем, и для сохранения моделей чтобы их идентифицировать
val_type = "toxld50oralrats"
data = pd.read_csv(val_type+".csv")
# оставь лишь те строчки у которых SMILES нотация применима
data["valid"] = data["smiles"].apply(valid_smiles)
data = data[data["valid"].notnull()]
print(np.shape(data))

# сейчас не используем, но в принципе могли бы использовать шкалу для преобразования
# моделируемого значения. Вместо этого используем лог в степени power
scaler = MinMaxScaler()

#data[modeled_property] = scaler.fit_transform(data[modeled_property].to_numpy().reshape(-1,1))

# записываем так потому что молекулярный отпечаток - список, если его просто добавить веса
# пандас стуктуру, он станет плоским (пример - не (1024,2) а (2048,)
XList = []
YList = []
for row in data.itertuples():
	# 2 is LD50
	# 3 is SMILES
	fp = morgan_fp(row[2])
	molwt = getMolWt(row[2])
	if fp is not None and molwt is not None:
		XList.append(fp)
		YList.append(math.log(row[1], power))

# превращаем полученные значения в нампи матрицы
X = np.array(XList)
Y = np.array(YList)

# выделям из каждой матрицы долю на валидацию и долю на тестирование
train_x, val_x, train_y, val_y = train_test_split(X, Y, test_size=0.08, random_state=1)
train_x, test_x, train_y, test_y = train_test_split(train_x, train_y, test_size=0.1, random_state=1)

# складываем вместе (просто катбуст так хочет)
train_dataset = Pool(data=X, label=Y)

eval_dataset = Pool(data=X, label=Y)

# много итераций, но и приличное количество ожидания если результаты на тестовом наборе не улучшаются
model = CatBoostRegressor(iterations=50000, depth=6, od_type='Iter', od_wait=500, learning_rate=0.07,
						  random_strength=40, l2_leaf_reg=100)

model.fit(train_dataset, eval_set=eval_dataset, use_best_model=True)

accuracy = model.get_best_score()

# get the mean of each fold
print("точность модели:", accuracy)

# прогнозируем результаты по нашим наборам
pred_train = model.predict(train_x)
pred_val = model.predict(val_x)
pred_test = model.predict(test_x)

# требуется изменить мерность для того чтобы использовать другие модели
train_y = np.expand_dims(train_y, 1)
pred_train = np.expand_dims(pred_train, 1)
test_y = np.expand_dims(test_y, 1)
pred_test = np.expand_dims(pred_test, 1)
val_y = np.expand_dims(val_y, 1)
pred_val = np.expand_dims(pred_val, 1)

# так как первоначально моделировали лог(power, значение)
# для того чтобы получить значение нужно сделать power в степени результат
for i in range(len(train_y)):
	train_y[i] = math.pow(power, train_y[i])
	pred_train[i] = math.pow(power, pred_train[i])

for i in range(len(test_y)):
	test_y[i] = math.pow(power, test_y[i])
	pred_test[i] = math.pow(power, pred_test[i])

for i in range(len(val_y)):
	val_y[i] = math.pow(power, val_y[i])
	pred_val[i] = math.pow(power, pred_val[i])

# проверяем среднюю абсолютную ошибку (ну а точнее корень квадратный средней квадратичной ошибки)
rmse_train = math.sqrt(mean_squared_error(train_y, pred_train))
rmse_val = math.sqrt(mean_squared_error(val_y, pred_val))
rmse_test = math.sqrt(mean_squared_error(test_y, pred_test))


print("RMSE, Train:%0.3F Test:%0.3F Val:%0.3F" % (rmse_train, rmse_test, rmse_val))

# сохраняем результат, начало названия это модель которую мы использовали, а конец - что мы прогнозировали
model.save_model("catboost_"+val_type)






