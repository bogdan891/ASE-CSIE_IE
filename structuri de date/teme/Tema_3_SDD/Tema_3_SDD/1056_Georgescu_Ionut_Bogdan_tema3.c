#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

typedef struct Game Game;
typedef struct Nod Nod;
typedef struct HashTable HashTable;

struct Game
{
	char* name;
	char* producer;
	int releaseYear;
	float price;
	bool multiplayer;
	int nbOfChapters;
	int* levelsPerChapters;
};

struct Nod
{
	Game info;
	Nod* next;
};

struct HashTable
{
	int size;
	Nod** vector;
};

Game readGame(FILE* file)
{
	Game g;
	char buffer[50];

	//Citire name
	if (!fgets(buffer, sizeof(buffer), file))
	{
		Game zero = { 0 };
		return zero;
	}
	char* temp = strtok(buffer, "\n");
	g.name = (char*)malloc((strlen(temp) + 1) * sizeof(char));
	strcpy(g.name, temp);

	//Citire producer
	if (!fgets(buffer, sizeof(buffer), file))
	{
		Game zero = { 0 };
		return zero;
	}
	temp = strtok(buffer, "\n");
	g.producer = (char*)malloc((strlen(temp) + 1) * sizeof(char));
	strcpy(g.producer, temp);

	//Citire realeaseYear
	if (!fgets(buffer, sizeof(buffer), file))
	{
		Game zero = { 0 };
		return zero;
	}
	g.releaseYear = atoi(buffer);

	//Citire price
	if (!fgets(buffer, sizeof(buffer), file))
	{
		Game zero = { 0 };
		return zero;
	}
	g.price = atof(buffer);

	//Citire multiplayer
	if (!fgets(buffer, sizeof(buffer), file))
	{
		Game zero = { 0 };
		return zero;
	}
	temp = strtok(buffer, "\n");
	if (strcmp(temp, "True") == 0)
	{
		g.multiplayer = true;
	}
	else
	{
		g.multiplayer = false;
	}

	//Citire nbOfParts
	if (!fgets(buffer, sizeof(buffer), file))
	{
		Game zero = { 0 };
		return zero;
	}
	g.nbOfChapters = atoi(buffer);

	//Citire levelsPerChapter
	g.levelsPerChapters = (int*)malloc(g.nbOfChapters * sizeof(int));
	for (int i = 0; i < g.nbOfChapters; i++)
	{
		if (!fgets(buffer, sizeof(buffer), file))
		{
			Game zero = { 0 };
			return zero;
		}
		g.levelsPerChapters[i] = atoi(buffer);
	}

	return g;
}

void readStiva(Nod** varf, FILE* fileStream)
{
	while (!feof(fileStream))
	{
		Nod* temp = (Nod*)malloc(sizeof(Nod));
		Game g = readGame(fileStream);

		if (g.name != NULL)
		{
			temp->info.name = (char*)malloc((strlen(g.name) + 1) * sizeof(char));
			strcpy(temp->info.name, g.name);
		}
		else
		{
			temp->info.name = NULL;
		}

		if (g.producer != NULL)
		{
			temp->info.producer = (char*)malloc((strlen(g.producer) + 1) * sizeof(char));
			strcpy(temp->info.producer, g.producer);
		}
		else
		{
			temp->info.producer = NULL;
		}

		temp->info.releaseYear = g.releaseYear;

		temp->info.price = g.price;

		temp->info.multiplayer = g.multiplayer;

		temp->info.nbOfChapters = g.nbOfChapters;

		if (g.levelsPerChapters != NULL && g.nbOfChapters > 0)
		{
			temp->info.levelsPerChapters = (int*)malloc(g.nbOfChapters * sizeof(int));
			for (int i = 0; i < g.nbOfChapters; i++)
			{
				temp->info.levelsPerChapters[i] = g.levelsPerChapters[i];
			}
		}

		temp->next = *varf;
		*varf = temp;

		if (g.name != NULL)
			free(g.name);
		if (g.producer != NULL)
			free(g.producer);
	}
}

