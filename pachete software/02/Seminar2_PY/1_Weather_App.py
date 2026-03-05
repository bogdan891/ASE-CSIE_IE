import streamlit as st
import requests
import pandas as pd

st.title("Aplicație meteo")

st.markdown("""
### Prezentare generală
Această aplicație folosește **API-ul Open-Meteo** pentru a obține datele meteo curente pentru orice oraș din lume.
Nu este necesară cheie API

- `st.text_input` pentru introducerea datelor de către utilizator
- `st.button` pentru declanșarea unei acțiuni
- `st.metric` pentru afișarea valorilor importante
- `st.columns` pentru afișare pe coloane
- `st.map` pentru afișarea locației pe hartă
- `@st.cache_data` pentru salvarea temporară a răspunsurilor API
- `st.spinner` pentru afișarea unui mesaj de încărcare
""")

st.markdown("---")

# -------------------------------------------------------------------
# Funcții pentru apeluri API cu cache memory
# -------------------------------------------------------------------

@st.cache_data
def geocode_city(city_name):
    """Folosește API-ul de geocodare Open-Meteo pentru a obține latitudinea și longitudinea unui oraș."""
    url = f"https://geocoding-api.open-meteo.com/v1/search?name={city_name}&count=1&language=en"
    response = requests.get(url)
    if response.status_code == 200:
        data = response.json()
        if "results" in data and len(data["results"]) > 0:
            result = data["results"][0]
            return {
                "name": result.get("name"),
                "country": result.get("country", ""),
                "latitude": result["latitude"],
                "longitude": result["longitude"]
            }
    return None


@st.cache_data
def get_weather(latitude, longitude):
    """Preia datele meteo curente din API-ul Open-Meteo."""
    url = (
        f"https://api.open-meteo.com/v1/forecast?"
        f"latitude={latitude}&longitude={longitude}"
        f"&current=temperature_2m,relative_humidity_2m,wind_speed_10m,weather_code"
        f"&timezone=auto"
    )
    response = requests.get(url)
    if response.status_code == 200:
        return response.json()
    return None

# Descrieri coduri meteo
WEATHER_CODES = {
    0: "Cer senin", 1: "Mai mult senin", 2: "Parțial noros", 3: "Înnorat",
    45: "Ceață", 48: "Ceață cu depunere de chiciură",
    51: "Burniță slabă", 53: "Burniță moderată", 55: "Burniță densă",
    61: "Ploaie slabă", 63: "Ploaie moderată", 65: "Ploaie puternică",
    71: "Ninsoare slabă", 73: "Ninsoare moderată", 75: "Ninsoare puternică",
    80: "Averse slabe", 81: "Averse moderate", 82: "Averse puternice",
    95: "Furtună", 96: "Furtună cu grindină slabă", 99: "Furtună cu grindină puternică",
}

# -------------------------------------------------------------------
# Interfața utilizator
# -------------------------------------------------------------------

city = st.text_input("Introdu numele unui oraș", value="București")

if st.button("Obține vremea"):
    with st.spinner("Se preiau datele meteo..."):
        location = geocode_city(city)

        if location is None:
            st.error(f"Nu s-a găsit orașul: {city}. Verifică ortografia.")
        else:
            weather = get_weather(location["latitude"], location["longitude"])

            if weather is None:
                st.error("Nu s-au putut prelua datele meteo. Încearcă din nou.")
            else:
                current = weather["current"]

                st.subheader(f"{location['name']}, {location['country']}")

                # Afișare valori pe coloane
                col1, col2, col3 = st.columns(3)
                col1.metric("Temperatură", f"{current['temperature_2m']} °C")
                col2.metric("Umiditate", f"{current['relative_humidity_2m']}%")
                col3.metric("Viteza vântului", f"{current['wind_speed_10m']} km/h")

                # Descriere condiții meteo
                weather_code = current.get("weather_code", 0)
                description = WEATHER_CODES.get(weather_code, "Necunoscut")
                st.write(f"**Condiții:** {description}")

                # Afișare locație pe hartă
                st.subheader("Locație")
                map_data = pd.DataFrame({
                    "lat": [location["latitude"]],
                    "lon": [location["longitude"]]
                })
                st.map(map_data)

                # Afișare răspuns brut JSON
                with st.expander("Vezi răspunsul complet API"):
                    st.json(weather)

st.markdown("---")
st.markdown("""
### Cum funcționează
1. API-ul de **geocodare** transformă numele orașului în coordonate geografice.
2. API-ul de **prognoză** folosește coordonatele pentru a returna datele meteo curente.
3. Ambele apeluri API sunt salvate temporar cu `@st.cache_data`, astfel încât căutările repetate pentru același oraș sunt instantanee.

Documentație API: Open-Meteo
""")