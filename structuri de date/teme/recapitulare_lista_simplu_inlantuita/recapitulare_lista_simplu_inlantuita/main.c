#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <malloc.h>
#include <stdbool.h>

typedef struct TrainRoute TrainRoute;
typedef struct Nod Nod;

struct TrainRoute
{
	char* departure;
	char* arrival;
	float distance;
	int nbOfStops;
	bool electrified;
};

struct Nod
{
	TrainRoute info;
	Nod* next;
};

//Metoda initializare TrainRoute
TrainRoute initTrainRoute(const char* departure, const char* arrival, float distance, int nbOfStops, bool electrified)
{
	TrainRoute tr;

	if (departure != NULL)
	{
		tr.departure = (char*)malloc(sizeof(char) * (strlen(departure) + 1));
		strcpy(tr.departure, departure);
	}
	else
	{
		tr.departure = NULL;
	}

	if (arrival != NULL)
	{
		tr.arrival = (char*)malloc(sizeof(char) * (strlen(arrival) + 1));
		strcpy(tr.arrival, arrival);
	}
	else
	{
		tr.arrival = NULL;
	}

	tr.distance = distance;

	tr.nbOfStops = nbOfStops;

	tr.electrified = electrified;

	return tr;
}

//Metoda afisare element de tip TrainRoute
void showTrainRoute(TrainRoute tr)
{
	printf("=======================================================================================\n");
	printf("Departure: %s\n", tr.departure ? tr.departure : "N/A");
	printf("Arrival: %s\n", tr.arrival ? tr.arrival : "N/A");
	printf("Distance: %.2f\n", tr.distance);
	printf("Number of stops: %d\n", tr.nbOfStops);
	printf("Is the route electrified? %s\n", tr.electrified ? "Yes" : "No");
	printf("=======================================================================================\n");
}

//Metoda afisare vector cu elemente de tip TrainRoute
void showTrainRoutesArray(TrainRoute* tr, int nbOfRoutes)
{
	if (tr == NULL)
	{
		printf("Vector NULL!\n");
		return;
	}
	else
	{
		for (int i = 0; i < nbOfRoutes; i++)
		{
			showTrainRoute(tr[i]);
		}
	}
}

//Functie de citire din fisier txt a unui element de tip TrainRoute
TrainRoute readTrainRoute(FILE* fileStream)
{
	TrainRoute tr;
	char buffer[50];
	//Citire DEPARTURE
	if (!fgets(buffer, sizeof(buffer), fileStream))
	{
		TrainRoute zero = { 0 };
		return zero;
	}
	char* temp = strtok(buffer, "\n");
	if (temp != NULL)
	{
		tr.departure = (char*)malloc(sizeof(char) * (strlen(buffer) + 1));
		strcpy(tr.departure, temp);
	}
	else
	{
		tr.departure = NULL;
	}
	//Citire ARRIVAL
	if (!fgets(buffer, sizeof(buffer), fileStream))
	{
		TrainRoute zero = { 0 };
		return zero;
	}
	temp = strtok(buffer, "\n");
	if (temp != NULL)
	{
		tr.arrival = (char*)malloc(sizeof(char) * (strlen(buffer) + 1));
		strcpy(tr.arrival, temp);
	}
	else
	{
		tr.arrival = NULL;
	}
	//Citire DISTANCE
	if (!fgets(buffer, sizeof(buffer), fileStream))
	{
		TrainRoute zero = { 0 };
		return zero;
	}
	tr.distance = atof(buffer);
	//Citire NBOFSTOPS
	if (!fgets(buffer, sizeof(buffer), fileStream))
	{
		TrainRoute zero = { 0 };
		return zero;
	}
	tr.nbOfStops = atoi(buffer);
	//Citire electrified
	if (!fgets(buffer, sizeof(buffer), fileStream))
	{
		TrainRoute zero = { 0 };
		return zero;
	}
	temp = strtok(buffer, "\n");
	if (strcmp(buffer, "Yes") == 0)
	{
		tr.electrified = true;
	}
	else
	{
		tr.electrified = false;
	}
	return tr;
}

//Metoda de initializare vector de tip TrainRoute cu elemente citite din fisier txt
void readTrainRouteArray(TrainRoute** tr, int* nbOfRoutes, FILE* fileStream)
{
	if (fileStream == NULL)
	{
		printf("Eroare la citirea din fisier!\n");
		return;
	}
	else
	{
		*nbOfRoutes = 0;
		while (!feof(fileStream))
		{
			TrainRoute* temp = (TrainRoute*)realloc(*tr, ((*nbOfRoutes) + 1) * sizeof(TrainRoute));
			if (temp == NULL)
			{
				printf("Eroare la alocarea memoriei!\n");
				return;
			}
			*tr = temp;
			(*tr)[*nbOfRoutes] = readTrainRoute(fileStream);
			(*nbOfRoutes)++;
		}
	}
}

