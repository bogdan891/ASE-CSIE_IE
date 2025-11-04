#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>

typedef struct Inginer Inginer;

typedef struct Nod Nod;

struct Inginer
{
	int idAngajat;
	char* nume;
	char* domeniuActivitate;
	int anulAngajarii;
	float salariul;
	int nrZileLucrate;
	float* nrOreLucratePerZi;
};

struct Nod
{
	Inginer info;
	Nod* next;
};

void dezalocaInginer(Inginer* inginer)
{
	if (inginer == NULL)
	{
		printf("Pointerul este NULL. NU se poate dezaloca!\n");
		return;
	}

	if (inginer->nume != NULL)
	{
		free(inginer->nume);
		inginer->nume = NULL;
	}

	if (inginer->domeniuActivitate != NULL)
	{
		free(inginer->domeniuActivitate);
		inginer->domeniuActivitate = NULL;
	}

	if (inginer->nrOreLucratePerZi != NULL)
	{
		free(inginer->nrOreLucratePerZi);
		inginer->nrOreLucratePerZi = NULL;
	}
}

void dezalocaLista(Nod** cap)
{
	if (*cap == NULL)
		return;

	while (*cap != NULL)
	{
		Nod* temp = *cap;
		*cap = (*cap)->next;

		dezalocaInginer(&temp->info);
		free(temp);
	}
}

Inginer citireInginer(FILE* fstream)
{
	char buffer[50];
	Inginer inginer;

	//Citire idAngajat
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		Inginer zero = { 0 };
		return zero;
	}
	inginer.idAngajat = atoi(buffer);

	//Citire nume
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		Inginer zero = { 0 };
		return zero;
	}
	char* temp = strtok(buffer, "\n");
	inginer.nume = (char*)malloc((strlen(temp) + 1) * sizeof(char));
	if (inginer.nume == NULL)
	{
		inginer.domeniuActivitate = NULL;
		inginer.nrOreLucratePerZi = NULL;
		return;
	}
	strcpy(inginer.nume, temp);

	//Citire domeniuActivitate
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		Inginer zero = { 0 };
		return zero;
	}
	temp = strtok(buffer, "\n");
	inginer.domeniuActivitate = (char*)malloc((strlen(temp) + 1) * sizeof(char));
	strcpy(inginer.domeniuActivitate, temp);

	//Citire anulAngajarii
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		Inginer zero = { 0 };
		return zero;
	}
	inginer.anulAngajarii = atoi(buffer);

	//Citire salariul
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		Inginer zero = { 0 };
		return zero;
	}
	inginer.salariul = atof(buffer);

	//Citire nrZileLucrate
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		Inginer zero = { 0 };
		return zero;
	}
	inginer.nrZileLucrate = atoi(buffer);

	//Citire nrOreLucratePerZi
	inginer.nrOreLucratePerZi = (float*)malloc(inginer.nrZileLucrate * sizeof(float));
	for (int i = 0; i < inginer.nrZileLucrate; i++)
	{
		if (!fgets(buffer, sizeof(buffer), fstream))
		{
			Inginer zero = { 0 };
			return zero;
		}
		inginer.nrOreLucratePerZi[i] = atof(buffer);
	}

	return inginer;
}

void citireVector(FILE* fstream, Inginer** ingineri, int* nrIngineri)
{
	if (fstream == NULL)
	{
		printf("Eroare la citirea din fisier!\n");
		return;
	}

	while (!feof(fstream))
	{
		Inginer* temp = (Inginer*)realloc(*ingineri, ((*nrIngineri) + 1) * sizeof(Inginer));
		if (temp == NULL)
		{
			printf("Eroare la realocarea memoriei!\n");
			return;
		}
		*ingineri = temp;
		(*ingineri)[*nrIngineri] = citireInginer(fstream);
		(*nrIngineri)++;
	}
}

void afisareInginer(Inginer inginer)
{
	printf("-------------------------------------------------------------------------------------------\n");
	printf("ID Angajat: %d\n", inginer.idAngajat);
	printf("Nume: %s\n", inginer.nume);
	printf("Domeniu de activitate: %s\n", inginer.domeniuActivitate);
	printf("Anul angajarii: %d\n", inginer.anulAngajarii);
	printf("Salariul: %.2f\n", inginer.salariul);
	printf("Numarul de zile lucrate pe zi: %d\n", inginer.nrZileLucrate);
	printf("Numarul de ore lucrate pe zi: ");
	for (int i = 0; i < inginer.nrZileLucrate; i++)
		printf("%.2f ", inginer.nrOreLucratePerZi[i]);
	printf("\n");
	printf("-------------------------------------------------------------------------------------------\n");
}

void afisareVector(Inginer* ingineri, int nrIngineri)
{
	if (nrIngineri > 0)
	{
		for (int i = 0; i < nrIngineri; i++)
			afisareInginer(ingineri[i]);
	}
}

