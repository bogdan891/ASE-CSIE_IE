#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>

typedef struct BusRoute BusRoute;
typedef struct NodS NodS;
typedef struct NodD NodD;

struct BusRoute
{
	int inventoryNb;
	char* model;
	char* garage;
	int idRoute;
	float routeDistance;
	int nbOfStops;
	float* timeBetweenStops;
};

struct NodS
{
	BusRoute info;
	NodS* next;
};

struct NodD
{
	NodD* prev;
	BusRoute info;
	NodD* next;
};

BusRoute citireBus(FILE* fstream)
{
	BusRoute b;
	char buffer[50];

	//Citire inventoryNb
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		BusRoute zero = { 0 };
		return zero;
	}
	b.inventoryNb = atoi(buffer);

	//Citire model
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		BusRoute zero = { 0 };
		return zero;
	}
	char* temp = strtok(buffer, "\n");
	b.model = (char*)malloc((strlen(temp) + 1) * sizeof(char));
	strcpy(b.model, temp);

	//Citire garage
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		BusRoute zero = { 0 };
		return zero;
	}
	temp = strtok(buffer, "\n");
	b.garage = (char*)malloc((strlen(temp) + 1) * sizeof(char));
	strcpy(b.garage, temp);

	//Citire idRoute
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		BusRoute zero = { 0 };
		return zero;
	}
	b.idRoute = atoi(buffer);

	//Citire routeDistance
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		BusRoute zero = { 0 };
		return zero;
	}
	b.routeDistance = atof(buffer);

	//Citire nbOfStops
	if (!fgets(buffer, sizeof(buffer), fstream))
	{
		BusRoute zero = { 0 };
		return zero;
	}
	b.nbOfStops = atoi(buffer);

	//Citire timeBetweenStops
	b.timeBetweenStops = (float*)malloc(b.nbOfStops * sizeof(float));
	for (int i = 0; i < b.nbOfStops; i++)
	{
		if (!fgets(buffer, sizeof(buffer), fstream))
		{
			BusRoute zero = { 0 };
			return zero;
		}
		b.timeBetweenStops[i] = atof(buffer);
	}

	return b;
}

void citireListaSI(NodS** cap, FILE* fileStream)
{
	while (!feof(fileStream))
	{
		NodS* temp = (NodS*)malloc(sizeof(NodS));

		BusRoute b = citireBus(fileStream);

		temp->info.inventoryNb = b.inventoryNb;

		if (b.model != NULL)
		{
			temp->info.model = (char*)malloc((strlen(b.model) + 1) * sizeof(char));
			strcpy(temp->info.model, b.model);
		}
		else
		{
			temp->info.model = NULL;
		}

		if (b.garage != NULL)
		{
			temp->info.garage = (char*)malloc((strlen(b.garage) + 1) * sizeof(char));
			strcpy(temp->info.garage, b.garage);
		}
		else
		{
			temp->info.garage = NULL;
		}

		temp->info.idRoute = b.idRoute;

		temp->info.routeDistance = b.routeDistance;

		temp->info.nbOfStops = b.nbOfStops;

		if (b.nbOfStops > 0 && b.timeBetweenStops != NULL)
		{
			temp->info.timeBetweenStops = (float*)malloc(b.nbOfStops * sizeof(float));
			for (int i = 0; i < b.nbOfStops; i++)
			{
				temp->info.timeBetweenStops[i] = b.timeBetweenStops[i];
			}
		}
		else
		{
			temp->info.timeBetweenStops = NULL;
		}

		temp->next = NULL;

		if (*cap == NULL)
		{
			*cap = temp;
		}
		else
		{
			NodS* current = *cap;
			while (current->next != NULL)
			{
				current = current->next;
			}
			current->next = temp;
		}
	}
}

