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

// ===================== Funcții Book =====================

Book initBook(const char* title, const char* author, int releaseYear, int nbOfPages) {
    Book b = { 0 };  // Inițializare cu zero/NULL

    if (title != NULL) {
        b.title = (char*)malloc(strlen(title) + 1);
        if (b.title) {
            strcpy(b.title, title);
        }
    }

    if (author != NULL) {
        b.author = (char*)malloc(strlen(author) + 1);
        if (b.author) {
            strcpy(b.author, author);
        }
        else {
            free(b.title);  // Eliberăm memoria dacă alocarea pentru autor eșuează
            b.title = NULL;
        }
    }

    b.releaseYear = releaseYear;
    b.nbOfPages = nbOfPages;

    return b;
}

void freeBook(Book* b) {
    if (b->title != NULL) {
        free(b->title);
        b->title = NULL;
    }
    if (b->author != NULL) {  // Corectat: != în loc de =
        free(b->author);
        b->author = NULL;
    }
}

void printBook(const Book* b) {
    printf("Titlu: %s\nAutor: %s\nAn: %d\nPagini: %d\n\n",
        b->title ? b->title : "Unknown",
        b->author ? b->author : "Unknown",
        b->releaseYear,
        b->nbOfPages);
}

// ===================== Operații Listă =====================

void insertAtTheBeginning(Nod** head, Nod** tail, Book b) {
    Nod* temp = (Nod*)malloc(sizeof(Nod));
    if (!temp) return;

    temp->info = initBook(b.title, b.author, b.releaseYear, b.nbOfPages);
    temp->prev = NULL;
    temp->next = *head;

    if (*head != NULL) {
        (*head)->prev = temp;
    }
    else {
        *tail = temp;  // Dacă lista era goală, setăm și coada
    }
    *head = temp;
}

void insertAtTheEnd(Nod** head, Nod** tail, Book b) {
    Nod* temp = (Nod*)malloc(sizeof(Nod));
    if (!temp) return;

    temp->info = initBook(b.title, b.author, b.releaseYear, b.nbOfPages);
    temp->prev = *tail;
    temp->next = NULL;

    if (*tail != NULL) {
        (*tail)->next = temp;
    }
    else {
        *head = temp;  // Dacă lista era goală, setăm și capul
    }
    *tail = temp;
}

void deleteBook(Nod** head, Nod** tail, const char* author) {
    if (!head || !*head || !tail || !author) return;

    Nod* current = *head;

    while (current != NULL) {
        // Salvăm următorul nod ÎNAINTE de orice operație de ștergere
        Nod* next = current->next;

        if (current->info.author && strcmp(current->info.author, author) == 0) {
            // Actualizăm legăturile pentru nodul anterior
            if (current->prev) {
                current->prev->next = current->next;
            }
            else {
                *head = current->next;  // Este primul nod
            }

            // Actualizăm legăturile pentru nodul următor
            if (current->next) {
                current->next->prev = current->prev;
            }
            else {
                *tail = current->prev;  // Este ultimul nod
            }

            // Eliberăm memoria
            freeBook(&current->info);
            free(current);
        }

        // Trecem la următorul nod salvat anterior
        current = next;
    }
}

// ===================== Conversie ciclică =====================

Nod* toCycle(Nod* head) {
    if (!head) return NULL;

    Nod* tail = head;
    while (tail->next) {
        tail = tail->next;
    }

    // Conectăm coada cu capul și invers pentru a forma un ciclu
    tail->next = head;
    head->prev = tail;

    return head;
}

// ===================== Dezalocare =====================

void freeList(Nod** head) {
    Nod* current = *head;
    while (current != NULL) {
        Nod* next = current->next;
        freeBook(&current->info);
        free(current);
        current = next;
    }
    *head = NULL;
}

void freeCycleList(Nod** head) {
    if (!*head) return;

    // Mai întâi rupem ciclul
    Nod* start = *head;
    Nod* tail = start->prev;  // Ultimul nod

    tail->next = NULL;
    start->prev = NULL;

    // Acum eliberăm ca pe o listă normală
    freeList(head);
}

// ===================== Main =====================

int main() {
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

    // Eliberăm cărțile originale după ce le-am copiat în listă
    freeBook(&b1);
    freeBook(&b2);
    freeBook(&b3);
    freeBook(&b4);

    // Afișare lista inițială
    Nod* temp = head;
    printf("========== Lista dublu inlantuita ==========\n\n");
    while (temp != NULL) {
        printBook(&(temp->info));
        temp = temp->next;
    }

    // Ștergere cărți după autor
    deleteBook(&head, &tail, "Liviu Rebreanu");

    // Afișare lista după ștergere
    temp = head;
    printf("========== Lista dublu inlantuita dupa stergere ==========\n\n");
    while (temp != NULL) {
        printBook(&(temp->info));
        temp = temp->next;
    }

    // Opțional: transformare în listă circulară
    if (head) {
        Nod* cycle = toCycle(head);

        // Important: Rupem legăturile de ciclu înainte de a elibera memoria
        if (cycle && cycle->prev) {
            cycle->prev->next = NULL;
            cycle->prev = NULL;
        }

        // Eliberăm memoria
        freeList(&head);
    }

    return 0;
}
