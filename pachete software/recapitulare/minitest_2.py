import streamlit as st
import pandas as pd
import plotly.express as px

st.title("📱 User & Device Analytics")

# Încărcăm cele 3 dataseturi
df_usage = pd.read_csv("user_usage.csv")
df_device = pd.read_csv("user_device.csv")
df_supported = pd.read_csv("supported_devices.csv")

# ------------------------------------------------
# TODO 1: Unirea tabelelor (Pandas Merge)
# 1. Fă un LEFT JOIN între df_usage și df_device pe coloana 'use_id'.
#    Salvează în 'df_merged'.
# 2. Redenumește coloana 'Retail Branding' din df_supported în 'manufacturer'.
# 3. Fă un LEFT JOIN între 'df_merged' și 'df_supported'
#    (left_on="device", right_on="Model").
# ------------------------------------------------
df_merged = pd.merge(df_usage, df_device, on="use_id", how="left")
df_supported.rename(columns={"Retail Branding": "manufacturer"}, inplace=True)
df_merged = pd.merge(df_merged, df_supported, left_on="device", right_on="Model", how="left")
st.dataframe(df_merged)

# ------------------------------------------------
# TODO 2: Formularul de filtrare (Streamlit Form)
# 1. Creează un st.form("filter_form").
# 2. În interior, pune un st.slider pentru a alege traficul minim ('monthly_mb').
#    Alege un min_value=0 și un max_value rezonabil.
# 3. Adaugă butonul de submit.
# 4. Dacă s-a apăsat submit, filtrează 'df_merged' să aibă 'monthly_mb' >= valoarea aleasă.
# ------------------------------------------------
with st.form("filter_form"):
    min_mb = float(df_merged["monthly_mb"].min())
    max_mb = float(df_merged["monthly_mb"].max())
    val = st.slider("Traficul minim: ", min_value=min_mb, max_value=max_mb, value=min_mb, help="Alege traficul minim")
    submitted = st.form_submit_button("Afiseaza")

# ------------------------------------------------
# TODO 3: Structura pe Tab-uri (Streamlit Layout)
# 1. Creează două tab-uri: tab1 ("Date Brute") și tab2 ("Grafic Pie").
# 2. În tab1, afișează tabelul filtrat folosind st.dataframe.
# ------------------------------------------------
tab1, tab2 = st.tabs(["Date Brute", "Pie Chart"])
with tab1:
    if submitted:
        df_filtrat = df_merged[df_merged["monthly_mb"] >= val]
        st.dataframe(df_filtrat)
        st.balloons()
    else:
        st.warning("Apasa pe buton!!!")

# ------------------------------------------------
# TODO 4: Vizualizare avansată (Plotly)
# 1. În tab2, numără câți utilizatori sunt per platformă ('platform').
#    (Hint: folosește value_counts().reset_index() pe tabelul filtrat).
# 2. Desenează un grafic circular (px.pie) cu valorile rezultate.
# 3. Afișează graficul în pagină.
# ------------------------------------------------
with tab2:
    platform_counts = df_filtrat['platform'].value_counts().reset_index()
    fig_pie = px.pie(platform_counts, names='platform', values='count', title="Distribuția pe platforme")
    st.plotly_chart(fig_pie)