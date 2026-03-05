import streamlit as st

st.set_page_config(page_title="Bazele Streamlit și integrarea API", layout="wide")

st.title("Bazele Streamlit și integrarea API")

st.markdown("""
## Introducere

**Streamlit**, este un framework Python pentru construirea aplicațiilor web interactive.
Vom învăța conceptele de bază din Streamlit și vom vedea cum să integrăm **API-uri publice**
pentru a construi aplicații reale, funcționale, doar cu câteva linii de cod.

Structura seminarului:
1. **Bazele Streamlit** pe această pagină, widget-uri, layout, cache și formulare.
2. **Șase mini-aplicații cu API-uri** paginile 1-6, exemple practice cu API-uri gratuite.
3. **Proiect de grup** construiți propria aplicație Streamlit cu API.
""")

# -------------------------------------------------------------------
# SECȚIUNEA 1: Elemente text
# -------------------------------------------------------------------
st.markdown("---")
st.header("1. Elemente text")

st.markdown("""
Streamlit oferă mai multe elemente pentru afișarea textului:
- `st.title()` titlul principal al paginii
- `st.header()` / `st.subheader()` titluri de secțiune
- `st.markdown()` text cu formatare Markdown
- `st.write()` funcție versatilă pentru text, tabele, grafice etc.
- `st.code()` afișează cod cu evidențiere sintactică
- `st.latex()` afișează formule matematice LaTeX
""")

with st.expander("Vezi exemplu de cod"):
    st.code("""
st.title("Titlul aplicației")
st.header("Titlu secțiune")
st.markdown("Text cu **bold**, *italic* și `cod`.")
st.write("st.write() poate afișa aproape orice.")
st.latex(r"E = mc^2")
""", language="python")

# -------------------------------------------------------------------
# SECȚIUNEA 2: Widget-uri de input
# -------------------------------------------------------------------
st.markdown("---")
st.header("2. Widget-uri de input")

st.markdown("""
Widget-urile permit utilizatorilor să interacționeze cu aplicația.
De fiecare dată când o valoare se schimbă, Streamlit rulează din nou scriptul de la început.
""")

col1, col2 = st.columns(2)

with col1:
    st.subheader("Text și selecție")
    name = st.text_input("Introdu numele tău", value="Student")
    color = st.selectbox("Alege o culoare", ["Roșu", "Verde", "Albastru"])
    agree = st.checkbox("Sunt de acord cu termenii")
    st.write(f"Salut **{name}**, ai ales **{color}**. Acord: {agree}")

with col2:
    st.subheader("Numere și slider")
    age = st.slider("Selectează vârsta", 18, 60, 22)
    amount = st.number_input("Introdu o sumă", min_value=0.0, value=10.0, step=0.5)
    choice = st.radio("Alege o opțiune", ["Opțiunea A", "Opțiunea B"])
    st.write(f"Vârstă: {age}, Sumă: {amount}, Alegere: {choice}")

with st.expander("Vezi exemplu de cod"):
    st.code("""
name = st.text_input("Introdu numele")
color = st.selectbox("Alege o culoare", ["Roșu", "Verde", "Albastru"])
age = st.slider("Selectează vârsta", 18, 60, 22)
amount = st.number_input("Introdu o sumă", min_value=0.0)
choice = st.radio("Alege o opțiune", ["A", "B"])
agree = st.checkbox("Sunt de acord")
""", language="python")

# -------------------------------------------------------------------
# SECȚIUNEA 3: Layout
# -------------------------------------------------------------------
st.markdown("---")
st.header("3. Layout")

st.markdown("""
Streamlit oferă mai multe opțiuni pentru organizarea paginii:
- `st.columns()` elemente alăturate
- `st.sidebar` panou lateral
- `st.tabs()` conținut organizat pe tab-uri
- `st.expander()` secțiuni care se pot deschide și închide
""")

tab1, tab2 = st.tabs(["Tab A", "Tab B"])
with tab1:
    st.write("Conținut Tab A")
with tab2:
    st.write("Conținut Tab B")

