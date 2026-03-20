import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import matplotlib
plt.style.use('ggplot') # Setăm stilul graficelor pentru un aspect profesional
import seaborn as sns
from sklearn.metrics import classification_report, confusion_matrix, accuracy_score
from sklearn.impute import SimpleImputer

# ==========================================
# 1. PREPROCESAREA DATELOR (Curățarea "Matură")
# ==========================================
df = pd.read_csv("clienti_leasing1.csv")

# drop(): Eliminăm coloanele care conțin date unice (ID, Nume).
# Dacă le-am lăsa, modelul ar tinde să memoreze numele persoanei în loc să învețe comportamentul financiar.
df.drop("ID_CLIENT", axis=1, inplace=True)
df.drop("NUME_CLIENT", axis=1, inplace=True)
df.drop("CATEGORIE", axis=1, inplace=True)
df.drop("DESCRIERE", axis=1, inplace=True)

# pd.to_datetime: Transformăm textul în obiecte de tip dată.
# 'mixed' indică Python-ului să fie flexibil dacă formatele variază (ex: 01.01 vs 01-01).
df['DATA'] = pd.to_datetime(df['DATA'], format='mixed', dayfirst=True)

# dt.month/year: Calculatorul nu înțelege conceptul de "zi", dar înțelege numerele.
# Extragem luna și anul pentru a vedea dacă există un trend sezonier în contractare.
df['LUNA'] = df['DATA'].dt.month
df['AN'] = df['DATA'].dt.year
df.drop("DATA", axis=1, inplace=True)

# FILTRARE COMPLEXĂ: Păstrăm doar profesiile care apar des (cele din listă).
# .isin() verifică prezența, restul rândurilor devin temporar NaN (valori lipsă).
listOfProf = ['muncitor necalificat','profesor','agricultor','asistent medical','barman','economist','inginer','medic','pensionar']
df['PROFESIA'] = df.loc[df['PROFESIA'].str.lower().isin(listOfProf), ['PROFESIA']]

# fillna(): Toate profesiile care NU erau în lista de mai sus primesc acum eticheta "ALTA PROFESIE".
# Acest pas previne "zgomotul" (prea multe categorii rare care ar zăpăci algoritmul).
df['PROFESIA'] = df['PROFESIA'].fillna('ALTA PROFESIE')

# ==========================================
# 2. IDENTIFICAREA ȘI TRATAREA VALORILOR LIPSĂ
# ==========================================
# Calculăm procentul de date lipsă pentru a vedea cât de "găurită" este baza de date.
total = df.isnull().sum().sort_values(ascending=False)
percent = (df.isnull().sum()*100/df.isnull().count()).sort_values(ascending=False)
missing_data = pd.concat([total, percent], axis=1, keys=['Total','Percent'])
print(missing_data.head(20))

# SimpleImputer(strategy='mean'): Funcție salvatoare.
# Dacă unui client îi lipsește Vârsta sau Venitul, modelul ML ar da eroare.
# Noi calculăm MEDIA coloanei și umplem automat spațiile goale.
df_numeric = df.select_dtypes(include=[np.number])
numeric_cols = df_numeric.columns
imputer = SimpleImputer(strategy='mean')
df[numeric_cols] = imputer.fit_transform(df[numeric_cols])

# ==========================================
# 3. TRANSFORMAREA VARIABILELOR CATEGORICE
# ==========================================
from sklearn.preprocessing import LabelEncoder
labelEncoder = LabelEncoder()

# Modelele matematice nu pot procesa cuvinte ("Masculin", "Euro").
# LabelEncoder le traduce în cifre (0, 1, 2...).
# Aceasta se numește mapare numerică a categoriilor.
categorice = ['PROFESIA', 'SEX', 'STARE_CIVILA', 'MONEDA']
for col in categorice:
    df[col] = labelEncoder.fit_transform(df[col].astype(str))

# ==========================================
# 4. FEATURE SELECTION (Selecția Inteligentă)
# ==========================================
# X reprezintă întrebările (predictorii), y reprezintă răspunsul (va semna sau nu?).
X = df.drop('PROBABILITATE_CONTRACTARE_N', axis=1)
y = df['PROBABILITATE_CONTRACTARE_N']

