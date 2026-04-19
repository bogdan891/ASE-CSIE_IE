
import streamlit as st
import pandas as pd
import plotly.express as px

st.title("🔥 Testul de Tortură: Analytics Avansat")

# Încărcăm datele (să zicem mersi că nu ți le-am dat corupte)
df_usage = pd.read_csv("user_usage.csv")
df_device = pd.read_csv("user_device.csv")
df_supported = pd.read_csv("supported_devices.csv")

# ------------------------------------------------
# TODO 1: Coșmarul Merge-urilor în lanț (Pandas)
# 1. Redenumește coloana 'Retail Branding' din df_supported în 'manufacturer'.
# 2. Lipește (LEFT JOIN) df_usage cu df_device pe 'use_id'.
# 3. Lipește rezultatul de mai sus cu df_supported (left_on="device", right_on="Model").
# 4. Elimină (drop) toate rândurile unde 'manufacturer' a rămas NaN (căutăm doar date curate).
#    Salvează monstrul ăsta în variabila `df_master`.
# ------------------------------------------------
df_merge = pd.merge(df_usage, df_device, on="use_id", how="left")
df_supported.rename(columns={"Retail Branding" : "manufacturer"}, inplace=True)
df_merge = pd.merge(df_merge, df_supported, left_on="device", right_on="Model", how="left")
df_master = df_merge.dropna(subset=["manufacturer"]).copy()
st.dataframe(df_master)
# ------------------------------------------------
# TODO 2: Formularul și Memoria (Streamlit session_state)
# 1. Dacă "filtrare_aplicata" nu există în st.session_state, dă-i valoarea 0.
# 2. Creează un formular (st.form). În el pune:
#    - Un multiselect pentru 'platform' (ia valorile unice din df_master).
#    - Un number_input pentru 'Trafic minim MB', valoare default 500.
#    - Buton de submit.
# 3. Dacă apeși submit:
#    - Adaugă +1 la "filtrare_aplicata" în session_state.
#    - Filtrează df_master să aibă DOAR platformele alese ȘI monthly_mb >= traficul minim.
#    - Salvează în `df_filtrat`. (Dacă nu se apasă, df_filtrat = df_master).
# ------------------------------------------------
if "filtrare_aplicata" not in st.session_state:
    st.session_state.filtrare_aplicata = 0

with st.form("formular filtrare"):
    platforme = df_master["platform"].unique()
    val = st.multiselect("Platforme", platforme, help="Alege minim o platforma")
    n = st.number_input("Trafic minim", value=1)
    if val is None:
        st.warning("Selecteaza minim o platforma!")
    submitted = st.form_submit_button("Afiseaza")

if val:
    # CORECȚIE: Paranteze + operatorul &
    masca = (df_master["platform"].isin(val)) & (df_master["monthly_mb"] >= n)
    df_filtrat = df_master[masca].copy()  # .copy() e good practice

    st.session_state.filtrare_aplicata += 1
    st.dataframe(df_filtrat)
    st.balloons()
else:
    st.warning("Alege măcar o platformă din listă!")

# ------------------------------------------------
# TODO 3: Agregarea de nivel Boss (Pandas .agg)
# Folosește `df_filtrat`. Fă un groupby după 'manufacturer' și calculează SIMULTAN:
# - Media pentru 'monthly_mb' (numește coloana 'avg_mb')
# - Maximul pentru 'outgoing_sms_per_month' (numește coloana 'max_sms')
# - Numărul de utilizatori unici ('use_id') (numește coloana 'user_count' -> hint: folosește 'nunique')
#
# După ce resetezi indexul, mai aplică un filtru:
# Păstrează doar producătorii care au `user_count` >= 2.
# Salvează în `df_final`.
# ------------------------------------------------
df_final = df_merge.groupby("manufacturer").agg(
    avg_mb = ("monthly_mb", "mean"),
    max_sms = ("outgoing_sms_per_month", "max"),
    user_count = ("use_id", "nunique")
).reset_index()
df_final = df_final[df_final["user_count"] >= 2]
st.dataframe(df_final)

# În loc să dai direct st.dataframe(df_master), faci așa:
with st.expander("vezi datele brute (df_master)"):
    st.write(f"Tabelul are {df_master.shape[0]} rânduri.")
    st.dataframe(df_master)

# Sau pentru rezultatul final, să nu aglomerezi pagina
with st.expander("📊 Detalii Agregare Producători"):
    if not df_final.empty:
        st.table(df_final.sort_values("user_count", ascending=False))
    else:
        st.info("Niciun producător nu îndeplinește criteriile.")
# ------------------------------------------------
# TODO 4: Plotly pe steroizi (Scatter Bubble Chart)
# 1. Pune un st.metric care să afișeze textul "Filtraje rulate:" și valoarea din session_state.
# 2. Desenează un px.scatter folosind `df_final`.
#    - Axa X = 'avg_mb'
#    - Axa Y = 'max_sms'
#    - Mărimea bulelor (size) = 'user_count'
#    - Culoarea bulelor (color) = 'manufacturer'
# 3. Aruncă graficul pe ecran.
# ------------------------------------------------
st.metric("Filtraje rulate: ", st.session_state.filtrare_aplicata)
fig = px.scatter(df_final, x="avg_mb", y="max_sms", size="user_count", color="manufacturer")
st.plotly_chart(fig)