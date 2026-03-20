import streamlit as st
import pandas as pd
import numpy as np
from sklearn.preprocessing import OneHotEncoder, LabelEncoder
import plotly.express as px
from scipy.stats import zscore

st.title("Pagina 2: Layout si widgeturi interactive")
st.markdown("**Abilitati Streamlit:** `st.radio`, `st.columns`, `st.plotly_chart`, `st.checkbox`")

st.markdown("---")

df = pd.read_csv("titanic.csv")

# CONCEPT 1: st.radio
st.header("1. Butoane radio: st.radio")

st.markdown("""
st.radio creeaza un set de butoane radio. Utilizatorul poate selecta o singura optiune.

Exemplu:

choice = st.radio("Alege una:", ["Optiunea A", "Optiunea B", "Optiunea C"])

Foloseste st.radio cand ai un numar mic de optiuni exclusive (2-5). Pentru mai multe optiuni foloseste st.selectbox.
""")

st.subheader("Exemplu functional: alegerea metodei de encoding")

categorical_cols = df.select_dtypes(include=['object']).columns.tolist()

for col in ["Name", "Ticket"]:
    if col in categorical_cols:
        categorical_cols.remove(col)

encoding_method = st.radio(
    "Alege o metoda de encoding",
    ["One-Hot Encoding", "Label Encoding"],
    key="encoding_radio",
    help="One-Hot creeaza coloane binare. Label atribuie numere intregi"
)

df_encoded = df.copy()

if encoding_method == "One-Hot Encoding":
    df_encoded = pd.get_dummies(df, columns=categorical_cols)
    st.info(f"One-Hot Encoding a creat {len(df_encoded.columns) - len(df.columns)} coloane noi")
else:
    label_encoder = LabelEncoder()
    for col in categorical_cols:
        df_encoded[col] = label_encoder.fit_transform(df[col])
    st.info("Label Encoding a inlocuit valorile text cu numere")

st.dataframe(df_encoded.head())

# Exercitiul 1
st.subheader("Exercitiul 1: Creeaza un selector radio")

st.markdown("""
Creeaza un st.radio care permite alegerea intre:
"Primele 5 randuri" sau "Ultimele 5 randuri" din DataFrame-ul encodat.

Afiseaza randurile folosind st.dataframe.
""")

ex1_code = st.text_area(
    "Codul tau:",
    value="# Creeaza un radio si afiseaza randurile corespunzatoare din df_encoded\n",
    height=120,
    key="ex1_code"
)

if st.button("Ruleaza", key="ex1_run"):
    try:
        exec(ex1_code, {"st": st, "pd": pd, "np": np, "df_encoded": df_encoded})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 2: st.columns
st.header("2. Layout pe coloane: st.columns")

st.markdown("""
st.columns imparte pagina in coloane orizontale.

Exemplu:

col1, col2 = st.columns(2)

with col1:
    st.write("Partea stanga")

with col2:
    st.write("Partea dreapta")
""")

st.subheader("Exemplu functional: inainte si dupa eliminarea outlierilor")

numeric_cols = df.select_dtypes(include=np.number).columns

selected_column = st.selectbox(
    "Alege o coloana numerica",
    numeric_cols,
    key="outlier_col"
)

Q1 = df[selected_column].quantile(0.25)
Q3 = df[selected_column].quantile(0.75)
IQR = Q3 - Q1

lower_bound = Q1 - 1.5 * IQR
upper_bound = Q3 + 1.5 * IQR

df_cleaned = df[
    (df[selected_column] >= lower_bound) &
    (df[selected_column] <= upper_bound)
]

outliers_removed = len(df) - len(df_cleaned)

col1, col2 = st.columns(2)

with col1:
    st.markdown("**Inainte de eliminarea outlierilor**")
    fig_before = px.histogram(df, x=selected_column, nbins=30, title="Original")
    fig_before.update_layout(height=350)
    st.plotly_chart(fig_before)
    st.write(f"Numar total randuri: {len(df)}")

with col2:
    st.markdown("**Dupa eliminarea outlierilor**")
    fig_after = px.histogram(df_cleaned, x=selected_column, nbins=30, title="Curatat")
    fig_after.update_layout(height=350)
    st.plotly_chart(fig_after)
    st.write(f"Numar total randuri: {len(df_cleaned)} (eliminate {outliers_removed})")

# Exercitiul 2
st.subheader("Exercitiul 2: Creeaza un layout cu doua coloane")

st.markdown("""
Foloseste st.columns(2) pentru a afisa:

Coloana stanga: statistici de baza ale coloanei selectate  
df[selected_column].describe()

Coloana dreapta: boxplot al coloanei folosind px.box
""")

ex2_code = st.text_area(
    "Codul tau:",
    value="# Creeaza doua coloane si adauga continut in fiecare\n",
    height=150,
    key="ex2_code"
)

if st.button("Ruleaza", key="ex2_run"):
    try:
        exec(ex2_code, {"st": st, "pd": pd, "np": np, "df": df, "px": px, "selected_column": selected_column})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 3: st.plotly_chart
st.header("3. Grafice Plotly: st.plotly_chart")

st.markdown("""
Streamlit poate afisa grafice Plotly interactive.

Utilizatorii pot face zoom, pot muta graficul si pot vedea valorile cu hover.
""")

st.subheader("Exemplu functional: boxplot interactiv")

fig_box = px.box(df, y=selected_column, title=f"Boxplot pentru {selected_column}")
fig_box.update_layout(width=600, height=400)

st.plotly_chart(fig_box)

# Exercitiul 3
st.subheader("Exercitiul 3: Creeaza propriul grafic Plotly")

st.markdown("""
Creeaza un scatter plot folosind plotly.express.

Axa X: Age  
Axa Y: Fare  
Culoare: Survived

Afiseaza graficul folosind st.plotly_chart.
""")

ex3_code = st.text_area(
    "Codul tau:",
    value="# Creeaza un scatter plot folosind px.scatter\n",
    height=120,
    key="ex3_code"
)

if st.button("Ruleaza", key="ex3_run"):
    try:
        exec(ex3_code, {"st": st, "pd": pd, "np": np, "df": df, "px": px})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 4: st.checkbox
st.header("4. Afisare conditionata: st.checkbox")

st.markdown("""
st.checkbox returneaza True sau False si poate controla afisarea continutului.

Exemplu:

if st.checkbox("Arata datele brute"):
    st.dataframe(df)
""")

st.subheader("Exemplu functional")

if st.checkbox("Arata datele brute Titanic", key="show_raw"):
    st.dataframe(df)

if st.checkbox("Arata dimensiunea datasetului", key="show_shape"):
    st.write(f"Datasetul are {df.shape[0]} randuri si {df.shape[1]} coloane")

# Exercitiul 4
st.subheader("Exercitiul 4: Afisare controlata cu checkbox")

st.markdown("""
Creeaza doua checkbox-uri:

1. Show column types -> afiseaza df.dtypes  
2. Show missing value counts -> afiseaza df.isnull().sum()
""")

ex4_code = st.text_area(
    "Codul tau:",
    value="# Creeaza checkbox-uri care afiseaza informatii diferite\n",
    height=150,
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

st.radio pentru selectarea unei optiuni  
st.columns pentru layout cu coloane  
st.plotly_chart pentru grafice interactive  
st.checkbox pentru afisare conditionata
""")