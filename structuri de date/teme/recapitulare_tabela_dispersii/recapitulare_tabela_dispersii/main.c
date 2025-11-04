#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>

typedef struct Book Book;
typedef struct Nod Nod;
typedef struct HashTable HashTable;

struct Book
{
	char* title;
	char* author;
	int nbOfChapters;
	int nbOfPages;
	float price;
};

struct Nod
{
	Book info;
	Nod* next;
};

struct HashTable
{
	int size;
	Nod** vector;
};

//Initializare element de tip Book
Book initBook(const char* title, const char* author, int nbOfChapters, int nbOfPages, float price) {
	Book b;

	if (title != NULL)
	{
		b.title = (char*)malloc(strlen(title) + 1);
		strcpy(b.title, title);
	}

	if (author != NULL)
	{
		b.author = (char*)malloc(strlen(author) + 1);
		strcpy(b.author, author);
	}

	b.nbOfChapters = nbOfChapters;
	b.nbOfPages = nbOfPages;
	b.price = price;

	return b;
}

//Afisare element de tip Book
void showBook(Book b) 
{
	printf("--------------------------------------------\n");
	printf("Title: %s\n", b.title ? b.title : "Unknown");
	printf("Author: %s\n", b.author ? b.author : "Unknown");
	printf("Number of chapters: %d\n", b.nbOfChapters);
	printf("Number of pages: %d\n", b.nbOfPages);
	printf("Price: %.2f\n", b.price);
	printf("-------------------------------------------\n");
}

//Citire din fisier
Book readBook(FILE* fileStream)
{
	Book b;
	char buffer[50];

	//TITLE
	if (!fgets(buffer, sizeof(buffer), fileStream))
	{
		Book zero = { 0 };
		return zero;
	}
	char* temp = strtok(buffer, "\n");
	b.title = (char*)malloc(strlen(temp) + 1);
	strcpy(b.title, temp);

	//AUTHOR
	if (!fgets(buffer, sizeof(buffer), fileStream))
	{
		Book zero = { 0 };
		return zero;
	}
	temp = strtok(buffer, "\n");
	b.author = (char*)malloc(strlen(temp) + 1);
	strcpy(b.author, temp);

	//NUMBER OF CHAPTERS
	if (!fgets(buffer, sizeof(buffer), fileStream))
	{
		Book zero = { 0 };
		return zero;
	}
	b.nbOfChapters = atoi(buffer);

	//NUMBER OF PAGES
	if (!fgets(buffer, sizeof(buffer), fileStream))
	{
		Book zero = { 0 };
		return zero;
	}
	b.nbOfPages = atoi(buffer);

	//PRICE
	if (!fgets(buffer, sizeof(buffer), fileStream))
	{
		Book zero = { 0 };
		return zero;
	}
	b.price = atof(buffer);

	return b;
}

//Afisare elemente l.s.i.
void showBookList(Nod* cap)
{
	if (cap == NULL)
	{
		printf("The list is empty!\n");
		return;
	}

	while (cap != NULL)
	{
		showBook(cap->info);
		cap = cap->next;
	}
}

//Citire vector de elemente de tip Book
void readBookArray(Book** books, int* size,  FILE* fileStream)
{
	if (fileStream == NULL)
	{
		printf("Error! The file cannot be open.\n");
		return;
	}

	*size = 0;

	while (!feof(fileStream))
	{
		*books = (Book*)realloc(*books, ((*size) + 1) * sizeof(Book));
		(*books)[*size] = readBook(fileStream);
		(*size)++;
	}
}

//Initializare Hashtable
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

//Functia Hash
int HashFunction(int key, int tableSize)
{
	return key % tableSize;
}

//Inserare la sfarsit intr-o L.S.I.
void insert(Nod** cap, Book b)
{
	Nod* temp = (Nod*)malloc(sizeof(Nod));
	temp->info = initBook(b.title, b.author, b.nbOfChapters, b.nbOfPages, b.price);
	temp->next = NULL;
	
	if (*cap == NULL)
	{
		*cap = temp;
	}
	else
	{
		Nod* current = *cap;
		while (current->next != NULL)
		{
			current = current->next;
		}
		current->next = temp;
	}
}

//Inserare HashTable
void insertHashTable(HashTable table, Book book)
{
	int position = HashFunction(book.nbOfChapters, table.size);
	if (position >= 0 && position < table.size)
	{
		insert(&table.vector[position], book);
	}
}

//Afisare HashTable
void showHashTable(HashTable table)
{
	for (int i = 0; i < table.size; i++)
	{
		printf("\nList #%d:\n", i + 1);
		showBookList(table.vector[i]);
	}
}

//Calcul pret mediu
float avgPrice(HashTable table)
{
	float sum = 0;
	int counter = 0;

	for (int i = 0; i < table.size; i++)
	{
		Nod* current = table.vector[i];

		while (current != NULL)
		{
			sum += current->info.price;
			counter++;
			current = current->next;
		}
	}

	if (counter == 0)
		return 0.0f;

	return sum / counter;
}

//Afisare elemente aflate sub pretul mediu
void showBelow(HashTable table)
{
	float avg = avgPrice(table);
	printf("The books that have price below the average price: %.2f\n", avg);
	for (int i = 0; i < table.size; i++)
	{
		Nod* current = table.vector[i];
		while (current != NULL)
		{
			if (current->info.price < avg)
				showBook(current->info);

			current = current->next;
		}
	}
}

//Eliberare Memorie
void freeBook(Book* b)
{
	if (b->title != NULL)
		free(b->title);

	if (b->author != NULL)
		free(b->author);
}

void freeList(Nod* cap)
{
	while(cap!=NULL)
	{
		Nod* n = cap;
		cap = cap->next;
		free(&(n->info));
	}
}

void freeHashTable(HashTable* table)
{
	if (table != NULL && table->vector != NULL)
	{
		for (int i = 0; i < table->size; i++)
		{
			freeList(table->vector[i]);
		}
		free(table->vector);
	}
}

void main()
{
	//Citirea din fisier a unui vector de tip Book
	FILE* file = fopen("books.txt", "r");
	if (file == NULL)
	{
		printf("Error! The file cannot be open.\n");
		return;
	}

	//Initializare vector elemente de tip Book
	Book* books = NULL;
	int size;
	readBookArray(&books, &size, file);

	//Inchidere fisier
	fclose(file);

	//Afisare vector
	/*for (int i = 0; i < size; i++)
	{
		printf("--- Book #%d ---\n", i+1);
		showBook(books[i]);
	}*/

	//Intializare HashTable
	HashTable table = initHashTable(size);
	for (int i = 0; i < table.size; i++)
	{
		insertHashTable(table, books[i]);
	}
	
	//Afisare HashTable
	printf("HashTable: \n");
	showHashTable(table);

	//Afisare elemente book care au pretul mai mic decat pretul mediu
	showBelow(table);

	//Dezalocari
	for (int i = 0; i < size; i++)
	{
		freeBook(&books[i]);
	}
	free(books);

	freeHashTable(&table);
}