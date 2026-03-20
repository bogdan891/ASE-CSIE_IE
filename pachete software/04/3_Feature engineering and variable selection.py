import streamlit as st
import pandas as pd
import numpy as np
from sklearn.feature_selection import VarianceThreshold

st.title("Pagina 3: Slidere, inputuri numerice si taburi")
st.markdown("**Abilitati Streamlit:** `st.slider`, `st.number_input`, `st.tabs`, `st.latex`, `st.text_input`")

st.markdown("---")

df = pd.read_csv("housing.csv")

# CONCEPT 1: st.slider
st.header("1. Slidere: st.slider")

st.markdown("""
st.slider creeaza un slider pentru introducere numerica.

Exemple:

# Slider pentru numere intregi
age = st.slider("Varsta", min_value=0, max_value=100, value=25)

# Slider pentru numere reale
threshold = st.slider("Prag", 0.0, 1.0, 0.5, step=0.01)

# Slider pentru interval
low, high = st.slider("Interval", 0, 100, (25, 75))
""")

st.subheader("Exemplu functional: selector pentru pragul de varianta")

st.markdown("Metoda variance threshold elimina variabilele cu varianta foarte mica.")

st.latex(r"\text{Variance}(X) = \frac{1}{n} \sum_{i=1}^{n} (X_i - \bar{X})^2")

# Adaugam coloane cu varianta mica pentru demonstratie
df_demo = df.copy()
df_demo["constant_feature"] = 1
df_demo["almost_constant"] = np.random.normal(0, 0.0001, df_demo.shape[0])

X = df_demo.drop(columns=["median_house_value", "ocean_proximity"]).select_dtypes(include=np.number).dropna(axis=1)

threshold = st.slider(
    "Prag varianta",
    0.0,
    0.001,
    0.0001,
    0.00001,
    key="var_thresh_slider"
)

var_thresh = VarianceThreshold(threshold=threshold)

X_selected = X.loc[:, var_thresh.fit(X).get_support()]

removed_cols = set(X.columns) - set(X_selected.columns)

st.write(f"{len(X_selected.columns)} variabile pastrate, {len(removed_cols)} eliminate")

if removed_cols:
    st.warning(f"Variabile eliminate: {', '.join(removed_cols)}")
else:
    st.success("Nu au fost eliminate variabile la acest prag")

st.dataframe(X_selected.head())

# # Exercitiul 1
# st.subheader("Exercitiul 1: Creeaza un slider pentru interval")
#
# st.markdown("""
# Creeaza un slider pentru intervalul valorilor din median_house_value.
# Utilizatorul trebuie sa poata filtra casele dupa pret.
#
# Afiseaza numarul de case din interval si datele filtrate.
# """)
#
# ex1_code = st.text_area(
#     "Codul tau:",
#     value="# Creeaza un slider pentru median_house_value\n# Filtreaza si afiseaza rezultatele\n",
#     height=150,
#     key="ex1_code"
# )

# if st.button("Ruleaza", key="ex1_run"):
#     try:
#         exec(ex1_code, {"st": st, "pd": pd, "np": np, "df": df})
#     except Exception as e:
#         st.error(f"Eroare: {e}")

min_val = float(df['median_house_value'].min())
max_val = float(df['median_house_value'].max())

price_range = st.slider(
    "Selectează intervalul de preț (median_house_value):",
    min_value=min_val,
    max_value=max_val,
    value=(min_val, max_val)
)

filtered_df = df[
    (df['median_house_value'] >= price_range[0]) &
    (df['median_house_value'] <= price_range[1])
]

st.write(f"### Rezultate: {len(filtered_df)} case găsite în acest interval")
st.dataframe(filtered_df)

st.markdown("---")

# CONCEPT 2: st.number_input
st.header("2. Input numeric: st.number_input")

st.markdown("""
st.number_input creeaza un camp numeric cu butoane + si -.

Exemplu:

n = st.number_input("Introdu un numar", min_value=0, max_value=100, value=10, step=1)

Foloseste st.number_input cand ai nevoie de introducere numerica precisa.
""")

st.subheader("Exemplu functional: prag pentru corelatie")

corr_thresh = st.number_input(
    "Prag corelatie",
    min_value=0.0,
    max_value=1.0,
    value=0.8,
    step=0.05,
    key="corr_input"
)

corr_matrix = X.corr()

correlated_features = set()

for i in range(len(corr_matrix.columns)):
    for j in range(i):
        if abs(corr_matrix.iloc[i, j]) > corr_thresh:
            correlated_features.add(corr_matrix.columns[i])

