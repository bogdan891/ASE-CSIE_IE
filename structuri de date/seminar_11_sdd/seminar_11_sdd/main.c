#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>
#include <stdbool.h>

typedef struct Casa Casa;
typedef struct Nod Nod;

struct Casa {
	int id;
	char* numeCasa;
	float facturaGaze;
};

struct Nod {
	Casa info;
	Nod* copilSt;
	Nod* copilDr;
};

Casa initCasa(int id, const char* numeCasa, float facturaGaze) {
	Casa casa;
	casa.id = id;
	casa.facturaGaze = facturaGaze;
	casa.numeCasa = (char*)malloc(sizeof(char) * (strlen(numeCasa) + 1));
	strcpy(casa.numeCasa, numeCasa);

	return casa;
}

void afisareCasa(Casa casa) {
	printf("\nId: %d,nume Casa: %s, factura de gaze: %.2f ", casa.id, casa.numeCasa, casa.facturaGaze);
}

void rotireDreapta(Nod** radacina) {
	Nod* aux = (*radacina)->copilSt;
	(*radacina)->copilSt = aux->copilDr;
	aux->copilDr = *radacina;
	*radacina = aux;
}

void rotireStanga(Nod** radacina) {
	Nod* aux = (*radacina)->copilDr;
	(*radacina)->copilDr = aux->copilSt;
	aux->copilSt = *radacina;
	*radacina = aux;
}

void inserareInAVL(Nod** radacina, Casa casa) {
	if (*radacina == NULL) {
		Nod* nou = (Nod*)malloc(sizeof(Nod));
		nou->info = casa;
		nou->copilSt = NULL;
		nou->copilDr = NULL;
		*radacina = nou;
	}
	else if (casa.id < (*radacina)->info.id) {
		inserareInAVL(&(*radacina)->copilSt, casa);
	}
	else {
		inserareInAVL(&(*radacina)->copilDr, casa);
	}

	int dif = calculDifInaltimeSubarbori(*radacina);

	if (dif == 2) {
		if (calculDifInaltimeSubarbori((*radacina)->copilSt) == -1) {
			rotireStanga(&(*radacina)->copilSt);
		}
		rotireDreapta(radacina);
	}
	if (dif == -2) {
		if (calculDifInaltimeSubarbori((*radacina)->copilDr) == 1) {
			rotireDreapta(&(*radacina)->copilDr);
		}
		rotireStanga(radacina);
	}
}

void inordine(Nod* radacina) {
	//SRD
	if (radacina) {
		inordine(radacina->copilSt);
		afisareCasa(radacina->info);
		inordine(radacina->copilDr);
	}
}

void postordine(Nod* radacina) {
	//SDR
	if (radacina) {
		postordine(radacina->copilSt);
		postordine(radacina->copilDr);
		afisareCasa(radacina->info);
	}
}

Casa cautareDupaId(Nod* radacina, int id) {
	if (radacina == NULL) {
		return initCasa(-1, "", 0.0);
	}
	else if (id == radacina->info.id) {
		return initCasa(radacina->info.id, radacina->info.numeCasa, radacina->info.facturaGaze);
	}
	else if (id < radacina->info.id) {
		return cautareDupaId(radacina->copilSt, id);
	}
	else {
		return cautareDupaId(radacina->copilDr, id);
	}
}



void dezalocare(Nod** radacina) {
	if (*radacina) {
		dezalocare(&(*radacina)->copilSt);
		dezalocare(&(*radacina)->copilDr);
		free((*radacina)->info.numeCasa);
		free(*radacina);
	}
}

bool esteFrunza(Nod* radacina, int id) {
	if (radacina == NULL) return false;

	if (radacina->info.id == id) {
		return (radacina->copilSt == NULL && radacina->copilDr == NULL);
	}

	if (id < radacina->info.id)
		return esteFrunza(radacina->copilSt, id);
	else
		return esteFrunza(radacina->copilDr, id);
}

int main() {
	Nod* radacina = NULL;
	inserareInAVL(&radacina, initCasa(9, "Coman", 6.3));
	inserareInAVL(&radacina, initCasa(5, "Datcu", 6.7));
	inserareInAVL(&radacina, initCasa(17, "Ana", 8.3));
	inserareInAVL(&radacina, initCasa(6, "Maria", 4.1));
	inserareInAVL(&radacina, initCasa(15, "Flavia", 5.3));
	inserareInAVL(&radacina, initCasa(7, "Andreea", 3.3));
	inserareInAVL(&radacina, initCasa(8, "Andrei", 6.3));

	printf("\nParcurgere inordine:");
	inordine(radacina);

	printf("\nParcurgere postordine:");
	postordine(radacina);

	Casa casa = cautareDupaId(radacina, 6);
	printf("\nCasa cu id ul 6:");
	afisareCasa(casa);
	free(casa.numeCasa);

	printf("\nDiferenta dintre inaltimile subarborilor este: %d.", calculDifInaltimeSubarbori(radacina));
	printf("\nInaltimea arborelui este: %d.", inaltimeArbore(radacina));

	int id = 9;
	if (esteFrunza(radacina, id))
		printf("\nNodul ESTE frunza!");
	else
		printf("\nNodul NU ESTE frunza!");

	dezalocare(&radacina);
}