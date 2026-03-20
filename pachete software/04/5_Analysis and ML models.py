import streamlit as st
import pandas as pd
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestClassifier
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import accuracy_score
import time

st.title("Pagina 5: Formuri, metrici si session state")
st.markdown("**Abilitati Streamlit:** st.form, st.metric, st.spinner, st.session_state")

st.markdown("---")

df = pd.read_excel("credit_card.xlsx")
df.rename(columns={"default_payment_next_month": "DEFAULT"}, inplace=True)

# CONCEPT 1: st.form
st.header("1. Formuri: st.form")

st.markdown("""
In mod normal, orice modificare a unui widget ruleaza din nou scriptul.
st.form grupeaza mai multe inputuri. Scriptul ruleaza doar cand utilizatorul apasa butonul Submit.

Exemplu:

with st.form("my_form"):
    name = st.text_input("Name")
    age = st.slider("Age", 0, 100, 25)
    submitted = st.form_submit_button("Submit")

if submitted:
    st.write(f"Hello {name}, you are {age} years old")
""")

st.subheader("Exemplu functional: form pentru antrenarea modelului")

X = df.drop(columns=["ID", "DEFAULT"])
y = df["DEFAULT"]

with st.form("training_form"):

    st.markdown("Configurare antrenare model")

    col1, col2 = st.columns(2)

    with col1:
        model_choice = st.selectbox("Model", ["Logistic Regression", "Random Forest"])
        test_size = st.slider("Test size", 0.1, 0.5, 0.2, 0.05)

    with col2:
        if model_choice == "Random Forest":
            n_trees = st.number_input("Numar de arbori", 10, 200, 100, 10)
        else:
            n_trees = 100

        random_state = st.number_input("Random state", 0, 100, 42)

    train_button = st.form_submit_button("Train model")

if train_button:

    with st.spinner("Se antreneaza modelul..."):

        X_train, X_test, y_train, y_test = train_test_split(
            X, y, test_size=test_size, random_state=random_state, stratify=y
        )

        if model_choice == "Logistic Regression":
            model = LogisticRegression(max_iter=1000)
        else:
            model = RandomForestClassifier(n_estimators=n_trees, random_state=random_state)

        model.fit(X_train, y_train)

        y_pred = model.predict(X_test)

        acc = accuracy_score(y_test, y_pred)

    st.success(f"Antrenare finalizata. Accuracy: {acc:.4f}")

    st.session_state["last_accuracy"] = acc
    st.session_state["last_model"] = model_choice

# Exercitiul 1
st.subheader("Exercitiul 1: Creeaza propriul form")

st.markdown("""
Creeaza un form numit data_filter_form cu:

1. number_input pentru varsta minima (15-80)
2. selectbox pentru nivelul de educatie (1,2,3,4)
3. buton Submit numit Filter data

Dupa submit afiseaza cate randuri respecta filtrele.
""")

ex1_code = st.text_area(
    "Codul tau:",
    value="# Creeaza un form cu number_input si selectbox\n",
    height=200,
    key="ex1_code"
)

if st.button("Ruleaza", key="ex1_run"):
    try:
        exec(ex1_code, {"st": st, "pd": pd, "np": np, "df": df})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 2: st.metric
st.header("2. Afisare metrici: st.metric")

st.markdown("""
st.metric afiseaza o valoare numerica evidentiata.

Exemplu:

st.metric("Temperature", "28°C", delta="+2°C")
st.metric("Revenue", "$1,234", delta="-5%")

Metricile arata bine in coloane.
""")

st.subheader("Exemplu functional: dashboard cu metrici")

col1, col2, col3, col4 = st.columns(4)

col1.metric("Total observatii", f"{len(df):,}")
col2.metric("Numar variabile", f"{len(df.columns)}")
col3.metric("Rata default", f"{df['DEFAULT'].mean():.1%}")
col4.metric("Limita credit medie", f"${df['LIMIT_BAL'].mean():,.0f}")

# Exercitiul 2
st.subheader("Exercitiul 2: Creeaza un rand de metrici")

