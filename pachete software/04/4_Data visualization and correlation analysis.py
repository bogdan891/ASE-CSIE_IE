import streamlit as st
import pandas as pd
import numpy as np
import plotly.express as px
import plotly.figure_factory as ff
import plotly.graph_objects as go

st.title("Pagina 4: Grafice avansate si expandere")
st.markdown("**Abilitati Streamlit:** `st.plotly_chart`, `st.expander`, `st.multiselect`")

st.markdown("---")

df = pd.read_csv("housing.csv")
numeric_df = df.select_dtypes(include=["number"])

# CONCEPT 1: st.expander
st.header("1. Sectiuni pliabile: st.expander")

st.markdown("""
st.expander creeaza sectiuni care se pot deschide si inchide.

Exemplu:

with st.expander("Apasa pentru detalii"):
    st.write("Acest continut este ascuns initial")
    st.dataframe(df.head())

Poti seta expanded=True pentru a fi deschis initial.
""")

st.subheader("Exemplu functional: explorarea datelor")

with st.expander("Prezentare generala dataset"):
    st.write(f"Shape: {df.shape[0]} randuri, {df.shape[1]} coloane")
    st.write(f"Memorie folosita: {df.memory_usage(deep=True).sum() / 1024:.1f} KB")
    st.write("Tipuri de date:")
    st.write(df.dtypes)

with st.expander("Sumar statistic"):
    st.dataframe(df.describe())

with st.expander("Valori lipsa"):
    missing = df.isnull().sum()
    missing = missing[missing > 0]
    if len(missing) > 0:
        st.warning(f"Au fost gasite {len(missing)} coloane cu valori lipsa")
        st.write(missing)
    else:
        st.success("Nu exista valori lipsa")

# Exercitiul 1
st.subheader("Exercitiul 1: Creeaza expandere")

st.markdown("""
Creeaza doua expandere:

1. "Primele 5 randuri" -> afiseaza df.head()
2. "Ultimele 5 randuri" -> afiseaza df.tail()
""")

ex1_code = st.text_area(
    "Codul tau:",
    value="# Creeaza doua expandere cu continut diferit\n",
    height=150,
    key="ex1_code"
)

if st.button("Ruleaza", key="ex1_run"):
    try:
        exec(ex1_code, {"st": st, "pd": pd, "np": np, "df": df})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 2: st.multiselect
st.header("2. Selectie multipla: st.multiselect")

st.markdown("""
st.multiselect permite selectarea mai multor optiuni dintr-o lista.

Exemplu:

selected = st.multiselect("Alege coloane:", df.columns)
st.write("Ai selectat:", selected)

Spre deosebire de st.selectbox, care permite o singura alegere,
st.multiselect returneaza o lista.
""")

st.subheader("Exemplu functional: analiza corelatie")

default_cols = list(numeric_df.columns[:4])

selected_cols = st.multiselect(
    "Selecteaza coloane pentru analiza corelatiei",
    options=list(numeric_df.columns),
    default=default_cols,
    key="corr_cols"
)

if len(selected_cols) >= 2:
    corr = numeric_df[selected_cols].corr().round(2)

    fig = px.imshow(
        corr,
        text_auto=True,
        color_continuous_scale=[(0, "darkblue"), (0.5, "white"), (1, "darkred")],
        title="Heatmap corelatie"
    )

    fig.update_layout(height=500)
    st.plotly_chart(fig)

else:
    st.warning("Selecteaza cel putin doua coloane")

# Exercitiul 2
st.subheader("Exercitiul 2: Selectarea coloanelor")

st.markdown("""
Creeaza un st.multiselect care permite utilizatorului sa aleaga ce coloane
sa fie afisate din DataFrame.

Afiseaza doar acele coloane.
""")

ex2_code = st.text_area(
    "Codul tau:",
    value="# Creeaza un multiselect si afiseaza coloanele selectate\n",
    height=120,
    key="ex2_code"
)

if st.button("Ruleaza", key="ex2_run"):
    try:
        exec(ex2_code, {"st": st, "pd": pd, "np": np, "df": df})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 3: Grafice Plotly avansate
st.header("3. Grafice Plotly avansate")

st.markdown("""
Tipuri de grafice utile:

Heatmap pentru corelatii
Histogram pentru distributii
Scatter pentru relatii intre variabile
""")

st.subheader("Exemplu functional: distributia variabilelor")

selected_feature = st.selectbox(
    "Alege o variabila",
    numeric_df.columns,
    key="dist_feature"
)

fig = px.histogram(
    numeric_df,
    x=selected_feature,
    nbins=40,
    marginal="box",
    title=f"Distributia variabilei {selected_feature}"
)

fig.update_layout(height=500)

st.plotly_chart(fig)

with st.expander("Ghid interpretare grafic"):
    st.markdown("""
Histogram arata frecventa valorilor.

Boxplot arata distributia datelor.

Punctele din afara cutiei pot indica outlieri.
""")

# Exercitiul 3
st.subheader("Exercitiul 3: Scatter plot cu trendline")

st.markdown("""
Creeaza un scatter plot:

X: median_income
Y: median_house_value

Adauga trendline si titlu.
""")

ex3_code = st.text_area(
    "Codul tau:",
    value="# Creeaza un scatter plot cu trendline\n",
    height=150,
    key="ex3_code"
)

if st.button("Ruleaza", key="ex3_run"):
    try:
        exec(ex3_code, {"st": st, "pd": pd, "np": np, "df": df, "px": px})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 4: Combinarea widgeturilor
st.header("4. Combinarea widgeturilor")

st.markdown("""
Puterea Streamlit vine din combinarea widgeturilor.

Utilizatorul selecteaza optiuni,
datele se filtreaza,
graficul se actualizeaza automat.
""")

st.subheader("Exemplu functional: generator de grafice")

col1, col2 = st.columns(2)

with col1:
    x_axis = st.selectbox("Axa X", numeric_df.columns, index=0)

with col2:
    y_axis = st.selectbox("Axa Y", numeric_df.columns, index=1)

chart_type = st.radio(
    "Tip grafic",
    ["Scatter", "Histogram", "Boxplot"],
    horizontal=True
)

if chart_type == "Scatter":
    fig = px.scatter(numeric_df, x=x_axis, y=y_axis)

elif chart_type == "Histogram":
    fig = px.histogram(numeric_df, x=x_axis, nbins=30)

else:
    fig = px.box(numeric_df, y=y_axis)

fig.update_layout(height=450)

st.plotly_chart(fig)

# Exercitiul 4
st.subheader("Exercitiul 4: Creeaza propriul generator de grafice")

st.markdown("""
Creeaza un mic generator de grafice:

1. selectbox pentru alegerea unei coloane
2. radio pentru alegerea tipului de grafic
3. afiseaza graficul intr-un expander
""")

ex4_code = st.text_area(
    "Codul tau:",
    value="# Creeaza un generator simplu de grafice\n",
    height=180,
    key="ex4_code"
)

if st.button("Ruleaza", key="ex4_run"):
    try:
        exec(ex4_code, {"st": st, "pd": pd, "np": np, "df": df, "numeric_df": numeric_df, "px": px})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

st.markdown("### Rezumat")

st.markdown("""
Ai exersat:

st.expander pentru sectiuni pliabile  
st.multiselect pentru selectii multiple  
grafice Plotly avansate  
combinarea widgeturilor pentru aplicatii interactive
""")