BusRoute initBR(int id, const char* model, const char* garage, int idRoute, float routeDistance, int nbOfStops, float* tbs)
{
	BusRoute br;

	br.inventoryNb = id;

	if (model != NULL)
	{
		br.model = (char*)malloc((strlen(model) + 1) * sizeof(char));
		strcpy(br.model, model);
	}
	else
	{
		br.model = NULL;
	}

	if (garage != NULL)
	{
		br.garage = (char*)malloc((strlen(garage) + 1) * sizeof(char));
		strcpy(br.garage, garage);
	}
	else
	{
		br.garage = NULL;
	}

	br.idRoute = idRoute;

	br.routeDistance = routeDistance;

	br.nbOfStops = nbOfStops;

	if (nbOfStops > 0 && tbs != NULL)
	{
		br.timeBetweenStops = (float*)malloc(nbOfStops * sizeof(float));
		for (int i = 0; i < nbOfStops; i++)
		{
			br.timeBetweenStops[i] = tbs[i];
		}
	}
	else
	{
		br.timeBetweenStops = NULL;
	}

	return br;
}

void showBusLSI(NodS* cap)
{
	NodS* temp = cap;
	while (temp != NULL)
	{
		printf("-------------------------------------------------------------------------\n");

		printf("Bus ID = %d\n", temp->info.inventoryNb);

		if (temp->info.model != NULL)
			printf("Model: %s\n", temp->info.model);
		else
			printf("Model: null\n");

		if (temp->info.garage != NULL)
			printf("Garage: %s\n", temp->info.garage);
		else
			printf("Garage: null\n");

		printf("ID Route: %d\n", temp->info.idRoute);

		printf("Distance: %.2f\n", temp->info.routeDistance);

		printf("Number of Stops: %d\n", temp->info.nbOfStops);

		printf("Time between stops:");
		if (temp->info.nbOfStops > 0 && temp->info.timeBetweenStops != NULL)
		{
			for (int i = 0; i < temp->info.nbOfStops; i++)
			{
				printf(" %.2f", temp->info.timeBetweenStops[i]);
			}
		}
		printf("\n-------------------------------------------------------------------------\n");

		temp = temp->next;
	}
}

void showBusLDI(NodD* cap)
{
	if (cap == NULL)
	{
		printf("NULL list!\n");
		return;
	}

	NodD* temp = cap;

	while(temp!=NULL)
	{
		printf("-------------------------------------------------------------------------\n");

		printf("Bus ID = %d\n", temp->info.inventoryNb);

		if (temp->info.model != NULL)
			printf("Model: %s\n", temp->info.model);
		else
			printf("Model: null\n");

		if (temp->info.garage != NULL)
			printf("Garage: %s\n", temp->info.garage);
		else
			printf("Garage: null\n");

		printf("ID Route: %d\n", temp->info.idRoute);

		printf("Distance: %.2f\n", temp->info.routeDistance);

		printf("Number of Stops: %d\n", temp->info.nbOfStops);

		printf("Time between stops:");
		if (temp->info.nbOfStops > 0 && temp->info.timeBetweenStops != NULL)
		{
			for (int i = 0; i < temp->info.nbOfStops; i++)
			{
				printf(" %.2f", temp->info.timeBetweenStops[i]);
			}
		}
		printf("\n-------------------------------------------------------------------------\n");

		temp = temp->next;
	}
}

void showCycleBusLDI(NodD* cycle)
{
	if (cycle == NULL)
	{
		printf("NULL list!\n");
		return;
	}

	NodD* temp = cycle;

	do
	{
		printf("-------------------------------------------------------------------------\n");

		printf("Bus ID = %d\n", temp->info.inventoryNb);

		if (temp->info.model != NULL)
			printf("Model: %s\n", temp->info.model);
		else
			printf("Model: null\n");

		if (temp->info.garage != NULL)
			printf("Garage: %s\n", temp->info.garage);
		else
			printf("Garage: null\n");

		printf("ID Route: %d\n", temp->info.idRoute);

		printf("Distance: %.2f\n", temp->info.routeDistance);

		printf("Number of Stops: %d\n", temp->info.nbOfStops);

		printf("Time between stops:");
		if (temp->info.nbOfStops > 0 && temp->info.timeBetweenStops != NULL)
		{
			for (int i = 0; i < temp->info.nbOfStops; i++)
			{
				printf(" %.2f", temp->info.timeBetweenStops[i]);
			}
		}
		printf("\n-------------------------------------------------------------------------\n");

		temp = temp->next;
	} while (temp != cycle);
}

