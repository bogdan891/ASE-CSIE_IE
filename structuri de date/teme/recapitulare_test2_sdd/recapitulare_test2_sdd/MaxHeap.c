//#define _CRT_SECURE_NO_WARNINGS
//#include <stdio.h>
//#include <stdlib.h>
//#include <malloc.h>
//#include <string.h>
//
//typedef struct Produs Produs;
//typedef struct MaxHeap MaxHeap;
//
//struct Produs
//{
//    int Id;
//    char* nume;
//    float pret;
//};
//
//struct MaxHeap
//{
//    Produs* vector;
//    int dimensiune;
//};
//
//Produs copiereProdus(Produs p)
//{
//    Produs copie;
//    copie.Id = p.Id;
//    copie.pret = p.pret;
//    copie.nume = (char*)malloc(sizeof(char) * (strlen(p.nume) + 1));
//    strcpy(copie.nume, p.nume);
//    return copie;
//}
//
//Produs initProdus(int Id, const char* nume, float pret)
//{
//    Produs p;
//    p.Id = Id;
//    p.nume = (char*)malloc(sizeof(char) * (strlen(nume) + 1));
//    if (nume != NULL)
//    {
//        strcpy(p.nume, nume);
//    }
//    p.pret = pret;
//    return p;
//}
//
//void afisareProdus(Produs p)
//{
//    printf("\n==============\n");
//    printf("\nId: %d", p.Id);
//    printf("\nNume: %s", p.nume);
//    printf("\nPret: %.2f", p.pret);
//    printf("\n");
//}
//
//void dezalocareProdus(Produs p)
//{
//    free(p.nume);
//}
//
//void traversareMaxHeap(MaxHeap mh)
//{
//    for (int i = 0; i < mh.dimensiune; i++)
//    {
//        afisareProdus(mh.vector[i]);
//    }
//}
//
//void filtrareMaxHeap(MaxHeap mh, int index)
//{
//    // index = poz nodului de la care trebuie verificata proprietatea
//    if (mh.dimensiune > 0)
//    {
//        int pozMax = index;            // pp ca elementul curent este cel mai mare
//        int pozStanga = 2 * index + 1; // calc copilul din stanga
//        int pozDreapta = 2 * index + 2;
//
//        if (pozStanga < mh.dimensiune && mh.vector[pozMax].Id < mh.vector[pozStanga].Id)
//        {
//            // daca exista copilul din stanga si are Id mai mare decat nodul curent =>
//            // copilul din stanga devine noul pozMax
//            pozMax = pozStanga;
//        }
//        if (pozDreapta < mh.dimensiune && mh.vector[pozMax].Id < mh.vector[pozDreapta].Id)
//        {
//            pozMax = pozDreapta;
//        }
//
//        if (pozMax != index) // daca cel mai mare dintre parinte si copii NU este parintele faci swap
//        {
//            Produs aux = mh.vector[index];
//            mh.vector[index] = mh.vector[pozMax];
//            mh.vector[pozMax] = aux;
//
//            // Apelezi recursiv pentru copilul cu care ai făcut swap
//            // pentru a te asigura că și subarborele lui respectă regula
//            if (pozMax <= mh.dimensiune / 2 - 1) // optimizare - doar nodurile care au copii trebuie verif
//            {
//                filtrareMaxHeap(mh, pozMax);
//            }
//        }
//    }
//}
//
//void extragereDinMaxHeap(MaxHeap* mh, Produs* p) // p = pointer la produs in care copiez elemntul cel mai mare
//{
//    *p = initProdus(mh->vector[0].Id, mh->vector[0].nume, mh->vector[0].pret);
//    mh->vector[0] = mh->vector[mh->dimensiune - 1];
//    mh->dimensiune--;
//    filtrareMaxHeap(*mh, 0);
//}
//
//
//void stergereDupaCriteriu(MaxHeap* mh, float pret)
//{
//    //newSize va ține numărul de produse care rămân după filtrare.
//    int newSize = 0;
//    for (int i = 0; i < mh->dimensiune; i++)
//    {
//        if (mh->vector[i].pret > pret)
//        {
//            //Se copiază produsul la începutul vectorului, la poziția newSize.
//            mh->vector[newSize++] = copiereProdus(mh->vector[i]);
//        }
//        else
//        {
//            //daca pretul nu e mai mare atunci se elibereaza memoria
//            //Se eliberează memoria pentru nume (presupunând că nume este alocat dinamic).
//            free(mh->vector[i].nume);
//        }
//    }
//    mh->dimensiune = newSize;
//
//    for (int i = mh->dimensiune / 2 - 1; i >= 0; i--)
//    {
//        filtrareMaxHeap(*mh, i);
//    }
//}
//
//Produs* vectorDupaCriteriu(MaxHeap mh, float prag, int* dim)
//{
//    Produs* vector = NULL;
//
//    for (int i = 0; i < mh.dimensiune; i++)
//    {
//        if (mh.vector[i].pret > prag)
//        {
//            vector = (Produs*)realloc(vector, sizeof(Produs) * ((*dim)+1));
//            vector[(*dim)++] = copiereProdus(mh.vector[i]);
//        }
//    }
//
//    for (int i = 0; i < *dim - 1; i++)
//    {
//        for (int j = i; j < *dim; j++)
//        {
//            if (vector[i].pret > vector[j].pret)
//            {
//                Produs temp = vector[i];
//                vector[i] = vector[j];
//                vector[j] = temp;
//            }
//        }
//    }
//
//    return vector;
//}
//
//void dezalocareHeap(MaxHeap* mHeap)
//{
//    for (int i = 0; i < mHeap->dimensiune; i++)
//    {
//        free(mHeap->vector[i].nume);
//    }
//    free(mHeap->vector);
//    mHeap->vector = NULL;
//    mHeap->dimensiune = 0;
//}
//
//int main()
//{
//    MaxHeap mh;
//    mh.dimensiune = 6;
//    mh.vector = (Produs*)malloc(sizeof(Produs) * mh.dimensiune);
//
//    mh.vector[0] = initProdus(100, "Casti", 250.99);
//    mh.vector[1] = initProdus(101, "Ceai", 10.99);
//    mh.vector[2] = initProdus(102, "Masina", 90050.99);
//    mh.vector[3] = initProdus(103, "Laptop", 1500.99);
//    mh.vector[4] = initProdus(104, "Papusa", 100.99);
//    mh.vector[5] = initProdus(105, "Pastile", 78.99);
//
//    // traversareMaxHeap(mh);
//
//    for (int i = mh.dimensiune / 2 - 1; i >= 0; i--)
//    {
//        filtrareMaxHeap(mh, i);
//    }
//
//    //printf("\nMAXHEAP VALID: \n");
//    // traversareMaxHeap(mh);
//
//     //Produs produs;
//     //while (mh.dimensiune != 0)
//     //{
//     //  extragereDinMaxHeap(&mh, &produs);
//     //  afisareProdus(produs);
//     //  free(produs.nume);
//     //}
//
//    // stergereDupaCriteriu(&mh, 200);
//    // traversareMaxHeap(mh);
//
//    int dim = 0;
//    Produs* vector = vectorDupaCriteriu(mh, 200, &dim);
//    for (int i = 0; i < dim; i++)
//    {
//        afisareProdus(vector[i]);
//    }
//
//    dezalocareHeap(&mh);
//}