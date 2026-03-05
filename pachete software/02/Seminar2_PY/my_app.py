import streamlit as st
import requests

st.title("PisiciAPI")

#
# api call
#

def get_cat_images(count):
    url = "https://api.thecatapi.com/v1/images/search?limit=10"
    response = requests.get(url)
    if response.status_code == 200:
        data = response.json()
        return data[:count]
    return None

#
# UI
#

num_images = st.slider(
    "Câte imagini cu pisici vrei să vezi?",
    min_value=1,
    max_value=10,
    value=3
)

if st.button("Arată pisici!"):
    with st.spinner("Se încarcă imaginile..."):
        images = get_cat_images(num_images)

    if images is None or len(images) == 0:
        st.error("Nu s-au putut prelua imaginile. Încearcă din nou.")
    else:
        st.success(f"S-au încărcat {len(images)} imagini!")
        st.divider()

        cols_per_row = 3
        for i in range(0, len(images), cols_per_row):
            cols = st.columns(cols_per_row)
            for j, col in enumerate(cols):
                idx = i + j
                if idx < len(images):
                    img = images[idx]
                    with col:
                        st.image(
                            img["url"],
                            caption=f"Pisica #{idx + 1}",
                            use_container_width=True
                        )

        st.divider()

        # Afișare răspuns complet JSON
        with st.expander("Vezi răspunsul complet API"):
            st.json(images)