if correlated_features:
    st.warning(f"Variabile cu corelatie mai mare decat {corr_thresh}: {', '.join(correlated_features)}")
else:
    st.success(f"Nicio variabila nu depaseste pragul de corelatie {corr_thresh}")

# Exercitiul 2
st.subheader("Exercitiul 2: Selectarea numarului de randuri")

st.markdown("""
Creeaza un st.number_input care permite alegerea numarului de randuri afisate (1-50).
Afiseaza acel numar de randuri din dataset.
""")

# ex2_code = st.text_area(
#     "Codul tau:",
#     value="# Creeaza un number_input pentru numarul de randuri\n# Afiseaza randurile selectate\n",
#     height=120,
#     key="ex2_code"
# )
#
# if st.button("Ruleaza", key="ex2_run"):
#     try:
#         exec(ex2_code, {"st": st, "pd": pd, "np": np, "df": df})
#     except Exception as e:
#         st.error(f"Eroare: {e}")

nr_randuri = st.number_input("Randuri:", min_value=1, max_value=50, value=1, step=1)
st.write(df.head(nr_randuri))

st.markdown("---")

# CONCEPT 3: st.tabs
st.header("3. Layout cu taburi: st.tabs")

st.markdown("""
st.tabs creeaza sectiuni organizate in taburi.

Exemplu:

tab1, tab2, tab3 = st.tabs(["Date", "Grafice", "Setari"])

with tab1:
    st.write("Tab pentru date")

with tab2:
    st.write("Tab pentru grafice")
""")

st.subheader("Exemplu functional: feature engineering in taburi")

tab_derived, tab_agg = st.tabs(["Variabile derivate", "Variabile agregate"])

with tab_derived:
    st.markdown("Variabilele derivate sunt create din coloane existente.")

    df_derived = df.copy()

    df_derived["price_per_room"] = df_derived["median_house_value"] / df_derived["total_rooms"]
    df_derived["rooms_per_household"] = df_derived["total_rooms"] / df_derived["households"]
    df_derived["bedrooms_per_household"] = df_derived["total_bedrooms"] / df_derived["households"]

    st.dataframe(
        df_derived[
            [
                "median_house_value",
                "total_rooms",
                "price_per_room",
                "rooms_per_household",
                "bedrooms_per_household",
            ]
        ].head(10)
    )

with tab_agg:
    st.markdown("Variabilele agregate rezuma datele pe grupuri.")

    avg_by_location = (
        df.groupby("ocean_proximity")
        .agg(
            {
                "median_house_value": "mean",
                "median_income": "mean",
            }
        )
        .round(2)
        .reset_index()
    )

    st.dataframe(avg_by_location)

# Exercitiul 3
st.subheader("Exercitiul 3: Creeaza propriile taburi")

st.markdown("""
Creeaza 3 taburi:

Summary -> df.describe()  
Shape -> numarul de randuri si coloane  
Columns -> lista coloanelor
""")

ex3_code = st.text_area(
    "Codul tau:",
    value="# Creeaza 3 taburi cu continut diferit\n",
    height=180,
    key="ex3_code"
)

if st.button("Ruleaza", key="ex3_run"):
    try:
        exec(ex3_code, {"st": st, "pd": pd, "np": np, "df": df})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 4: st.latex si st.text_input
st.header("4. LaTeX si input text")

st.markdown("""
st.latex afiseaza formule matematice.

Exemplu:

st.latex(r"E = mc^2")

st.text_input creeaza un camp pentru introducere text.
""")

st.subheader("Exemplu functional")

st.write("Formula corelatie Pearson:")

st.latex(
    r" r_{X,Y} = \frac{\sum (X_i - \bar{X})(Y_i - \bar{Y})}{\sqrt{\sum (X_i - \bar{X})^2} \cdot \sqrt{\sum (Y_i - \bar{Y})^2}} "
)

feature_name = st.text_input(
    "Introdu numele unei noi variabile:",
    value="my_feature",
    key="feat_name"
)

st.write(f"Numele variabilei ar fi: {feature_name}")

# Exercitiul 4
st.subheader("Exercitiul 4: LaTeX si input text")

st.markdown("""
1. Cere utilizatorului numele unei formule folosind st.text_input
2. Afiseaza formula varianta folosind st.latex
""")

ex4_code = st.text_area(
    "Codul tau:",
    value="# Cere numele formulei si afiseaza formula varianta\n",
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

st.slider pentru valori unice si intervale  
st.number_input pentru introducere numerica precisa  
st.tabs pentru organizarea continutului  
st.latex pentru formule matematice  
st.text_input pentru introducere text
""")