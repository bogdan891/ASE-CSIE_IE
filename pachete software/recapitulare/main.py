import pandas as pd
import plotly.express as px
import streamlit as st

st.title("Sales Dashboard")

# ------------------------------------------------
# Dataseturi
# ------------------------------------------------
# sales.csv
# order_id
# product_id
# country
# quantity
# price
#
# products.csv
# product_id
# product
# category

df_sales = pd.read_csv("sales.csv")
df_products = pd.read_csv("products.csv")


# ------------------------------------------------
# TODO 1: Curățare + Join + Calcule
#
# 1. Înlocuiește valorile lipsă din quantity cu media coloanei.
# 2. Creează un LEFT JOIN între sales și products pe product_id.
#    Salvează rezultatul în df.
# 3. Creează coloana revenue = quantity * price.
# ------------------------------------------------
df_sales["quantity"] = df_sales["quantity"].fillna(df_sales["quantity"].mean())
df_merge = pd.merge(df_sales,df_products, how="left", on="product_id")
df_merge["revenue"] = df_sales["quantity"] * df_sales["price"]
st.dataframe(df_merge)
# ------------------------------------------------
# TODO 2: Agregare
#
# Creează un tabel agregat pe category care conține:
# - total_revenue (suma revenue)
# - total_orders (numărul de order_id)
#
# Salvează rezultatul în category_summary.
# ------------------------------------------------
category_summary = df_merge.groupby("category").agg(
    total_revenue = ("revenue", "sum"),
    total_orders = ("order_id", "count")
)
# ------------------------------------------------
# TODO 3: Afișare tabel
#
# Afișează category_summary într-un tabel Streamlit.
# ------------------------------------------------
st.table(category_summary)
# ------------------------------------------------
# TODO 4: Mini form cu validări
#
# Creează un form care conține:
# - selectbox pentru country (din df)
# - number_input pentru minimum revenue (min 0)
# - buton "Apply Filter"
#
# Validare:
# dacă nu există date pentru filtrul ales,
# afișează un warning cu textul - "No data for selected filter"
#
# Dacă butonul este apăsat:
# filtrează df după:
# - country selectat
# - revenue >= minimum revenue
#
# Afișează rezultatul cu st.dataframe().
# ------------------------------------------------
with st.form("filter_form"):
    selected_country = st.selectbox("Select a country", df_merge["country"].unique())
    min_revenue = st.number_input("Minimum Revenue", min_value=0.0)
    submitted = st.form_submit_button("Apply Filter")

if submitted:
    filtered_df = df_merge[(df_merge['country'] == selected_country) & (df_merge['revenue'] >= min_revenue)]
    if filtered_df.empty:
        st.warning("No data for selected filter")
    else:
        st.dataframe(filtered_df)
# ------------------------------------------------
# Creează un bar chart cu Plotly:
# X = category
# Y = total_revenue
# folosind category_summary
#
# Afișează graficul în aplicație.
# ------------------------------------------------
fig = px.bar(category_summary, x='category', y='total_revenue', title='Total Revenue by Category')
st.plotly_chart(fig)