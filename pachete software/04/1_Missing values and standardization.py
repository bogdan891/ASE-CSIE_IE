import streamlit as st
import pandas as pd
import numpy as np
from sklearn.impute import SimpleImputer, KNNImputer
from sklearn.preprocessing import StandardScaler, MinMaxScaler

st.title("Pagina 1: Widgeturi de baza")
st.markdown("**Abilitati Streamlit:** `st.selectbox`, `st.dataframe`, `st.table`, `st.write`, `st.success`/`st.warning`/`st.error`, `st.download_button`")

st.markdown("---")

# CONCEPT 1: Afisarea datelor
st.header("1. Afisarea datelor")

st.markdown("""
Streamlit ofera mai multe moduri de a afisa date:

| Functie | Scop |
|----------|---------|
| `st.write()` | Afisare inteligenta, detecteaza automat tipul (string, DataFrame, grafic) |
| `st.dataframe()` | Tabel interactiv, cu scroll si sortare |
| `st.table()` | Tabel static (fara sortare sau scroll) |
""")

df = pd.read_csv("titanic.csv")

st.subheader("Exemplu functional")

tab1, tab2, tab3 = st.tabs(["st.write", "st.dataframe", "st.table"])

with tab1:
    st.write("Folosind st.write(df.head()):")
    st.write(df.head())

with tab2:
    st.write("Folosind st.dataframe(df.head()):")
    st.dataframe(df.head())

with tab3:
    st.write("Folosind st.table(df.head()):")
    st.table(df.head())

st.info("Observa diferentele. st.dataframe este interactiv. Poti apasa pe antetul coloanelor pentru sortare. st.table este static.")

# Exercitiul 1
st.subheader("Exercitiul 1: Afiseaza datele in modul tau")
st.markdown("Foloseste zona de cod de mai jos pentru a afisa ultimele 10 randuri folosind st.dataframe.")

ex1_code = st.text_area(
    "Codul tau:",
    value="# df este deja incarcat\n# Afiseaza ultimele 10 randuri\n",
    height=100,
    key="ex1_code"
)

if st.button("Ruleaza", key="ex1_run"):
    try:
        exec(ex1_code, {"st": st, "pd": pd, "np": np, "df": df})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 2: st.selectbox
st.header("2. Widget de selectie: st.selectbox")

st.markdown("""
st.selectbox creeaza un meniu dropdown si returneaza valoarea selectata.
""")

st.subheader("Exemplu functional: Alege o metoda de imputare")

numeric_cols = df.select_dtypes(include=["number"]).columns
categorical_cols = df.select_dtypes(include=["object"]).columns

impute_method = st.selectbox(
    "Selecteaza o metoda de imputare pentru date numerice",
    ["Mean", "Median", "Most frequent", "KNN imputer"],
    key="impute_select"
)

if impute_method in ["Mean", "Median", "Most frequent"]:
    strategy = impute_method.lower().replace("most frequent", "most_frequent")
    num_imputer = SimpleImputer(strategy=strategy)
else:
    num_imputer = KNNImputer(n_neighbors=3)

df_imputed = df.copy()
df_imputed[numeric_cols] = num_imputer.fit_transform(df_imputed[numeric_cols])

cat_imputer = SimpleImputer(strategy="most_frequent")
df_imputed[categorical_cols] = cat_imputer.fit_transform(df_imputed[categorical_cols])

missing_before = df.isnull().sum().sum()
missing_after = df_imputed.isnull().sum().sum()

st.write(f"Valori lipsa inainte: {missing_before} | dupa: {missing_after}")
st.write("Metoda selectata:", impute_method)
st.write("Media Age:", df_imputed["Age"].mean())

# Exercitiul 2
st.subheader("Exercitiul 2: Creeaza un selector de coloane")
st.markdown("Creeaza un selectbox care permite alegerea unei coloane si afiseaza cate valori lipsa are.")

ex2_code = st.text_area(
    "Codul tau:",
    value="# Alege o coloana cu st.selectbox\n# Afiseaza numarul de valori lipsa\n",
    height=120,
    key="ex2_code"
)

if st.button("Ruleaza", key="ex2_run"):
    try:
        exec(ex2_code, {"st": st, "pd": pd, "np": np, "df": df})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 3: Mesaje de status
st.header("3. Mesaje de status")

st.markdown("""
Streamlit ofera mesaje colorate pentru feedback.
""")

st.subheader("Exemplu functional")

missing_data = df.isnull().sum()
missing_data = missing_data[missing_data > 0]

if missing_data.empty:
    st.success("Nu exista valori lipsa in dataset.")
else:
    st.warning(f"Au fost gasite {len(missing_data)} coloane cu valori lipsa.")

    st.dataframe(
        pd.DataFrame({
            "Coloana": missing_data.index,
            "Numar valori lipsa": missing_data.values,
            "Procent": (missing_data.values / len(df) * 100).round(2)
        })
    )

# Exercitiul 3
st.subheader("Exercitiul 3: Mesaje conditionale")

ex3_code = st.text_area(
    "Codul tau:",
    value="# Verifica cate valori lipsa are coloana Age\n",
    height=120,
    key="ex3_code"
)

if st.button("Ruleaza", key="ex3_run"):
    try:
        exec(ex3_code, {"st": st, "pd": pd, "np": np, "df": df})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 4: st.download_button
st.header("4. Buton de descarcare: st.download_button")

st.subheader("Exemplu functional")

scaling_method = st.selectbox(
    "Alege o metoda de scalare",
    ["Standardization (Z-score)", "Normalization (Min-Max)"],
    key="scale_select"
)

scaler = StandardScaler() if scaling_method == "Standardization (Z-score)" else MinMaxScaler()

df_scaled = df_imputed.copy()
df_scaled[numeric_cols] = scaler.fit_transform(df_scaled[numeric_cols])

st.write("Previzualizare date scalate:")
st.dataframe(df_scaled.head())

csv = df_scaled.to_csv(index=False).encode("utf-8")

st.download_button(
    label="Descarca datasetul scalat",
    data=csv,
    file_name="scaled_data.csv",
    mime="text/csv"
)

# Exercitiul 4
st.subheader("Exercitiul 4: Creeaza propriul buton de descarcare")

ex4_code = st.text_area(
    "Codul tau:",
    value="# Filtreaza randurile unde Age este null si creeaza un download button\n",
    height=120,
    key="ex4_code"
)

if st.button("Ruleaza", key="ex4_run"):
    try:
        exec(ex4_code, {"st": st, "pd": pd, "np": np, "df": df})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

st.markdown("### Rezumatul paginii")

st.markdown("""
Ai exersat:
- st.write, st.dataframe, st.table pentru afisarea datelor
- st.selectbox pentru selectie din dropdown
- st.success, st.warning, st.error, st.info pentru mesaje
- st.download_button pentru descarcarea fisierelor
""")