//Dezalocare memorie structura TrainRoute
void freeTrainRoute(TrainRoute tr)
{
	if (tr.arrival != NULL)
		free(tr.arrival);

	if (tr.departure != NULL)
		free(tr.departure);
}

//Dezalocare memorie vector de tip TrainRoute
void freeTrainRouteArray(TrainRoute* tr, int nbOfRoutes)
{
	if (tr == NULL)
		return;
	for (int i = 0; i < nbOfRoutes; i++)
	{
		freeTrainRoute(tr[i]);
	}
	free(tr);
}

//inserare la inceput intr-o L.S.I.
void insertAtTheBeginning(Nod** cap, TrainRoute tr)
{
	Nod* temp = (Nod*)malloc(sizeof(Nod));
	temp->info = initTrainRoute(tr.departure, tr.arrival, tr.distance, tr.nbOfStops, tr.electrified);
	temp->next = *cap;
	*cap = temp;
}

//inserare la sfarsit intr-o L.S.I.
void insertAtTheEnding(Nod** cap, TrainRoute tr)
{
	Nod* temp = (Nod*)malloc(sizeof(Nod));
	temp->info = initTrainRoute(tr.departure, tr.arrival, tr.distance, tr.nbOfStops, tr.electrified);
	temp->next = NULL;
	if (*cap == NULL)
	{
		*cap = temp;
	}
	else
	{
		Nod* aux = *cap;
		while (aux->next != NULL)
		{
			aux = aux->next;
		}
		aux->next = temp;
	}
}

//Afisare elemente L.S.I. stanga -> dreapta
void showLSI(Nod* cap)
{
	if (cap == NULL)
	{
		printf("Lista este goala!\n");
		return;
	}

	while (cap != NULL)
	{
		showTrainRoute(cap->info);
		cap = cap->next;
	}
}

//Dezalocare memorie intr-o L.S.I.
void freeLSI(Nod** cap)
{
	while ((*cap) != NULL)
	{
		freeTrainRoute((*cap)->info);
		Nod* temp = *cap;
		*cap = (*cap)->next;
		free(temp);
	}
}

//Stergere element
void deleteLastElement(Nod** cap)
{
	if (*cap == NULL)
	{
		printf("Lista este goala!\n");
		return;
	}
	
	if ((*cap)->next == NULL)
	{
		freeTrainRoute((*cap)->info);
		*cap = NULL;
		return;
	}

	Nod* temp = *cap;
	Nod* prev = NULL;
	while (temp->next != NULL)
	{
		prev = temp;
		temp = temp->next;
	}
	freeTrainRoute(temp->info);
	free(temp);
	prev->next = NULL;
}

//Returnare element
TrainRoute returnElement(Nod* cap, const char* departure, const char* arrival)
{
	if (cap == NULL)
	{
		printf("Lista este goala!\n");
		return;
	}

	while (cap != NULL)
	{
		if (strcmp(cap->info.departure, departure) == 0 && strcmp(cap->info.arrival, arrival) == 0)
		{
			return cap->info;
		}
		else
		{
			cap = cap->next;
		}
	}
}

void main()
{
	//Deschidere fisier
	FILE* fileStream = fopen("routes.txt", "r");

	//Declarare vector de tip TrainRoute
	TrainRoute* trainRoutes = NULL;
	int nbOfRoutes;

	//Citire vector de TrainRoute din fisier
	readTrainRouteArray(&trainRoutes, &nbOfRoutes, fileStream);

	//Inchidere fisier
	fclose(fileStream);
	
	//Afisare vector de tip TrainRoute
	/*printf("TrainRoute Array:\n");
	showTrainRoutesArray(trainRoutes, nbOfRoutes);*/

	//Declarare L.S.I.
	Nod* cap = NULL;

	//Inserare valori in L.S.I.
	for (int i = 0; i < nbOfRoutes; i++)
	{
		insertAtTheBeginning(&cap, trainRoutes[i]);
	}
	TrainRoute tr1 = initTrainRoute("Bucharest", "Targoviste", 80.00, 3, false);
	insertAtTheBeginning(&cap, tr1);
	TrainRoute tr2 = initTrainRoute("Cluj-Napoca", "Oradea", 120.59, 5, false);
	insertAtTheEnding(&cap, tr2);

	//Afisare valori L.S.I.
	/*printf("Elementele listei simplu inlantuite:\n");
	showLSI(cap);*/

	//Stergere elemente L.S.I.
	/*deleteLastElement(&cap);
	printf("\nElementele listei simplu inlantuite dupa stergere:\n");
	showLSI(cap);*/

	//Returnare element in functie de ruta
	TrainRoute tr3 = returnElement(cap, "Bucharest", "Budapest");
	showTrainRoute(tr3);

	//Dezalocare membrii alocati static
	freeTrainRouteArray(trainRoutes, nbOfRoutes);
	freeLSI(&cap);
	free(cap);
}