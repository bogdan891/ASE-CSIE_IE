import streamlit as st
import requests

st.title("Country Explorer")

st.markdown("""
### Prezentare generală
Această aplicație folosește **REST Countries API** pentru a căuta informații despre orice țară.
Nu este necesară cheie API.

- `st.text_input` pentru introducerea numelui țării
- `st.image` pentru afișarea steagului
- `st.columns` pentru organizarea elementelor în pagină
- `st.json` pentru afișarea datelor brute
- Tratarea erorilor pentru introduceri greșite
""")

st.markdown("---")

# -------------------------------------------------------------------
# Funcție API
# -------------------------------------------------------------------

@st.cache_data
def search_country(name):
    """Caută o țară după nume folosind REST Countries API."""
    url = f"https://restcountries.com/v3.1/name/{name}"
    response = requests.get(url)
    if response.status_code == 200:
        data = response.json()
        if isinstance(data, list) and len(data) > 0:
            return data[0]
    return None

# -------------------------------------------------------------------
# Interfața utilizator
# -------------------------------------------------------------------

country_name = st.text_input("Introdu numele unei țări", value="România")

if st.button("Caută"):
    with st.spinner("Se caută informații..."):
        country = search_country(country_name)

    if country is None:
        st.error(f"Nu s-a găsit țara: '{country_name}'. Verifică ortografia.")
    else:
        # Nume și steag
        official_name = country.get("name", {}).get("official", "N/A")
        common_name = country.get("name", {}).get("common", "N/A")
        flag_url = country.get("flags", {}).get("png", "")

        st.subheader(f"{common_name}")
        st.caption(official_name)

        col1, col2 = st.columns([1, 2])

        with col1:
            if flag_url:
                st.image(flag_url, width=200)

        with col2:
            capital = country.get("capital", ["N/A"])
            capital_str = ", ".join(capital) if isinstance(capital, list) else str(capital)

            region = country.get("region", "N/A")
            subregion = country.get("subregion", "N/A")
            population = country.get("population", 0)

            st.write(f"**Capitală:** {capital_str}")
            st.write(f"**Regiune:** {region} / {subregion}")
            st.write(f"**Populație:** {population:,}")

            # Limbi
            languages = country.get("languages", {})
            if languages:
                lang_str = ", ".join(languages.values())
                st.write(f"**Limbi:** {lang_str}")

            # Monede
            currencies = country.get("currencies", {})
            if currencies:
                curr_list = []
                for code, info in currencies.items():
                    name = info.get("name", code)
                    symbol = info.get("symbol", "")
                    curr_list.append(f"{name} ({symbol})" if symbol else name)
                st.write(f"**Monede:** {', '.join(curr_list)}")

        # Informații suplimentare
        st.divider()
        col3, col4, col5 = st.columns(3)
        col3.metric("Suprafață", f"{country.get('area', 0):,.0f} km2")
        col4.metric("Fusuri orare", str(len(country.get("timezones", []))))
        col5.metric("Țări vecine", str(len(country.get("borders", []))))

        # JSON brut
        with st.expander("Vezi răspunsul complet API"):
            st.json(country)

st.markdown("---")
st.markdown("""
### Cum funcționează
1. Utilizatorul introduce numele unei țări.
2. Aplicația trimite o cerere GET către `https://restcountries.com/v3.1/name/{name}`.
3. API-ul returnează un obiect JSON cu informații detaliate despre țară.
4. Aplicația extrage câmpuri importante, nume, capitală, populație, steag, limbi și monede, și le afișează folosind elemente Streamlit.

Documentație API: REST Countries
""")