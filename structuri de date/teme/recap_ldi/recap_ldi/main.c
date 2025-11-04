#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Book Book;
typedef struct Nod Nod;

struct Book {
    char* title;
    char* author;
    int releaseYear;
    int nbOfPages;
};

struct Nod {
    Book info;
    Nod* prev;
    Nod* next;
};

Book initBook(const char* title, const char* author, int releaseYear, int nbOfPages) {
    Book b;

    if (title != NULL) {
        b.title = (char*)malloc(strlen(title) + 1);
        strcpy(b.title, title);
    }
    else
    {
        b.title = NULL;
    }

    if (author != NULL) 
    {
        b.author = (char*)malloc(strlen(author) + 1);
        strcpy(b.author, author);
    }
    else
    {
        b.author = NULL;
    }

    b.releaseYear = releaseYear;
    b.nbOfPages = nbOfPages;

    return b;
}

void printBook(const Book* b) {
    printf("Titlu: %s\nAutor: %s\nAn: %d\nPagini: %d\n\n",
        b->title ? b->title : "Unkown",
        b->author ? b->author : "Unknown",
        b->releaseYear,
        b->nbOfPages);
}

void freeBook(Book* b)
{
    if (b->title != NULL)
    {
        free(b->title);
        b->title = NULL;
    }

    if (b->author = NULL)
    {
        free(b->author);
        b->author = NULL;
    }
}

void insertAtTheBeginning(Nod** head, Nod** tail, Book b)
{
    Nod* temp = (Nod*)malloc(sizeof(Nod));
    temp->info = initBook(b.title, b.author, b.releaseYear, b.nbOfPages);
    temp->prev = NULL;
    temp->next = *head;

    if (*head != NULL)
    {
        (*head)->prev = temp;
    }
    else
    {
        *tail = temp;
    }
    *head = temp;
}

void insertAtTheEnd(Nod** head, Nod** tail, Book b)
{
    Nod* temp = (Nod*)malloc(sizeof(Nod));
    temp->info = initBook(b.title, b.author, b.releaseYear, b.nbOfPages);
    temp->prev = *tail;
    temp->next = NULL;

    if (*tail != NULL)
    {
        (*tail)->next = temp;
    }
    else
    {
        (*head) = temp;
    }
    *tail = temp;
}

void deleteBook(Nod** head, Nod** tail, const char* author)
{
    if (*head == NULL || *tail == NULL || author == NULL)
    {
        return;
    }

    Nod* current = *head;
    while (current != NULL)
    {
        Nod* next = current->next;
        if (strcmp(current->info.author, author) == 0 && author != NULL)
        {
            if (current->prev != NULL)
            {
                current->prev->next = current->next;
            }
            else
            {
               *head = current->next;
            }

            if (current->next != NULL)
            {
                current->next->prev = current->prev;
            }
            else
            {
               *tail = current->prev;
            }

            freeBook(&(current->info));
            free(current);
        }
        current = next;
    }
}

void main()
{
    Book b1 = initBook("Hunger Games", "Suzanne Collins", 2015, 344);
    Book b2 = initBook("Ion", "Liviu Rebreanu", 1930, 446);
    Book b3 = initBook("Poesii", "Mihai Eminescu", 1887, 201);
    Book b4 = initBook("Padurea Spanzuratilor", "Liviu Rebreanu", 1934, 237);

    Nod* head = NULL;
    Nod* tail = NULL;

    insertAtTheBeginning(&head, &tail, b1);
    insertAtTheBeginning(&head, &tail, b2);
    insertAtTheEnd(&head, &tail, b3);
    insertAtTheEnd(&head, &tail, b4);

    Nod* temp = head;
    printf("========== Lista dublu inlantuita ==========\n\n");
    while(temp != NULL)
    {
        printBook(&(temp->info));
        temp = temp->next;
    }

    deleteBook(&head, &tail, "Liviu Rebreanu");

    temp = head;
    printf("========== Lista dublu inlantuita dupa stergere ==========\n\n");
    while (temp != NULL)
    {
        printBook(&(temp->info));
        temp = temp->next;
    }
}