import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import matplotlib
plt.style.use('ggplot')
import seaborn as sns
from sklearn.metrics import classification_report, confusion_matrix, accuracy_score
from sklearn.impute import SimpleImputer


# PREPROCESAREA DATELOR
df = pd.read_csv("clienti_leasing1.csv")

df.drop("ID_CLIENT", axis=1, inplace=True)
df.drop("NUME_CLIENT", axis=1, inplace=True)
df.drop("CATEGORIE", axis=1, inplace=True)
df.drop("DESCRIERE", axis=1, inplace=True)


# Transformarea datei
df['DATA'] = pd.to_datetime(df['DATA'], format='mixed', dayfirst=True)
df['LUNA'] = df['DATA'].dt.month
df['AN'] = df['DATA'].dt.year
df.drop("DATA", axis=1, inplace=True)


# Simplificarea profesiilor
listOfProf = ['muncitor necalificat','profesor','agricultor','asistent medical','barman','economist','inginer','medic','pensionar']

df['PROFESIA'] = df.loc[df['PROFESIA'].str.lower().isin(listOfProf), ['PROFESIA']]
df['PROFESIA'] = df['PROFESIA'].fillna('ALTA PROFESIE')


# IDENTIFICAREA VALORILOR LIPSA
total = df.isnull().sum().sort_values(ascending=False)
percent = (df.isnull().sum()*100/df.isnull().count()).sort_values(ascending=False)
missing_data = pd.concat([total, percent], axis=1, keys=['Total','Percent'])
print(missing_data.head(20))


# Selectarea coloanelor numerice
df_numeric = df.select_dtypes(include=[np.number])
numeric_cols = df_numeric.columns

# Inlocuirea valorilor lipsa
imputer = SimpleImputer(strategy='mean')
df[numeric_cols] = imputer.fit_transform(df[numeric_cols])


# ANALIZA EXPLORATORIE
print('Coloane numerice:', df.select_dtypes(include=np.number).columns.tolist())
print('Coloane categorice:', df.select_dtypes(exclude=np.number).columns.tolist())


# Transformare variabile categorice
from sklearn.preprocessing import LabelEncoder

labelEncoder = LabelEncoder()

df['PROFESIA'] = labelEncoder.fit_transform(df['PROFESIA'].astype(str))
df['SEX'] = labelEncoder.fit_transform(df['SEX'].astype(str))
df['STARE_CIVILA'] = labelEncoder.fit_transform(df['STARE_CIVILA'].astype(str))
df['MONEDA'] = labelEncoder.fit_transform(df['MONEDA'].astype(str))


# DEFINIREA VARIABILELOR
X = df.drop('PROBABILITATE_CONTRACTARE_N', axis=1)
y = df['PROBABILITATE_CONTRACTARE_N']


# FEATURE SELECTION
from sklearn.feature_selection import SelectKBest, f_classif
selector = SelectKBest(score_func=f_classif, k=6)
X_new = selector.fit(X, y)

names = X.columns.values[selector.get_support()]
scores = selector.scores_[selector.get_support()]
names_scores = list(zip(names, scores))

ns_df = pd.DataFrame(data=names_scores, columns=['Feature','Score'])
ns_df_sorted = ns_df.sort_values(['Score'], ascending=False)

print(ns_df_sorted)

cols = names

X = selector.fit_transform(X, y)
X = pd.DataFrame(X, columns=cols)


# SCALAREA DATELOR
from sklearn.preprocessing import StandardScaler
scaler = StandardScaler()
scaler.fit(X)

X = scaler.transform(X)
X = pd.DataFrame(X, columns=cols)

# TRAIN / TEST SPLIT
from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=1)

# MODEL 1 - DECISION TREE
from sklearn.tree import DecisionTreeClassifier

DT = DecisionTreeClassifier(max_depth=5)
DT.fit(X_train, y_train)
y_pred_dt = DT.predict(X_test)

print("Accuracy Decision Tree:", accuracy_score(y_test, y_pred_dt))
print(classification_report(y_test, y_pred_dt))

# MODEL 2 - RANDOM FOREST
from sklearn.ensemble import RandomForestClassifier
RF = RandomForestClassifier(n_estimators=100)
RF.fit(X_train, y_train)
y_pred_rf = RF.predict(X_test)

print("Accuracy Random Forest:", accuracy_score(y_test, y_pred_rf))
print(classification_report(y_test, y_pred_rf))


# CONFUSION MATRIX
cm = confusion_matrix(y_test, y_pred_rf)
plt.figure(figsize=(6,5))
sns.heatmap(cm, annot=True, fmt='d')
plt.title("Confusion Matrix Random Forest")
plt.xlabel("Predicted")
plt.ylabel("Actual")
plt.show()


# GRAFIC 1 - IMPORTANTA VARIABILELOR
importances = RF.feature_importances_

indices = np.argsort(importances)[::-1]
plt.figure(figsize=(10,6))
plt.title("Importanta variabilelor")
plt.bar(range(len(importances)), importances[indices])
plt.xticks(range(len(importances)), X.columns[indices], rotation=90)
plt.show()

# GRAFIC 2 - DISTRIBUTIA PROBABILITATILOR
probs = RF.predict_proba(X_test)
plt.figure(figsize=(7,5))
plt.hist(probs[:,1], bins=20)
plt.title("Distributia probabilitatilor de contractare")
plt.xlabel("Probabilitate")
plt.ylabel("Numar clienti")
plt.show()


# GRAFIC 3 - ARBORELE DE DECIZIE
from sklearn.tree import plot_tree
plt.figure(figsize=(18,8))
plot_tree(
    DT,
    feature_names=X.columns,
    class_names=["0","1"],
    filled=True,
    rounded=True,
    fontsize=10,
    max_depth=2
)
plt.title("Arborele de decizie")
plt.show()