#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Restaurant Restaurant;
typedef struct Nod Nod;

struct Restaurant
{
	char* nume;
	int capacitate;
	char* domeniu; // Mancare
};

struct Nod
{
	Restaurant info;
	Nod* next;
};

Restaurant initializareRestaurant(const char* nume, int capacitate, const char* domeniu)
{
	Restaurant r;

	if (nume != NULL && domeniu != NULL)
	{
		r.nume = (char*)malloc((strlen(nume) + 1) * sizeof(char));
		strcpy(r.nume, nume);

		r.domeniu = (char*)malloc((strlen(domeniu) + 1) * sizeof(char));
		strcpy(r.domeniu, domeniu);
	}
	else
	{
		r.nume = NULL;
		r.domeniu = NULL;
	}

	r.capacitate = capacitate;

	return r;
}

void afisareRestaurant(Restaurant r)
{
	printf("Nume: %s, Capacitate: %d, Domeniu: %s.\n", r.nume, r.capacitate, r.domeniu);
}

void push(Nod** varf, Restaurant r)
{
	Nod* nou = (Nod*)malloc(sizeof(Nod));
	nou->info = r;
	nou->next = *varf;
	*varf = nou;
}

void put(Nod** coada, Restaurant r)
{
	Nod* nou = (Nod*)malloc(sizeof(Nod));
	nou->info = r;
	nou->next = NULL;
	
	if (*coada == NULL)
		*coada = nou;
	else
	{
		Nod* copie = *coada;
		while (copie->next != NULL)
		{
			copie = copie->next;
		}
		copie->next = nou;
	}
}

Restaurant pop(Nod** varf)
{
	if (*varf == NULL)
		return initializareRestaurant(NULL, 0, NULL);

	Restaurant r = (*varf)->info;
	Nod* temp = *varf;
	*varf = (*varf)->next;
	free(temp);
	return r;
}

void main()
{
	Restaurant r1 = initializareRestaurant("Mc Romana", 56, "Fast-food");
	Restaurant r2 = initializareRestaurant("Socului Obor", 45, "Fast-food");
	Restaurant r3 = initializareRestaurant("C&A Izvor", 16, "Fast-food");

	Nod* stiva = NULL;
	push(&stiva, r1);
	push(&stiva, r2);
	push(&stiva, r3);

	Restaurant r4;

	printf("Afisare STIVA:\n");
	while (stiva != NULL)
	{
		r4 = pop(&stiva);
		afisareRestaurant(r4);
		free(r4.nume);
		free(r4.domeniu);
	}

	Nod* coada = NULL;

	put(&coada, initializareRestaurant("Mc Romana", 56, "Fast-food"));
	put(&coada, initializareRestaurant("Socului Obor", 45, "Fast-food"));
	put(&coada, initializareRestaurant("C&A Izvor", 16, "Fast-food"));

	printf("\nAfisare COADA:\n");
	while (coada != NULL)
	{
		r4 = pop(&coada);
		afisareRestaurant(r4);
		free(r4.nume);
		free(r4.domeniu);
	}
}