# SelectKBest(f_classif, k=6): Una dintre cele mai tehnice părți.
# f_classif (Testul ANOVA) măsoară matematic cât de mult "contează" fiecare coloană pentru rezultat.
# k=6 îi spune: "Păstrează doar cele mai bune 6 coloane, aruncă restul de balast".
from sklearn.feature_selection import SelectKBest, f_classif
selector = SelectKBest(score_func=f_classif, k=6)
X_new = selector.fit(X, y)

# Extragem numele coloanelor "câștigătoare" pentru a le putea afișa în grafice mai târziu.
names = X.columns.values[selector.get_support()]
scores = selector.scores_[selector.get_support()]
ns_df = pd.DataFrame(data=list(zip(names, scores)), columns=['Feature','Score'])
print(ns_df.sort_values(['Score'], ascending=False))

# Reconstruim tabelul X doar cu cele 6 coloane selectate (optimizare).
cols = names
X = selector.fit_transform(X, y)
X = pd.DataFrame(X, columns=cols)

# ==========================================
# 5. SCALAREA ȘI SPLIT-UL DATELOR
# ==========================================
# StandardScaler: Esențial pentru corectitudine.
# Transformă valorile (ex: Venit 5000 vs Vârstă 30) în unități standard (scoruri Z).
# Fără asta, modelul ar crede că Venitul e mai important doar pentru că cifra e mai mare.
from sklearn.preprocessing import StandardScaler
scaler = StandardScaler()
X = pd.DataFrame(scaler.fit_transform(X), columns=cols)

# train_test_split: Împărțim datele în "Manual de învățare" (80%) și "Examen final" (20%).
# random_state=1 asigură că, dacă rulăm codul iar, obținem aceleași grupuri.
from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=1)

# ==========================================
# 6. MODELARE ȘI EVALUARE (Logica de Decizie)
# ==========================================

# Model 1 - Decision Tree: Creează un flux de întrebări Da/Nu.
# max_depth=5 limitează complexitatea arborelui pentru a nu deveni prea specific (overfitting).
from sklearn.tree import DecisionTreeClassifier
DT = DecisionTreeClassifier(max_depth=5)
DT.fit(X_train, y_train)
y_pred_dt = DT.predict(X_test)

# Model 2 - Random Forest: Un "juriu" format din 100 de arbori de decizie.
# n_estimators=100 înseamnă că facem 100 de variante de arbori, iar rezultatul e votul majorității.
# Este mult mai stabil și precis decât un singur arbore.
from sklearn.ensemble import RandomForestClassifier
RF = RandomForestClassifier(n_estimators=100)
RF.fit(X_train, y_train)
y_pred_rf = RF.predict(X_test)

# accuracy_score: Ne dă procentul de clienți ghiciți corect din totalul de test.
print("Accuracy Random Forest:", accuracy_score(y_test, y_pred_rf))
print(classification_report(y_test, y_pred_rf))

# ==========================================
# 7. VIZUALIZARE REZULTATE
# ==========================================

# Matricea de confuzie: Tabelul care arată clar unde am nimerit și unde am dat pe lângă.
cm = confusion_matrix(y_test, y_pred_rf)
sns.heatmap(cm, annot=True, fmt='d')
plt.title("Confusion Matrix Random Forest")
plt.show()

# predict_proba: Nu cerem doar "Da/Nu", ci cerem PROBABILITATEA (ex: 0.85).
# Histograma ne arată dacă modelul e convins de deciziile sale sau e nesigur (zona 0.5).
probs = RF.predict_proba(X_test)
plt.hist(probs[:,1], bins=20)
plt.show()

# plot_tree: Desenează vizual "creierul" modelului.
# filled=True colorează nodurile (albastru = Contractează, portocaliu = Nu).
from sklearn.tree import plot_tree
plt.figure(figsize=(18,8))
plot_tree(DT, feature_names=X.columns, class_names=["0","1"], filled=True, max_depth=2)
plt.show()