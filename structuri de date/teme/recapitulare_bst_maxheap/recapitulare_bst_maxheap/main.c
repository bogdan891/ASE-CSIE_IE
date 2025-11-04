#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>
#include <stdbool.h>

typedef struct Tren Tren;
typedef struct Nod Nod;
typedef struct MaxHeap MaxHeap;

struct Tren {
	char* tip;
	int nr;
	char* ruta;
	float vitezaMax;
};

struct Nod {
	Tren info;
	Nod* stanga;
	Nod* dreapta;
};

struct MaxHeap {
	Tren* vector;
	int dimensiune;
};


//Initializare
Tren initTren(const char* tip, int nr, const char* ruta, float vitezaMax) {
    Tren t;

    if (tip != NULL) {
        t.tip = (char*)malloc((strlen(tip) + 1) * sizeof(char));
        strcpy(t.tip, tip);
    }
    else {
        t.tip = NULL;
    }

    t.nr = nr;

    if (ruta != NULL) {
        t.ruta = (char*)malloc((strlen(ruta) + 1) * sizeof(char));
        strcpy(t.ruta, ruta);
    }
    else {
        t.ruta = NULL;
    }

    t.vitezaMax = vitezaMax;

    return t;
}

//Functie de copiere
Tren copyTren(Tren t) {
    Tren copy =  initTren(t.tip, t.nr, t.ruta, t.vitezaMax);
    return copy;
}

//Functie afisare
void afisareTren(Tren t) {
    printf("====================================\n");
    printf("Tren: %s %d\n", t.tip ? t.tip : "", t.nr);
    printf("Ruta: %s\n", t.ruta ? t.ruta : "-");
    printf("Viteza maxima: %.2f km/h\n", t.vitezaMax);
    printf("====================================\n");
}

//Dezalocare tren
void freeTren(Tren* t) {
    if (t->tip != NULL) {
        free(t->tip);
    }
    if (t->ruta != NULL) {
        free(t->ruta);
    }
}

//Inserare in arbore
void inserareArbore(Nod** radacina, Tren t) {
    if (*radacina == NULL) {
        Nod* temp = (Nod*)malloc(sizeof(Nod));
        temp->info = copyTren(t);
        temp->stanga = NULL;
        temp->dreapta = NULL;
        *radacina = temp;
    }
    else {
        if (t.nr < (*radacina)->info.nr) {
            inserareArbore(&(*radacina)->stanga, t);
        }
        else {
            inserareArbore(&(*radacina)->dreapta, t);
        }
    }
}

//Parcurgere arbore
void parcuregereInordine(Nod* radacina) {
    if (radacina == NULL) {
        return;
    }
    parcuregereInordine(radacina->stanga);
    afisareTren(radacina->info);
    parcuregereInordine(radacina->dreapta);
}

void parcurgerePostordine(Nod* radacina) {
    if (radacina == NULL) {
        return;
    }
    parcurgerePostordine(radacina->stanga);
    parcurgerePostordine(radacina->dreapta);
    afisareTren(radacina->info);
}

//Cautare dupa nr tren
Tren cautareTrenInArbore(Nod* radacina, int nr) {
    if (radacina == NULL) {
        return (Tren) { 0 };
    }
    else if (nr == radacina->info.nr) {
        return copyTren(radacina->info);
    }
    else if (nr < radacina->info.nr) {
        cautareTrenInArbore(radacina->stanga, nr);
    }
    else {
        cautareTrenInArbore(radacina->dreapta, nr);
    }
}

//Stergere frunza din arbore
void stergeFrunza(Nod** radacina, int nr) {
    if (radacina == NULL) {
        return;
    }
    else if (nr == (*radacina)->info.nr) {
        freeTren(&(*radacina)->info);
    }
    else if (nr < (*radacina)->info.nr) {
        stergeFrunza(&(*radacina)->stanga, nr);
    }
    else {
        stergeFrunza(&(*radacina)->dreapta, nr);
    }
}

int nrNoduri(Nod* radacina) {
    if (radacina == NULL) return 0;
    return 1 + nrNoduri(radacina->stanga) + nrNoduri(radacina->dreapta);
}

//Conversie arbore binar -> vector
void conversieVector(Nod* radacina, Tren* vector, int* index) {
    if (radacina != NULL) {
        conversieVector(radacina->stanga, vector, index);
        vector[(*index)++] = radacina->info;
        conversieVector(radacina->dreapta, vector, index);
    }
}

//Filtrare MaxHeap 
void filtrare(MaxHeap mh, int index) {
    if (mh.dimensiune > 0) {
        int max = index;
        int st = 2 * index + 1;
        int dr = 2 * index + 2;

        if (st < mh.dimensiune && mh.vector[max].nr < mh.vector[st].nr) {
            max = st;
        }

        if (dr < mh.dimensiune && mh.vector[max].nr < mh.vector[dr].nr) {
            max = dr;
        }

        if (max != index) {
            Tren aux = mh.vector[max];
            mh.vector[max] = mh.vector[index];
            mh.vector[index] = aux;

            if (max <= mh.dimensiune / 2 + 1) {
                filtrare(mh, max);
            }
        }
    }
}

