#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>

typedef struct Car Car;

struct Car
{
	char* manufacturer;
	char* model;
	int releaseYear;
	float price;
};

typedef struct Nod Nod;

struct Nod
{
	Car info;
	Nod* next;
};

//Metoda initializare Car
Car initCar(const char* manufacturer, const char* model, int releaseYear, float price)
{
    Car car;

    if (manufacturer != NULL)
    {
        car.manufacturer = (char*)malloc(strlen(manufacturer) + 1);
        if (car.manufacturer != NULL)
        {
            strcpy(car.manufacturer, manufacturer);
        }
        else
        {
            car.manufacturer = NULL;
        }
    }
    else
    {
        car.manufacturer = NULL;
    }

    if (model != NULL)
    {
        car.model = (char*)malloc(strlen(model) + 1);
        if (car.model != NULL)
        {
            strcpy(car.model, model);
        }
        else
        {
            car.model = NULL;
        }
    }
    else
    {
        car.model = NULL;
    }

    car.releaseYear = releaseYear;
    car.price = price;

    return car;
}

//Metoda dezalocare Car
void freeCar(Car* car)
{
    if (car->manufacturer != NULL)
    {
        free(car->manufacturer);
        car->manufacturer = NULL;
    }

    if (car->model != NULL)
    {
        free(car->model);
        car->model = NULL;
    }
}

//Metoda afisare Car
void displayCar(Car car)
{
    printf("----------------------------------\n");
    if (car.manufacturer != NULL)
        printf("Manufacturer: %s\n", car.manufacturer);
    else
        printf("Manufacturer: (null)\n");

    if (car.model != NULL)
        printf("Model: %s\n", car.model);
    else
        printf("Model: (null)\n");

    printf("Release Year: %d\n", car.releaseYear);
    printf("Price: %.2f\n", car.price);
    printf("----------------------------------\n");
}

//Inserare stiva
void push(Nod** varf, Car c)
{
    Nod* temp = (Nod*)malloc(sizeof(Nod));
    temp->info = initCar(c.manufacturer, c.model, c.releaseYear, c.price);
    temp->next = NULL;

    if (*varf == NULL)
    {
        *varf = temp;
    }
    else
    {
        temp->next = *varf;
        *varf = temp;
    }
}

//Metoda stergere element
void pop(Nod** varf)
{
    if (*varf == NULL)
        return;

    Nod* temp = *varf;
    *varf = (*varf)->next;

    free(&temp->info);
}

//Metoda afisare stiva / coada
void display(Nod* cap)
{
    if (cap == NULL)
    {
        printf("Stiva este goala!\n");
        return;
    }

    while (cap != NULL)
    {
        displayCar(cap->info);
        cap = cap->next;
    }
}

//Metoda inserare Coada
void put(Nod** coada, Car c)
{
    Nod* temp = (Nod*)malloc(sizeof(Nod));
    temp->info = initCar(c.manufacturer, c.model, c.releaseYear, c.price);
    temp->next = NULL;

    if (*coada == NULL)
    {
        *coada = temp;
    }
    else
    {
        Nod* current = *coada;
        while (current->next != NULL)
        {
            current = current->next;
        }
        current->next = temp;
    }
}

//Metoda stergere din coada
void dequeue(Nod** coada)
{
    if (*coada == NULL)
        return;

    if ((*coada)->next == NULL)
    {
        free(&(*coada)->info);
        return;
    }

    Nod* temp = *coada;
    *coada = (*coada)->next;
    free(&temp->info);
}

void main()
{
    Car c1 = initCar("Skoda", "Octavia", 2005, 2000);
    Car c2 = initCar("VolksWagen", "Passat", 2002, 1500);
    Car c3 = initCar("Dacia", "Logan", 2007, 1300);
    Nod* stiva = NULL;
    push(&stiva, c1);
    push(&stiva, c2);
    push(&stiva, c3);

    printf("Stiva:\n");
    display(stiva);
    printf("\n");
    printf("Stiva dupa stergere:\n");
    pop(&stiva);
    display(stiva);

    Nod* coada = NULL;
    put(&coada, c1);
    put(&coada, c2);
    put(&coada, c3);
    printf("\n");
    printf("\n");
    printf("Coada:\n");
    display(coada);
    dequeue(&coada);
    printf("\n");
    printf("Coada dupa stergere:\n");
    display(coada);
}