st.markdown("""
Creeaza 3 coloane cu metrici:

1. varsta medie a clientilor
2. valoarea maxima din BILL_AMT1
3. numarul de clienti cu DEFAULT = 1
""")

ex2_code = st.text_area(
    "Codul tau:",
    value="# Creeaza 3 coloane cu st.metric\n",
    height=150,
    key="ex2_code"
)

if st.button("Ruleaza", key="ex2_run"):
    try:
        exec(ex2_code, {"st": st, "pd": pd, "np": np, "df": df})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 3: st.spinner
st.header("3. Indicator incarcare: st.spinner")

st.markdown("""
st.spinner afiseaza un mesaj de incarcare pentru operatii lente.

Exemplu:

with st.spinner("Processing..."):
    time.sleep(2)

st.success("Done")
""")

st.subheader("Exemplu functional")

if st.button("Ruleaza o operatie lenta"):

    with st.spinner("Se simuleaza antrenarea modelului..."):
        time.sleep(2)

    st.success("Operatie finalizata")
    st.balloons()

# Exercitiul 3
st.subheader("Exercitiul 3: Spinner cu calcul")

st.markdown("""
Creeaza un buton Compute statistics.

Cand este apasat:
1. afiseaza spinner
2. calculeaza mean, median si std pentru LIMIT_BAL
3. afiseaza rezultatele folosind 3 metrici
""")

ex3_code = st.text_area(
    "Codul tau:",
    value="# Button + spinner + metrici\n",
    height=180,
    key="ex3_code"
)

if st.button("Ruleaza", key="ex3_run"):
    try:
        exec(ex3_code, {"st": st, "pd": pd, "np": np, "df": df, "time": time})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

# CONCEPT 4: st.session_state
st.header("4. Stare persistenta: st.session_state")

st.markdown("""
Streamlit ruleaza din nou scriptul la fiecare interactiune.

st.session_state permite pastrarea datelor intre rerulari.
""")

st.subheader("Exemplu functional: istoric antrenari")

if "training_history" not in st.session_state:
    st.session_state.training_history = []

with st.form("quick_train"):

    quick_model = st.radio("Model", ["Logistic Regression", "Random Forest"], horizontal=True)

    quick_submit = st.form_submit_button("Quick Train")

if quick_submit:

    with st.spinner("Training..."):

        X_tr, X_te, y_tr, y_te = train_test_split(
            X, y, test_size=0.2, random_state=42, stratify=y
        )

        if quick_model == "Logistic Regression":
            m = LogisticRegression(max_iter=1000)
        else:
            m = RandomForestClassifier(n_estimators=50, random_state=42)

        m.fit(X_tr, y_tr)

        acc = accuracy_score(y_te, m.predict(X_te))

    st.session_state.training_history.append(
        {"Model": quick_model, "Accuracy": f"{acc:.4f}"}
    )

if st.session_state.training_history:

    st.write("Istoric antrenari")

    st.dataframe(pd.DataFrame(st.session_state.training_history))

    if st.button("Sterge istoric"):
        st.session_state.training_history = []
        st.rerun()

else:
    st.info("Nu exista antrenari inca")

# Exercitiul 4
st.subheader("Exercitiul 4: Contor cu session_state")

st.markdown("""
Creeaza un contor de clickuri:

1. initializeaza st.session_state.clicks cu 0
2. buton Click me care creste contorul
3. buton Reset care il reseteaza
4. afiseaza valoarea cu st.metric
""")

ex4_code = st.text_area(
    "Codul tau:",
    value="# Creeaza un contor cu session_state\n",
    height=180,
    key="ex4_code"
)

if st.button("Ruleaza", key="ex4_run"):
    try:
        exec(ex4_code, {"st": st, "pd": pd, "np": np})
    except Exception as e:
        st.error(f"Eroare: {e}")

st.markdown("---")

st.markdown("### Rezumat")

st.markdown("""
Ai exersat:

st.form pentru gruparea inputurilor  
st.metric pentru afisarea indicatorilor numerici  
st.spinner pentru operatii lente  
st.session_state pentru pastrarea datelor intre rerulari
""")