//Copiere vector
Tren* copyVector(Tren* t, int nrTrenuri) {
    if (t == NULL) {
        return NULL;
    }

    Tren* copy = (Tren*)malloc(sizeof(Tren) * nrTrenuri);
    for (int i = 0; i < nrTrenuri; i++) {
        copy[i] = t[i];
    }
    return copy;
}

//Conversie maxHeap
MaxHeap conversieMaxHeap(Nod* radacina, int nrNoduri) {
    int dim = 0;
    Tren* vector = (Tren*)malloc(sizeof(Tren) * nrNoduri);
    conversieVector(radacina, vector, &dim);
    MaxHeap mh = { dim, copyVector(vector, dim) };
    for (int i = mh.dimensiune; i < mh.dimensiune / 2 + 1; i--) {
        filtrare(mh, i);
    }
    return mh;
}

//Parcurgere 
void parcurgereMaxHeap(MaxHeap mh) {
    if (mh.dimensiune <= 0 && mh.vector == NULL) {
        printf("Nu exitsa elemente in max heap!\n");
        return;
    }

    for (int i = 0; i < mh.dimensiune; i++) {
        afisareTren(mh.vector[i]);
    }
}

//Contorizare elemente tren
int contorTren(MaxHeap mh, const char* tip) {
    int contor = 0;
    for (int i = 0; i < mh.dimensiune; i++) {
        if (strcmp(mh.vector[i].tip, tip) == 0) {
            contor++;
        }
    }
    return contor;
}

//Sortare vector
void bubbleSort(Tren* vector, int nrTrenuri) {
    if (vector == NULL) {
        return;
    }

    for (int i = 0; i < nrTrenuri; i++) {
        for (int j = 0; j < nrTrenuri - i - 1; j++) {
            if (vector[j].nr > vector[j + 1].nr) {
                Tren temp = vector[j];
                vector[j] = vector[j + 1];
                vector[j + 1] = temp;
            }
        }
    }
}

//Returnare vector din MaxHeap
void returnareVector(MaxHeap mh, Tren**vector,  const char* tip) {
    int nrTrenuri = contorTren(mh, tip);
    *vector = (Tren*)malloc(sizeof(Tren) * nrTrenuri);
    int index = 0;
    for (int i = 0; i < mh.dimensiune; i++) {
        if (strcmp(mh.vector[i].tip, tip) == 0) {
            (*vector)[index++] = mh.vector[i];
        }
    }
}

//Stergere trenuri din MaxHeap
void stergeTrenMaxHeap(MaxHeap* mh, const char* tip) {
    if (mh->vector == NULL)
        return;
    int nrTrenuri = mh->dimensiune - contorTren(*mh, tip);
    Tren* trenuri = (Tren*)malloc(sizeof(Tren) * nrTrenuri);
    int index = 0;
    for (int i = 0; i < mh->dimensiune; i++) {
        if (strcmp(mh->vector[i].tip, tip) != 0) {
            trenuri[index++] = initTren(mh->vector[i].tip, mh->vector[i].nr, mh->vector[i].ruta, mh->vector[i].vitezaMax);
        }
    }

    for (int i = 0; i < mh->dimensiune; i++) {
        freeTren(&mh->vector[i]);
    }
    free(mh->vector);

    mh->dimensiune = nrTrenuri;
    mh->vector = (Tren*)malloc(sizeof(Tren) * mh->dimensiune);
    for (int i = 0; i < mh->dimensiune; i++) {
        mh->vector[i] = initTren(trenuri[i].tip, trenuri[i].nr, trenuri[i].ruta, trenuri[i].vitezaMax);
    }

    for (int i = 0; i < nrTrenuri; i++) {
        freeTren(&trenuri[i]);
    }
    free(trenuri);

    for (int i = mh->dimensiune / 2 - 1; i >= 0; i--) {
        filtrare(*mh, i);
    }
}

int main() {
    Nod* radacina = NULL;

    Tren tren1 = initTren("InterCity", 581, "Bucuresti Nord - Constanta", 160.0f);
    Tren tren2 = initTren("Regio", 3021, "Bucuresti Nord - Brasov", 110.5f);
    Tren tren3 = initTren("InterRegio", 1693, "Bucuresti Nord - Timisoara", 160.7f);
    Tren tren4 = initTren("Regio-Express", 3104, "Cluj-Napoca - Oradea", 130.2f);
    Tren tren5 = initTren("InterRegio", 1673, "Iasi - Galati", 150.0f);

    inserareArbore(&radacina, tren1);
    inserareArbore(&radacina, tren2);
    inserareArbore(&radacina, tren3);
    inserareArbore(&radacina, tren4);
    inserareArbore(&radacina, tren5);

    MaxHeap mh = conversieMaxHeap(radacina, nrNoduri(radacina));
    /*printf("Elementele din vectorul MaxHeap: \n");
    parcurgereMaxHeap(mh);*/

    int nrTrenuri = contorTren(mh, "InterRegio");
    Tren* trenuri = NULL;
    //returnareVector(mh, &trenuri, "InterRegio");
    //bubbleSort(trenuri, nrTrenuri);

    /*for (int i = 0; i < nrTrenuri; i++) {
        afisareTren(trenuri[i]);
    }*/

    //stergeTrenMaxHeap(&mh, "InterRegio");
    printf("Elementele din vectorul MaxHeap: \n");
    parcurgereMaxHeap(mh);

    return 0;
}