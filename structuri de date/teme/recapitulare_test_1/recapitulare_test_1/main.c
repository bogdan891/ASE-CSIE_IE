#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Film Film;
typedef struct sNod sNod;
typedef struct dNod dNod;

struct Film {
    char* name;
    int duration;
    int releaseYear;
    float ticketPrice;
};

struct sNod {
    Film info;
    sNod* next;
};

struct dNod {
    Film info;
    dNod* prev;
    dNod* next;
};

// ===================== Film =====================

Film initFilm(const char* name, int duration, int releaseYear, float ticketPrice) {
    Film film;
    if (name != NULL) {
        film.name = (char*)malloc(strlen(name) + 1);
        if (film.name != NULL) {
            strcpy(film.name, name);
        }
    }
    else {
        film.name = NULL;
    }
    film.duration = duration;
    film.releaseYear = releaseYear;
    film.ticketPrice = ticketPrice;
    return film;
}

void freeFilm(Film* film) {
    if (film->name != NULL) {
        free(film->name);
        film->name = NULL;
    }
}

// ===================== Citire Film =====================

Film readFilm(FILE* fileStream) {
    char buffer[256];
    Film f = { 0 };

    // Citire nume
    if (!fgets(buffer, sizeof(buffer), fileStream)) return f;
    buffer[strcspn(buffer, "\n")] = '\0';
    f.name = (char*)malloc(strlen(buffer) + 1);
    strcpy(f.name, buffer);

    // Citire durata
    if (!fgets(buffer, sizeof(buffer), fileStream)) { free(f.name); return (Film) { 0 }; }
    f.duration = atoi(buffer);

    // Citire an
    if (!fgets(buffer, sizeof(buffer), fileStream)) { free(f.name); return (Film) { 0 }; }
    f.releaseYear = atoi(buffer);

    // Citire pret
    if (!fgets(buffer, sizeof(buffer), fileStream)) { free(f.name); return (Film) { 0 }; }
    f.ticketPrice = atof(buffer);

    return f;
}

// ===================== Inserare LSI =====================

void insertAtTheEndingLSI(sNod** cap, Film f) {
    sNod* newNod = (sNod*)malloc(sizeof(sNod));
    newNod->info = initFilm(f.name, f.duration, f.releaseYear, f.ticketPrice);
    newNod->next = NULL;

    if (*cap == NULL) {
        *cap = newNod;
    }
    else {
        sNod* current = *cap;
        while (current->next != NULL) {
            current = current->next;
        }
        current->next = newNod;
    }
}

// ===================== Inserare LDI =====================

void insertAtTheEndingLDI(dNod** cap, Film f) {
    dNod* newNod = (dNod*)malloc(sizeof(dNod));
    newNod->info = initFilm(f.name, f.duration, f.releaseYear, f.ticketPrice);
    newNod->next = NULL;
    newNod->prev = NULL;

    if (*cap == NULL) {
        *cap = newNod;
    }
    else {
        dNod* current = *cap;
        while (current->next != NULL) {
            current = current->next;
        }
        current->next = newNod;
        newNod->prev = current;
    }
}

// ===================== Citire din fisier =====================

void insertLsiFromFile(sNod** cap, FILE* file) {
    while (!feof(file)) {
        Film film = readFilm(file);
        if (film.name != NULL) // Verificare citire corecta
            insertAtTheEndingLSI(cap, film);
        freeFilm(&film); // Eliberam memoria temporara
    }
}

void insertLdiFromFile(dNod** cap, FILE* file) {
    while (!feof(file)) {
        Film film = readFilm(file);
        if (film.name != NULL)
            insertAtTheEndingLDI(cap, film);
        freeFilm(&film);
    }
}

// ===================== Conversii =====================

void lsiToLdi(sNod* capS, dNod** capD) {
    dNod* last = NULL;

    while (capS != NULL) {
        dNod* newNod = (dNod*)malloc(sizeof(dNod));

        newNod->info = initFilm(capS->info.name, capS->info.duration,
            capS->info.releaseYear, capS->info.ticketPrice);

        newNod->prev = last;

        newNod->next = NULL;

        if (last != NULL) {
            last->next = newNod;
        }
        else {
            *capD = newNod;
        }

        last = newNod;

        capS = capS->next;
    }
}