void showGameList(Nod* varf)
{
	int index = 1;
	while (varf != NULL)
	{
		printf("====================== Game #%d =====================\n", index);
		printf("Name: %s\n", varf->info.name ? varf->info.name : "N/A");
		printf("Producer: %s\n", varf->info.producer ? varf->info.producer : "N/A");
		printf("Release year: %d\n", varf->info.releaseYear);
		printf("Price: %.2f\n", varf->info.price);
		printf("Multiplayer: %s\n", varf->info.multiplayer ? "Yes" : "No");
		printf("Number of Chapters: %d\n", varf->info.nbOfChapters);
		printf("Levels per Chapter:");
		if (varf->info.nbOfChapters > 0 && varf->info.levelsPerChapters != NULL)
		{
			for (int i = 0; i < varf->info.nbOfChapters; i++)
			{
				printf(" %d ", varf->info.levelsPerChapters[i]);
			}
			printf("\n");
		}
		else
		{
			printf("N/A\n");
		}
		printf("====================================================\n");
		index++;
		varf = varf->next;
	}
}

void showGame(Game g)
{
	printf("====================================================\n");
	printf("Name: %s\n", g.name ? g.name : "N/A");
	printf("Producer: %s\n", g.producer ? g.producer : "N/A");
	printf("Release year: %d\n", g.releaseYear);
	printf("Price: %.2f\n", g.price);
	printf("Multiplayer: %s\n", g.multiplayer ? "Yes" : "No");
	printf("Number of Chapters: %d\n", g.nbOfChapters);
	printf("Levels per Chapter:");
	if (g.nbOfChapters > 0 && g.levelsPerChapters != NULL)
	{
		for (int i = 0; i < g.nbOfChapters; i++)
		{
			printf(" %d ", g.levelsPerChapters[i]);
		}
		printf("\n");
	}
	else
	{
		printf("N/A\n");
	}
	printf("====================================================\n");

}

Game returnGameByYear(Nod* varf, int year)
{
	if (varf == NULL)
	{
		Game zero = { 0 };
		return zero;
	}

	while (varf != NULL)
	{
		if (varf->info.releaseYear == year)
		{
			return varf->info;
		}

		varf = varf->next;
	}
	Game zero = { 0 };
	return zero;
}

int hashFunction(int releaseYear, int size)
{
	return releaseYear % size;
}

void insertInHashTable(HashTable* ht, Game g)
{
	int index = hashFunction(g.releaseYear, ht->size);
	Nod* temp = (Nod*)malloc(sizeof(Nod));

	if (g.name != NULL)
	{
		temp->info.name = (char*)malloc((strlen(g.name) + 1) * sizeof(char));
		strcpy(temp->info.name, g.name);
	}
	else
	{
		temp->info.name = NULL;
	}

	if (g.producer != NULL)
	{
		temp->info.producer = (char*)malloc((strlen(g.producer) + 1) * sizeof(char));
		strcpy(temp->info.producer, g.producer);
	}

	temp->info.releaseYear = g.releaseYear;

	temp->info.price = g.price;

	temp->info.multiplayer = g.multiplayer;

	temp->info.nbOfChapters = g.nbOfChapters;

	if (g.nbOfChapters > 0 && g.levelsPerChapters != NULL)
	{
		temp->info.levelsPerChapters = (int*)malloc(g.nbOfChapters * sizeof(int));
		for (int i = 0; i < g.nbOfChapters; i++)
		{
			temp->info.levelsPerChapters[i] = g.levelsPerChapters[i];
		}
	}
	else
	{
		temp->info.levelsPerChapters = NULL;
	}

	temp->next = ht->vector[index];
	ht->vector[index] = temp;
}

void toHashTable(HashTable* table, Nod* varf)
{
	if (table->size > 0)
	{
		while (varf != NULL)
		{
			insertInHashTable(table, varf->info);
			varf = varf->next;
		}
	}
}

HashTable initHashTable(int size)
{
	HashTable table;
	table.size = size;
	table.vector = (Nod**)malloc(size * sizeof(Nod*));
	for (int i = 0; i < size; i++)
	{
		table.vector[i] = NULL;
	}

	return table;
}

Nod* copyNod(Game g)
{
	Nod* temp = (Nod*)malloc(sizeof(Nod));

	temp->info.name = (char*)malloc((strlen(g.name) + 1) * sizeof(char));
	strcpy(temp->info.name, g.name);

	temp->info.producer = (char*)malloc((strlen(g.producer) + 1) * sizeof(char));
	strcpy(temp->info.producer, g.producer);

	temp->info.releaseYear = g.releaseYear;

	temp->info.price = g.price;

	temp->info.multiplayer = g.multiplayer;

	temp->info.nbOfChapters = g.nbOfChapters;

	if (g.nbOfChapters > 0 && g.levelsPerChapters != NULL)
	{
		temp->info.levelsPerChapters = (int*)malloc(g.nbOfChapters * sizeof(int));
		for (int i = 0; i < g.nbOfChapters; i++)
		{
			temp->info.levelsPerChapters[i] = g.levelsPerChapters[i];
		}
	}
	else
	{
		temp->info.levelsPerChapters = NULL;
	}

	temp->next = NULL;
	return temp;
}

