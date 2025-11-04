#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include<malloc.h>
#include<string.h>
#include<stdlib.h>

typedef struct Shaorma Shaorma;
typedef struct Nod Nod;

struct Shaorma
{
	char* tip;
	float pret;
	int nrIngrediente;
};

struct Nod
{
	Shaorma info;
	Nod* next;
};

void afisareShaorma(Shaorma shaorma)
{
	printf("\nShaorma de tipul %s: costa %.2flei si contine %d ingrediente. ", 
		shaorma.tip, shaorma.pret, shaorma.nrIngrediente);
}

void afisareListaShaorma(Nod* cap)
{
	while (cap != NULL)
	{
		afisareShaorma(cap->info);
		cap = cap->next;
	}
}

float calculPretMediuShaorma(Nod* cap)
{
	float suma = 0;
	int contor = 0;
	while (cap != NULL)
	{
		suma += cap->info.pret;
		contor++;
		cap = cap->next;
	}
	if(contor != 0)
		return suma / contor;
	return 0;
}

int* citire_vector(int* dimensiune, FILE* fisier)
{
	fscanf(fisier, "%d", dimensiune);

	int* vector = (int*)malloc((*dimensiune) * sizeof(int));

	for (int i = 0; i < *dimensiune; i++)
	{
		fscanf(fisier, "%d", &vector[i]);
	}

	return vector;
}

void afisare_vector(int* vector, int dimensiune)
{
	printf("\n");
	for (int i = 0; i < dimensiune; i++)
	{
		printf("%d ", vector[i]);
	}
}

Shaorma citireShaorma(FILE* fileStream) {
	char buffer[10];
	Shaorma shaorma;
	fgets(buffer, 10, fileStream);

	char* tip = strtok(buffer, "\n");
	shaorma.tip = (char*)malloc(sizeof(char) * (strlen(tip) + 1));
	strcpy(shaorma.tip, tip);

	fgets(buffer, 4, fileStream);
	shaorma.pret = atof(buffer);

	fgets(buffer, 4, fileStream);
	shaorma.nrIngrediente = atoi(buffer);

	return shaorma;
}

void citireVectorShaorma(FILE* file, Shaorma** vectorShaorma, int* nrShaorma) {
	if (file == NULL) {
		return;
	}
	while (!feof(file)) {
		*vectorShaorma = (Shaorma*)realloc(*vectorShaorma, ((*nrShaorma) + 1) * sizeof(Shaorma));
		(*vectorShaorma)[*nrShaorma] = citireShaorma(file);
		(*nrShaorma)++;
	}
}

void inserareInceput(Nod** cap, Shaorma shaorma)
{
	Nod* nou = (Nod*)malloc(sizeof(Nod));
	nou->info = shaorma;
	nou->next = *cap;

	*cap = nou;
}

void inserareSfarsit(Nod** cap, Shaorma shaorma)
{
	Nod* nou = (Nod*)malloc(sizeof(Nod));
	nou->info = shaorma;
	nou->next = NULL;
	if ((*cap) == NULL)
		*cap = nou;
	else
	{
		Nod* aux = *cap;
		while (aux->next != NULL)
		{
			aux = aux->next;
		}

		aux->next = nou;
	}
}

void dezalocare(Nod** cap)
{
	while ((*cap) != NULL)
	{
		free((*cap)->info.tip);
		Nod* copie = *cap;
		*cap = (*cap)->next;
		free(copie);
	}
}

void main() {
	/*FILE* fisier = fopen("fisier.txt", "r");
	int value1, value2;

	if (fisier != NULL) {
		fscanf(fisier, "%d", &value1);
		fscanf(fisier, "%d", &value2);
	}

	fclose(fisier);

	printf("\nValue1=%d, value2=%d", value1, value2);

	FILE* f = fopen("file.txt", "r");
	int dimensiune;
	int* vector = NULL;
	if (f != NULL)
	{
		vector = citire_vector(&dimensiune, f);
	}

	afisare_vector(vector, dimensiune);
	free(vector);
	fclose(f);*/

	FILE* fileStream = fopen("Shaorma.txt", "r");
	Shaorma shaorma = citireShaorma(fileStream);

	fclose(fileStream);

	//printf("\nTipul ales este: %s", shaorma.tip);

	free(shaorma.tip);

	FILE* file = fopen("VectorShaorma.txt", "r");
	Shaorma* vectorShaorma = NULL;
	int nrShaorma = 0;
	citireVectorShaorma(fileStream, &vectorShaorma, &nrShaorma);
	//printf("\nAfisare vector:");
	Nod* cap = NULL;
	for (int i = 0; i < nrShaorma; i++) {
		/*printf("\nTipul ales este: %s.", vectorShaorma[i].tip);
		free(vectorShaorma[i].tip);*/
		inserareSfarsit(&cap, vectorShaorma[i]);
	}

	afisareListaShaorma(cap);

	printf("\nPretul mediu pentru o shaorma este %.2flei", calculPretMediuShaorma(cap));

	dezalocare(&cap);

	fclose(file);
}