void lsiTOldi(NodS* lsi, NodD** ldi)
{
	*ldi = NULL;

	while (lsi != NULL)
	{
		NodD* n = (NodD*)malloc(sizeof(NodD));

		n->info.inventoryNb = lsi->info.inventoryNb;

		if(lsi->info.model!=NULL)
		{
			n->info.model = (char*)malloc((strlen(lsi->info.model) + 1) * sizeof(char));
			strcpy(n->info.model, lsi->info.model);
		}
		else
		{
			n->info.model = NULL;
		}

		if (lsi->info.garage != NULL)
		{
			n->info.garage = (char*)malloc((strlen(lsi->info.garage) + 1) * sizeof(char));
			strcpy(n->info.garage, lsi->info.garage);
		}
		else
		{
			n->info.garage = NULL;
		}

		n->info.idRoute = lsi->info.idRoute;

		n->info.routeDistance = lsi->info.routeDistance;

		n->info.nbOfStops = lsi->info.nbOfStops;

		if (lsi->info.nbOfStops > 0 && lsi->info.timeBetweenStops != NULL)
		{
			n->info.timeBetweenStops = (float*)malloc(lsi->info.nbOfStops * sizeof(float));
			for (int i = 0; i < lsi->info.nbOfStops; i++)
			{
				n->info.timeBetweenStops[i] = lsi->info.timeBetweenStops[i];
			}
		}
		else
		{
			n->info.timeBetweenStops = NULL;
		}

		n->prev = NULL;
		n->next = NULL;

		if (*ldi == NULL)
		{
			*ldi = n;
		}
		else
		{
			NodD* temp = *ldi;
			while (temp->next != NULL)
			{
				temp = temp->next;
			}
			temp->next = n;
			n->prev = temp;
		}

		lsi = lsi->next;
	}
}

void inserareSfarsitLDI(NodD** cap, BusRoute br)
{
	NodD* n = (NodD*)malloc(sizeof(NodD));

	n->info.inventoryNb = br.inventoryNb;

	if (br.model != NULL)
	{
		n->info.model = (char*)malloc((strlen(br.model) + 1) * sizeof(char));
		strcpy(n->info.model, br.model);
	}
	else
	{
		n->info.model = NULL;
	}

	if (br.garage != NULL)
	{
		n->info.garage = (char*)malloc((strlen(br.garage) + 1) * sizeof(char));
		strcpy(n->info.garage, br.garage);
	}
	else
	{
		n->info.garage = NULL;
	}

	n->info.idRoute = br.idRoute;

	n->info.routeDistance = br.routeDistance;

	n->info.nbOfStops = br.nbOfStops;

	if (br.nbOfStops > 0 && br.timeBetweenStops != NULL)
	{
		n->info.timeBetweenStops = (float*)malloc(br.nbOfStops * sizeof(float));
		for (int i = 0; i < br.nbOfStops; i++)
		{
			n->info.timeBetweenStops[i] = br.timeBetweenStops[i];
		}
	}
	else
	{
		n->info.timeBetweenStops = NULL;
	}

	n->prev = NULL;
	n->next = NULL;

	if (*cap == NULL)
	{
		*cap = n;
	}
	else
	{
		NodD* temp = *cap;
		while (temp->next != NULL)
		{
			temp = temp->next;
		}
		temp->next = n;
		n->prev = temp;
	}
}

