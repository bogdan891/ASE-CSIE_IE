
#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include<malloc.h>

typedef struct Casa Casa;
typedef struct Nod Nod;

struct Casa 
{
	int id;
	char* numeCasa;
	float facturaGaze;
};

struct Nod
{
	Casa info;
	Nod* copilSt;
	Nod* copilDr;
};

//fct de init 
Casa initCasa(int id, const char* numeCasa, float facturaGaze)
{
	Casa casa;
	casa.id = id;
	casa.facturaGaze = facturaGaze;
	casa.numeCasa = (char*)malloc(sizeof(char) * (strlen(numeCasa) + 1));
	strcpy(casa.numeCasa, numeCasa);

	return casa;
}

//de afisare Casa
void afisareCasa(Casa casa)
{
	printf("\nID: %d,nume Casa: %s, factura de gaze: %.2f ", casa.id, casa.numeCasa, casa.facturaGaze);
}

//inserare in BST
void inserareInBST(Nod** radacina, Casa casa)
{
	if (*radacina == NULL)
	{
		Nod* temp = (Nod*)malloc(sizeof(Nod));
		temp->info = casa;
		temp->copilSt = NULL;
		temp->copilDr = NULL;
		*radacina = temp;
	}
	else
	{
		if (casa.id < (*radacina)->info.id)
		{
			inserareInBST(&(*radacina)->copilSt, casa);
		}
		else
		{
			inserareInBST(&(*radacina)->copilDr, casa);
		}
	}
}

//fct cautare
Casa cautareID(Nod* radacina, int id)
{
	if (radacina == NULL)
	{
		return (Casa) { 0 };
	}
	else if (id == radacina->info.id)
	{
		return initCasa(radacina->info.id, radacina->info.numeCasa, radacina->info.facturaGaze);
	}
	else if (id < radacina->info.id)
	{
		return cautareID(radacina->copilSt, id);
	}
	else
	{
		return cautareID(radacina->copilDr, id);
	}
}

//parcurgere inordine
void inordine(Nod* radacina)
{
	if (radacina == NULL)
	{
		return;
	}
	inordine(radacina->copilSt);
	afisareCasa(radacina->info);
	inordine(radacina->copilDr);
}

//parcurgere postordine
void postordine(Nod* radacina)
{
	if (radacina == NULL)
	{
		return;
	}
	postordine(radacina->copilSt);
	postordine(radacina->copilDr);
	afisareCasa(radacina->info);
}

//dezalocare
void dezalocare(Nod** radacina)
{
	if (*radacina != NULL)
	{
		dezalocare(&(*radacina)->copilSt);
		dezalocare(&(*radacina)->copilDr);
		free((*radacina)->info.numeCasa);
		free(*radacina);
	}
}

int main() 
{
	Nod* radacina = NULL;
	Casa c1 = initCasa(9, "Coman", 6.3);
	Casa c2 = initCasa(5, "Datcu", 6.7);
	Casa c3 = initCasa(17, "Ana", 8.3);
	Casa c4 = initCasa(6, "Maria", 4.1);
	Casa c5 = initCasa(15, "Flavia", 5.3);
	Casa c6 = initCasa(7, "Andreea", 3.3);
	Casa c7 = initCasa(8, "Andrei", 3.4);

	inserareInBST(&radacina, c1);
	inserareInBST(&radacina, c2);
	inserareInBST(&radacina, c3);
	inserareInBST(&radacina, c4);
	inserareInBST(&radacina, c5);
	inserareInBST(&radacina, c6);
	inserareInBST(&radacina, c7);

	printf("\nParcurgere inordine:\n");
	inordine(radacina);

	printf("\n\nParcurgere postordine:\n");
	postordine(radacina);

	Casa c8 = cautareID(radacina, 6);
	printf("\n\n\nCasa cu ID = 6 este: \n");
	afisareCasa(c8);
	printf("\n\n");
	free(c8.numeCasa);

	dezalocare(&radacina);
}