void inserareInceputLista(Nod** cap, Inginer inginer)
{
	Nod* temp = (Nod*)malloc(sizeof(Nod));
	temp->info = inginer;
	temp->next = *cap;
	*cap = temp;
}

void stergeUltimulElement(Nod** cap, int* nrIngineri)
{
	if (*cap == NULL)
	{
		printf("Lista este goala!\n");
		return;
	}

	if ((*cap)->next == NULL)
	{
		dezalocaInginer(&(*cap)->info);
		*cap = NULL;
		return;
	}

	Nod* temp = *cap;
	Nod* predecesor = NULL;
	while (temp->next != NULL)
	{
		predecesor = temp;
		temp = temp->next;
	}

	dezalocaInginer(&temp->info);

	free(temp);

	predecesor->next = NULL;
	(*nrIngineri)--;
}

Inginer returnareElement(Nod** cap, int id, int* pozitie, int nrIngineri)
{

	if (*cap == NULL)
	{
		printf("Lista este goala!\n");
		Inginer ing = { 0 };
		return ing;
	}

	*pozitie = 1;
	Nod* temp = *cap;

	for (int i = 0; i < nrIngineri; i++)
	{
		if (temp->info.idAngajat == id)
		{
			printf("Angajatul cu ID = %d se afla pe pozitia %d\n", id, *pozitie);
			return temp->info;
		}
		(*pozitie)++;
		temp = temp->next;
	}

	printf("Angajatul nu a fost gasit in lista!\n");
	Inginer ing = { 0 };
	return ing;
}

void afisareLista(Nod* cap, int nrIngineri)
{
	if (nrIngineri > 0)
	{
		for (int i = 0; i < nrIngineri; i++)
		{
			printf("Afisarea elementelor listei:\n");
			afisareInginer(cap->info);
			cap = cap->next;
		}
	}
	else
	{
		printf("Lista este goala!\n");
	}
}

Inginer* conversieListaVector(Nod* cap, int nrIngineri)
{
	if (cap == NULL || nrIngineri < 0)
		return NULL;

	Inginer* ing = (Inginer*)malloc(nrIngineri * sizeof(Inginer));
	if (!ing)
		return NULL;

	for (int i = 0; i < nrIngineri; i++)
	{
		ing[i].idAngajat = cap->info.idAngajat;

		if (cap->info.nume != NULL)
		{
			ing[i].nume = (char*)malloc(strlen(cap->info.nume) + 1);
			strcpy(ing[i].nume, cap->info.nume);
		}
		else
		{
			ing[i].nume = NULL;
		}

		if (cap->info.domeniuActivitate != NULL)
		{
			ing[i].domeniuActivitate = (char*)malloc(strlen(cap->info.domeniuActivitate) + 1);
			strcpy(ing[i].domeniuActivitate, cap->info.domeniuActivitate);
		}
		else
		{
			ing[i].domeniuActivitate = NULL;
		}

		ing[i].anulAngajarii = cap->info.anulAngajarii;

		ing[i].salariul = cap->info.salariul;

		ing[i].nrZileLucrate = cap->info.nrZileLucrate;

		if (cap->info.nrZileLucrate > 0 && cap->info.nrOreLucratePerZi != NULL)
		{
			ing[i].nrOreLucratePerZi = (float*)malloc(cap->info.nrZileLucrate * sizeof(float));
			for (int j = 0; j < cap->info.nrZileLucrate; j++)
				ing[i].nrOreLucratePerZi[j] = cap->info.nrOreLucratePerZi[j];
		}
		else
		{
			ing[i].nrOreLucratePerZi = NULL;
		}

		cap = cap->next;
	}

	return ing;
}

void main()
{
	FILE* fstream = fopen("ingineri.txt", "r");

	Inginer* ingineri = NULL;
	int nrIngineri = 0;

	//Citire vector de ingineri
	citireVector(fstream, &ingineri, &nrIngineri);
	int nrIngineriVector = nrIngineri;

	Nod* cap = NULL;

	//Inserare in lista
	for (int i = 0; i < nrIngineri; i++)
		inserareInceputLista(&cap, ingineri[i]);

	//Stergerea ultimului element din lista
	stergeUltimulElement(&cap, &nrIngineri);

	//Returnare angajat in functie de id
	int pozitie = 0;
	int id = 102;
	Inginer ing1 = returnareElement(&cap, id, &pozitie, nrIngineri);
	afisareInginer(ing1);

	afisareLista(cap, nrIngineri);

	Inginer* ings = conversieListaVector(cap, nrIngineri);
	printf("Afisare vector convertit:\n");
	afisareVector(ings, nrIngineri);

	//Dezalocari memorie
	dezalocaLista(&cap);

	fclose(fstream);

	//Nota: 8.5 - 9
}