NodD* returnLDI(NodD* cap, float routeDistance)
{
	NodD* rez = NULL;
	NodD* tail = NULL;
	NodD* start = cap;

	while (cap != NULL)
	{
		if (cap->info.routeDistance == routeDistance)
		{
			NodD* temp = (NodD*)malloc(sizeof(NodD));

			temp->info.inventoryNb = cap->info.inventoryNb;

			if (cap->info.model != NULL)
			{
				temp->info.model = (char*)malloc((strlen(cap->info.model) + 1) * sizeof(char));
				strcpy(temp->info.model, cap->info.model);
			}
			else
			{
				temp->info.model = NULL;
			}

			if (cap->info.garage != NULL)
			{
				temp->info.garage = (char*)malloc((strlen(cap->info.garage) + 1) * sizeof(char));
				strcpy(temp->info.garage, cap->info.garage);
			}
			else
			{
				temp->info.garage = NULL;
			}

			temp->info.idRoute = cap->info.idRoute;

			temp->info.routeDistance = cap->info.routeDistance;

			temp->info.nbOfStops = cap->info.nbOfStops;

			if (cap->info.nbOfStops > 0 && cap->info.timeBetweenStops != NULL)
			{
				temp->info.timeBetweenStops = (float*)malloc(cap->info.nbOfStops * sizeof(float));
				for (int i = 0; i < cap->info.nbOfStops; i++)
				{
					temp->info.timeBetweenStops[i] = cap->info.timeBetweenStops[i];
				}
			}
			else
			{
				temp->info.timeBetweenStops = NULL;
			}

			temp->next = NULL;
			temp->prev = tail;

			if (rez == NULL)
			{
				rez = temp;
			}
			else
			{
				tail->next = temp;
			}
			tail = temp;
		}
		cap = cap->next;
	}
	return rez;
}

void toCycle(NodD** cycle)
{
	if (cycle == NULL || *cycle == NULL)
		return;

	NodD* temp = *cycle;
	
	while (temp->next != NULL)
	{
		temp = temp->next;
	}

	if (temp->next != *cycle)
	{
		temp->next = *cycle;
		(*cycle)->prev = temp;
	}
}

void deleteNodCycleLDI(NodD** cap)
{
	if (*cap == NULL)
		return;

	NodD* temp = *cap;
	do
	{
		NodD* nextNod = temp->next;

		if (temp->info.idRoute % 2 != 0)
		{
			temp->prev->next = temp->next;
			temp->next->prev = temp->prev;

			if (temp == *cap)
				*cap = temp->next;

			if(temp->info.model != NULL)
				free(temp->info.model);

			if(temp->info.garage != NULL)
				free(temp->info.garage);

			if(temp->info.timeBetweenStops != NULL)
				free(temp->info.timeBetweenStops);

			free(temp);
		}
		temp = nextNod;
	} while (temp != *cap);
}

void freeBusRoute(BusRoute* br)
{
	if (br->model != NULL)
		free(br->model);

	if (br->garage != NULL)
		free(br->garage);

	if (br->timeBetweenStops != NULL)
		free(br->timeBetweenStops);
}

freeLSI(NodS** cap)
{
	NodS* temp;
	while (*cap != NULL)
	{
		temp = *cap;
		*cap = (*cap)->next;
		freeBusRoute(&temp->info);
		free(temp);
	}
}

void freeLDI(NodD** cap)
{
	NodD* temp;
	while (*cap != NULL)
	{
		temp = *cap;
		*cap = (*cap)->next;
		freeBusRoute(&temp->info);
		free(temp);
	}
}

void main()
{
	FILE* file = fopen("bus.txt", "r");
	if (file == NULL)
	{
		printf("Error!\nFile not found!\n");
		return;
	}
	else
	{
		NodS* capS = NULL;
		citireListaSI(&capS, file);
		//showBusLSI(capS);

		NodD* capD = NULL;
		lsiTOldi(capS, &capD);

		float tbs[] = { 2,4,2 };
		BusRoute br1 = initBR(1003, "Citaro Hybrid", "Nordului", 331, 11.7, 3, tbs);
		inserareSfarsitLDI(&capD, br1);
		BusRoute br2 = initBR(1004, "AstraBus", "Berceni", 312, 11.7, 3, tbs);
		inserareSfarsitLDI(&capD, br2);
		BusRoute br3 = initBR(1005, "Solaris Urbino", "Vatra Luminoasa", 90, 11.7, 3, tbs);
		inserareSfarsitLDI(&capD, br3);
		//showBusLDI(capD);

		float d = 11.7;
		NodD* ldi = returnLDI(capD, d);
		//showBusLDI(ldi);

		toCycle(&ldi);
		showCycleBusLDI(ldi);

		deleteNodCycleLDI(ldi);
		//showCycleBusLDI(ldi);
		fclose(file);
	}

	//Nota: 9
}