with st.expander("Vezi exemplu de cod"):
    st.code("""
col1, col2 = st.columns(2)
with col1:
    st.write("Coloana stângă")
with col2:
    st.write("Coloana dreaptă")

tab1, tab2 = st.tabs(["Tab A", "Tab B"])
with tab1:
    st.write("Conținut A")
with tab2:
    st.write("Conținut B")

st.sidebar.title("Titlu sidebar")
option = st.sidebar.selectbox("Alege", ["X", "Y"])
""", language="python")

# -------------------------------------------------------------------
# SECȚIUNEA 4: Elemente de afișare
# -------------------------------------------------------------------
st.markdown("---")
st.header("4. Elemente de afișare")

st.markdown("""
Pe lângă text, Streamlit poate afișa:
- `st.metric()` indicatori cheie
- `st.json()` date JSON formatate
- `st.dataframe()` tabele interactive
- `st.map()` hartă cu puncte latitudine și longitudine
""")

col1, col2, col3 = st.columns(3)
col1.metric("Temperatură", "22 C", "+2 C")
col2.metric("Umiditate", "65%", "-5%")
col3.metric("Vânt", "14 km/h", "+3 km/h")

with st.expander("Vezi exemplu de cod"):
    st.code("""
st.metric("Temperatură", "22 C", "+2 C")
st.json({"nume": "Ana", "scor": 95})
st.dataframe(my_dataframe)
st.map(df_cu_lat_lon)
""", language="python")

# -------------------------------------------------------------------
# SECȚIUNEA 5: Formulare
# -------------------------------------------------------------------
st.markdown("---")
st.header("5. Formulare")

st.markdown("""
Implicit, Streamlit rulează din nou scriptul la fiecare modificare.
Formularele grupează mai multe inputuri și rulează codul doar la apăsarea butonului de trimitere.
Este util când colectezi mai multe valori înainte de un apel API.
""")

with st.form("demo_form"):
    f_name = st.text_input("Prenume")
    f_age = st.number_input("Vârstă", min_value=0, max_value=120, value=20)
    submitted = st.form_submit_button("Trimite")
    if submitted:
        st.success(f"Formular trimis: {f_name}, vârsta {f_age}")

with st.expander("Vezi exemplu de cod"):
    st.code("""
with st.form("formular"):
    name = st.text_input("Nume")
    age = st.number_input("Vârstă", min_value=0)
    submitted = st.form_submit_button("Trimite")
    if submitted:
        st.success(f"Salut {name}, vârsta {age}")
""", language="python")

# -------------------------------------------------------------------
# SECȚIUNEA 6: Cache și indicatori de stare
# -------------------------------------------------------------------
st.markdown("---")
st.header("6. Cache și indicatori de stare")

st.markdown("""
Cache-ul împiedică rularea repetată a operațiilor costisitoare, cum ar fi apelurile API.
Folosește decoratorul `@st.cache_data` pe funcțiile care preiau date.
""")

st.code("""
import requests

@st.cache_data
def fetch_data(url):
    response = requests.get(url)
    return response.json()
""", language="python")

st.markdown("""
Indicatorii de stare informează utilizatorul:
- `st.spinner("Se încarcă...")`
- `st.success("Gata!")`
- `st.error("Eroare!")`
- `st.warning("Atenție!")`
""")

st.code("""
with st.spinner("Se preiau datele..."):
    data = fetch_data(url)
st.success("Date încărcate cu succes!")
""", language="python")

# -------------------------------------------------------------------
# SECȚIUNEA 7: Cum funcționează API-urile
# -------------------------------------------------------------------
st.markdown("---")
st.header("7. Cum funcționează API-urile")

st.markdown("""
Un API permite codului tău Python să comunice cu servicii externe prin internet.

Modelul de bază:
1. Trimiți o cerere HTTP GET către un URL.
2. Primești un răspuns în format JSON.
3. Prelucrezi și afișezi datele.

Toate API-urile folosite în acest seminar sunt gratuite și nu necesită cheie API.
""")

st.code("""
import requests

response = requests.get("https://api.example.com/data")

if response.status_code == 200:
    data = response.json()
    print(data)
else:
    print("Eroare:", response.status_code)
""", language="python")

st.markdown("---")
st.markdown("""
## Pașii următori
Navighează în sidebar pentru a explora cele 6 mini-aplicații cu API.
Fiecare exemplu arată un mod diferit de integrare API în Streamlit.
""")