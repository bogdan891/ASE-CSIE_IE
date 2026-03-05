import impyute
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import matplotlib
plt.style.use('ggplot')
from matplotlib.pyplot import figure
matplotlib.rcParams['figure.figsize'] = (15,10)
import seaborn as sns
from sklearn.metrics import classification_report, confusion_matrix, accuracy_score
from sklearn.impute import SimpleImputer

#Pre-procesarea datelor
df = pd.read_csv("clienti_leasing1.csv")
df.drop("ID_CLIENT", axis = 1, inplace = True)
df.drop("NUME_CLIENT", axis = 1, inplace = True)
df.drop("CATEGORIE", axis = 1, inplace = True)
df.drop("DESCRIERE", axis = 1, inplace = True)

'''Transformam coloana DATA in DateTime si extragem anul si luna'''
df['DATA'] = pd.to_datetime(df['DATA'], format='mixed', dayfirst=True)
df['LUNA'] = df['DATA'].dt.month
df['AN'] = df['DATA'].dt.year
df.drop("DATA", axis = 1, inplace = True)

'''Transformam coloana PROFESIA astfel incat profesiile care nu se regasesc in lista sa fie etichetate cu ALTA PROFESIE'''
listOfProf = ['muncitor necalificat', 'profesor' , 'agricultor', 'asistent medical', 'barman', 'economist', 'inginer',
             'medic', 'pensionar']
df['PROFESIA']=df.loc[df['PROFESIA'].str.lower().isin(listOfProf), ['PROFESIA']]
df['PROFESIA'] = df['PROFESIA'].fillna('ALTA PROFESIE')


#Identificarea si eliminarea valorilor lipsa
'''Tratarea valorilor lipsa'''
total = df.isnull().sum().sort_values(ascending=False)
#Calculam cate valori lipsa are fiecare coloana si le sortam descrescator
percent = (df.isnull().sum()*100/df.isnull().count()).sort_values(ascending=False)
#Calculam procentul de valori lipsa din fiecare coloana
missing_data = pd.concat([total, percent], axis=1, keys=['Total', 'Percent'])
print(missing_data.head(20))

'''df['PRESCORING'] = df['PRESCORING'].fillna(method = 'bfill')
df['FIDELITATE'] = df['FIDELITATE'].fillna(method = 'bfill')
df['SUMA_DEPOZIT'] = df['SUMA_DEPOZIT'].fillna(0)'''

#Selectam coloanele numerice
df_numeric = df.select_dtypes(include=[np.number])
numeric_cols = df_numeric.columns

#Inlocuim valorile lipsa cu media
imputer = SimpleImputer(strategy='mean')
df[numeric_cols] = imputer.fit_transform(df[numeric_cols])

#Continuare pre-procesare si ML - algoritm de clasificare REGRESIA LOGISTICA
# Functie pentru afisarea Confusion Matrix
def conf_mtrx(y_test, y_pred, model_name):
    cm = confusion_matrix(y_test, y_pred)
    f, ax = plt.subplots(figsize=(5, 5))
    sns.heatmap(cm, annot=True, linewidths=0.5, linecolor="red", fmt=".0f", ax=ax)
    plt.xlabel("predicted y values")
    plt.ylabel("real y values")
    plt.title("\nConfusion Matrix " + model_name)
    plt.show()


'''Functie pentru afisarea curbei ROC si AUC'''
from sklearn.metrics import roc_auc_score, roc_curve
def roc_auc_curve_plot(model_name, X_testt, y_testt):
    ns_probs = [0 for _ in range(len(y_testt))]
    # probabiltatile modelului
    model_probs = model_name.predict_proba(X_testt)
    # pstram doar probabilitatile pentru valorile pozitive
    model_probs = model_probs[:, 1]
    # calcul scor auc
    ns_auc = roc_auc_score(y_testt, ns_probs)
    lr_auc = roc_auc_score(y_testt, model_probs)
    print('No Skill: ROC AUC=%.3f' % (ns_auc))
    print(': ROC AUC=%.3f' % (lr_auc))
    #  roc curves
    ns_fpr, ns_tpr, _ = roc_curve(y_testt, ns_probs)
    model_fpr, model_tpr, _ = roc_curve(y_testt, model_probs)
    # plot the roc curve for the model
    plt.plot(ns_fpr, ns_tpr, linestyle='--', label='No Skill')
    plt.plot(model_fpr, model_tpr, marker='.', label='Clasifier')
    # axis labels
    plt.xlabel('False Positive Rate')
    plt.ylabel('True Positive Rate')
    plt.legend()
    plt.show()