void ldiToLsi(dNod* capD, sNod** capS) {
    sNod* tail = NULL;
    while (capD != NULL) {
        sNod* newNod = (sNod*)malloc(sizeof(sNod));
        newNod->info = initFilm(capD->info.name, capD->info.duration,
            capD->info.releaseYear, capD->info.ticketPrice);
        newNod->next = NULL;
        if (*capS == NULL) {
            *capS = newNod;
            tail = newNod;
        }
        else {
            tail->next = newNod;
            tail = newNod;
        }
        capD = capD->next;
    }
}

// ===================== Stergeri =====================

void deleteLSI(sNod** cap, const char* name) {
    sNod* current = *cap;
    sNod* prev = NULL;
    while (current != NULL) {
        if (strcmp(current->info.name, name) == 0) {
            sNod* toDelete = current;
            if (prev == NULL) {
                *cap = current->next;
            }
            else {
                prev->next = current->next;
            }
            current = current->next;
            freeFilm(&(toDelete->info));
            free(toDelete);
        }
        else {
            prev = current;
            current = current->next;
        }
    }
}

void deleteLDI(dNod** cap, const char* name) {
    dNod* current = *cap;
    while (current != NULL) {
        dNod* next = current->next;
        if (strcmp(current->info.name, name) == 0) {
            if (current->prev != NULL)
                current->prev->next = current->next;
            else
                *cap = current->next;
            if (current->next != NULL)
                current->next->prev = current->prev;
            freeFilm(&(current->info));
            free(current);
        }
        current = next;
    }
}

// ===================== Afisare =====================

void showFilm(Film film) {
    printf("====================================\n");
    printf("Name: %s\n", film.name ? film.name : "Unknown");
    printf("Duration: %d minutes\n", film.duration);
    printf("Release Year: %d\n", film.releaseYear);
    printf("Ticket Price: %.2f\n", film.ticketPrice);
    printf("====================================\n");
}

void showLSI(sNod* cap) {
    while (cap != NULL) {
        showFilm(cap->info);
        cap = cap->next;
    }
}

void showLDI(dNod* cap) {
    while (cap != NULL) {
        showFilm(cap->info);
        cap = cap->next;
    }
}

// ===================== Dezalocari =====================

void freeLSI(sNod** cap) {
    sNod* current = *cap;
    while (current != NULL) {
        sNod* next = current->next;
        freeFilm(&(current->info));
        free(current);
        current = next;
    }
    *cap = NULL;
}

void freeLDI(dNod** cap) {
    dNod* current = *cap;
    while (current != NULL) {
        dNod* next = current->next;
        freeFilm(&(current->info));
        free(current);
        current = next;
    }
    *cap = NULL;
}

// ===================== Main =====================

int main() {
    // Exemplu de utilizare pentru LSI
    sNod* listaLSI = NULL;
    FILE* file = fopen("films.txt", "r");
    if (file) {
        insertLsiFromFile(&listaLSI, file);
        fclose(file);
    }
    printf("Lista simplu inlantuita (LSI):\n");
    showLSI(listaLSI);

    // Conversie LSI -> LDI
    dNod* listaLDI = NULL;
    lsiToLdi(listaLSI, &listaLDI);
    printf("\nLista dublu inlantuita (LDI):\n");
    showLDI(listaLDI);

    // Stergere din LSI
    deleteLSI(&listaLSI, "Inception");
    printf("\nLSI dupa stergere 'Inception':\n");
    showLSI(listaLSI);

    // Stergere din LDI
    deleteLDI(&listaLDI, "Inception");
    printf("\nLDI dupa stergere 'Inception':\n");
    showLDI(listaLDI);

    // Dezalocare memorie
    freeLSI(&listaLSI);
    freeLDI(&listaLDI);

    return 0;
}