Nod* getLSIfromHashTable(HashTable* ht, int key)
{
	if (ht == NULL || ht->size == 0)
		return NULL;

	int index = hashFunction(key, ht->size);
	Nod* result = NULL;
	Nod* temp = ht->vector[index];

	while (temp != NULL)
	{
		Nod* nod = copyNod(temp->info);
		nod->next = result;
		result = nod;
		temp = temp->next;
	}

	return result;
}

void showHashTable(HashTable table)
{
	printf("Elementele tabelei de dispersii:\n");
	if (table.vector == NULL || table.size == 0)
	{
		printf("Tabela este goala/nedefinita!\n");
		return;
	}

	for (int i = 0; i < table.size; i++)
	{
		printf("Pozitia %d:\n", i);
		Nod* temp = table.vector[i];
		if (temp == NULL)
		{
			printf("/t-- NULL --\n");
		}
		else
		{
			while (temp != NULL)
			{
				showGame(temp->info);
				temp = temp->next;
			}
		}
	}
}

void deleteGameByPrice(HashTable* table, float priceLimit)
{
	for (int i = 0; i < table->size; i++)
	{
		Nod* current = table->vector[i];
		Nod* prev = NULL;

		while (current != NULL)
		{
			if (current->info.price < priceLimit)
			{
				Nod* toDelete = current;

				if (prev == NULL)
				{
					table->vector[i] = current->next;
					current = table->vector[i];
				}
				else
				{
					prev->next = current->next;
					current = current->next;
				}

				if (toDelete->info.name != NULL)
					free(toDelete->info.name);

				if(toDelete->info.producer != NULL)
					free(toDelete->info.producer);

				if (toDelete->info.levelsPerChapters != NULL)
					free(toDelete->info.levelsPerChapters);

				free(toDelete);
			}
			else
			{
				prev = current;
				current = current->next;
			}
		}
	}
}

void freeGame(Game* g)
{
	if (g->name != NULL)
		free(g->name);
	if (g->producer != NULL)
		free(g->producer);
	if (g->levelsPerChapters != NULL)
		free(g->levelsPerChapters);
}

void freeLSI(Nod* cap)
{
	while (cap != NULL)
	{
		Nod* temp = cap;
		cap = cap->next;
		freeGame(&temp->info);
		free(temp);
	}
}

void freeHashTable(HashTable* table)
{
	if (table->vector != NULL)
	{
		for (int i = 0; i < table->size; i++)
		{
			Nod* current = table->vector[i];
			while (current != NULL)
			{
				Nod* temp = current;
				current = current->next;
				freeGame(&temp->info);
				free(temp);
			}
		}
		free(table->vector);
		table->vector = NULL;
	}
}

void main()
{
	//Cerintele 1 si 2;

	FILE* fileStream = fopen("games.txt", "r");
	Nod* stiva = NULL;
	readStiva(&stiva, fileStream);
	showGameList(stiva);

	//Cerinta 3;
	int year = 2010;
	printf("Primul joc din stiva lansat in anul %d: \n", year);
	Game g1 = returnGameByYear(stiva, year);
	showGame(g1);

	//Cerintele 4, 5;
	int size = 2;
	HashTable table = initHashTable(size);
	toHashTable(&table, stiva);
	
	//Cerinta 6;
	int key = 2010;
	Nod* lsi = getLSIfromHashTable(&table, key);
	//Cerinta 7;
	//Pentru stiva metoda showGameList;
	//Pentru tabela de dispersii
	showHashTable(table);
	//Cerinta 8;
	float priceLimit = 50.00;
	deleteGameByPrice(&table, priceLimit);
	printf("Dupa steregerea jocurilor care au pretul sub %.2f", priceLimit);
	showHashTable(table);
	
	//Eliberare memorie
	freeLSI(stiva);
	freeLSI(lsi);
	freeHashTable(&table);
}