# De aici - avem pipeline-ul ML ---> transformare -> selectie variabile -> scalare -> antrenare -> evaluare
'''ANALIZA EXPLORATORIE A DATELOR SI TRANSFORMAREA ACESTORA'''
'''Lista coloanelor numerice si non-numerice:'''
print('Coloane numerice', df.select_dtypes(include=np.number).columns.tolist())
print('Coloane non-numerice', df.select_dtypes(exclude=np.number).columns.tolist())

'''Distributia valorilor pe coloanele non-numerice in vederea transformarii cu acestora in coloane numerice'''
for col in df.select_dtypes(exclude=np.number).columns.tolist():
    print(col, len(df[col].unique()))

'''Transformare coloane non-numerice in numerice'''
from sklearn.preprocessing import LabelEncoder, StandardScaler, MinMaxScaler

labelEncoder = LabelEncoder()
df['PROFESIA'] = labelEncoder.fit_transform(df['PROFESIA'].astype(str))
df['SEX'] = labelEncoder.fit_transform(df['SEX'].astype(str))
df['STARE_CIVILA'] = labelEncoder.fit_transform(df['STARE_CIVILA'].astype(str))
df['MONEDA'] = labelEncoder.fit_transform(df['MONEDA'].astype(str))

'''Extragerea variabilelor X si a variabilei target y din setul de date'''
X = df.drop('PROBABILITATE_CONTRACTARE_N', axis=1)
y = df['PROBABILITATE_CONTRACTARE_N']

'''Feature selection'''
from sklearn.feature_selection import SelectKBest, f_regression

# Selectarea atributelor importante Fisher scores
k_features = 5
selector = SelectKBest(f_regression, k=k_features)
# Folosim doar fit() pt a vedea denumirea atributelor si a scorului
X_new = selector.fit(X, y)
names = X.columns.values[selector.get_support()]
scores = selector.scores_[selector.get_support()]
names_scores = list(zip(names, scores))
ns_df = pd.DataFrame(data=names_scores, columns=['Feat_names', 'F_Scores'])
##sortam atributele in ordinea importantei
ns_df_sorted = ns_df.sort_values(['F_Scores', 'Feat_names'], ascending=[False, True])
print(ns_df_sorted)
# aplicam feature selection pe setul de date
cols = names
X = selector.fit_transform(X, y)
X = pd.DataFrame(X, columns=cols)

'''Standardizarea valorilor'''
cols = X.columns.tolist()
scaler = StandardScaler()
scaler.fit(X)
X = scaler.transform(X)
X = pd.DataFrame(data=X, columns=cols)

'''Construirea seturilor de date de train si test: 80% train si 20% test. Parametrul random_state=63 ne asigura ca se va selecta acelasi set de date de fiecare data cand rulam scriptul.'''
from sklearn.model_selection import train_test_split

X_train, X_test, y_train, y_test = train_test_split(X, y, random_state=1, test_size=.20)

'''APLICAREA MODELELOR DE CLASIFICARE'''
'''Aplicarea modelului de REGRESIE LOGISTICA'''
from sklearn.linear_model import LogisticRegression

RL = LogisticRegression(max_iter=50, penalty='l2', solver='lbfgs')
RL.fit(X_train, y_train)
y_predicted = RL.predict(X_test)

'''Verificarea modelului de regresie logistica. Afisam acuratetea, matricea de confuzie şi raportul de clasificare'''
CM = confusion_matrix(y_test, y_predicted)
print("Confusion matrix:")
print(CM)
conf_mtrx(y_test, y_predicted, 'RL')
RL_report = classification_report(y_test, y_predicted)
print("Classification report:")
print(RL_report)
acuratetea_RL = accuracy_score(y_test, y_predicted)
print("Acuratetea RL: ", acuratetea_RL)
roc_auc_curve_plot(RL, X_test, y_test)