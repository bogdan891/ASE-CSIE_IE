#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>
#include <stdbool.h>

typedef struct Train Train;
typedef struct Nod Nod;
typedef struct MaxHeap MaxHeap;

struct Train {
	char* type;
	int nb;
	char* route;
	bool isElectric;
	float maxSpeed;
	int nbOfCoaches;
	int* capacityPerCoach;
};

struct Nod {
	Train info;
	Nod* copilSt;
	Nod* copilDr;
};

struct MaxHeap {
	Train* vector;
	int size;
};

//Initializare element Train
Train initTrain(const char* type, int nb, const char* route, bool isElectric, 
	float maxSpeed, int nbOfCoaches, int* capacityPerCoach) {
	Train t;

	if (type != NULL) {
		t.type = (char*)malloc(sizeof(char) * (strlen(type) + 1));
		strcpy(t.type, type);
	}
	else {
		t.type = NULL;
	}

	t.nb = nb;

	if (route != NULL) {
		t.route = (char*)malloc(sizeof(char) * (strlen(route) + 1));
		strcpy(t.route, route);
	}
	else {
		t.route = NULL;
	}

	t.isElectric = isElectric;

	t.maxSpeed = maxSpeed;

	t.nbOfCoaches = nbOfCoaches;

	if (nbOfCoaches > 0 && capacityPerCoach != NULL) {
		t.capacityPerCoach = (int*)malloc(sizeof(int) * nbOfCoaches);
		for (int i = 0; i < nbOfCoaches; i++) {
			t.capacityPerCoach[i] = capacityPerCoach[i];
		}
	}
	else {
		t.capacityPerCoach = NULL;
	}

	return t;
}

//Afisare element de tip Train
void showTrain(Train t) {
	printf("Train : %s%d\n", t.type ? t.type : "", t.nb);
	printf("Route: %s\n", t.route ? t.route : "-");
	printf("Electric engine? %s\n", t.isElectric ? "yes" : "no");
	printf("Max speed: %.2f\n", t.maxSpeed);
	printf("Number of Coaches: %d\n", t.nbOfCoaches);
	printf("Capacity of the train per coach: ");
	if (t.capacityPerCoach != NULL) {
		for (int i = 0; i < t.nbOfCoaches; i++) {
			printf("#%d - %d; ", i + 1, t.capacityPerCoach[i]);
		}
	}
	else {
		printf("-");
	}
}

//Afisare elemente Maxheap
void showMaxHeap(MaxHeap mh) {
	if (mh.vector == NULL)
		return;
	for (int i = 0; i < mh.size; i++) {
		showTrain(mh.vector[i]);
		printf("\n------------------------------------------------------------------------------\n");
	}
}

//Afisare elemente BST
void showInOrderBST(Nod* root) {
	if (root == NULL) {
		return;
	}

	showInOrderBST(root->copilSt);
	showTrain(root->info);
	printf("\n------------------------------------------------------------------------------\n");
	showInOrderBST(root->copilDr);
}

//Citire element Train
Train readTrainFromFile(FILE* fileStream) {
	if (fileStream == NULL) {
		return (Train) { 0 };
	}

	Train t;
	char buffer[100];

	//Citire type
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Train) { 0 };
	}
	char* temp = strtok(buffer, "\n");
	if (temp == NULL) {
		t.type = NULL;
	}
	else {
		t.type = (char*)malloc(sizeof(char) * (strlen(temp) + 1));
		strcpy(t.type, temp);
	}

	//Citire nb
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Train) { 0 };
	}
	t.nb = atoi(buffer);

	//Citire route
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Train) { 0 };
	}
	temp = strtok(buffer, "\n");
	if (temp == NULL) {
		t.route = NULL;
	}
	else {
		t.route = (char*)malloc(sizeof(char) * (strlen(temp) + 1));
		strcpy(t.route, temp);
	}

	//Citire isElectric
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Train) { 0 };
	}
	temp = strtok(buffer, "\n");
	if (temp != NULL && strcmp(temp, "Yes") == 0) {
		t.isElectric = true;
	}
	else {
		t.isElectric = false;
	}

	//Citire maxSpeed
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Train) { 0 };
	}
	t.maxSpeed = atof(buffer);

	//Citire nbOfCoaches
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Train) { 0 };
	}
	t.nbOfCoaches = atoi(buffer);

	//Citire capacityPerCoach
	if (t.nbOfCoaches > 0) {
		t.capacityPerCoach = (int*)malloc(sizeof(int) * t.nbOfCoaches);
		for (int i = 0; i < t.nbOfCoaches; i++) {
			if (!fgets(buffer, sizeof(buffer), fileStream)) {
				return (Train) { 0 };
			}
			t.capacityPerCoach[i] = atoi(buffer);
		}
	}
	else {
		t.capacityPerCoach = NULL;
	}

	return t;
}

//Inserare in BST
void insertIntoBST(Nod** root, Train t) {
	if (*root == NULL) {
		Nod* temp = (Nod*)malloc(sizeof(Nod));
		temp->info = initTrain(t.type, t.nb, t.route, t.isElectric, t.maxSpeed, 
			t.nbOfCoaches, t.capacityPerCoach);
		temp->copilSt = NULL;
		temp->copilDr = NULL;
		*root = temp;
	}
	else {
		if (t.nb > (*root)->info.nb) {
			insertIntoBST(&(*root)->copilDr, t);
		}
		else {
			insertIntoBST(&(*root)->copilSt, t);
		}
	}
}

//Citire arbore binar
void readBST(Nod** root) {
	FILE* fileStream = fopen("trains.txt", "r");
	if (fileStream == NULL) {
		printf("The file cannot be opened!\n");
		return;
	}

	while (1) {
		Train t = readTrainFromFile(fileStream);
		if (t.type == NULL) break;
		insertIntoBST(root, t);
		freeTrain(t);
	}

	fclose(fileStream);
}

//Contorizare noduri frunze in fucntie de id
int countLeavesByNb(Nod* root, int value) {
	if (root == NULL)
		return 0;

	if (root->copilDr == NULL && root->copilSt == NULL) {
		return root->info.nb > value ? 1 : 0;
	}

	return countLeavesByNb(root->copilSt, value) + countLeavesByNb(root->copilDr, value);
}

//Calcul nr elemente din BST
int countNodes(Nod* root) {
	if (root == NULL) return 0;
	return 1 + countNodes(root->copilSt) + countNodes(root->copilDr);
}

//Colectarea elementelor intr-un vector
void collectTrains(Nod* root, Train** trains, int* index) {
	if (root == NULL) return;
	collectTrains(root->copilSt, trains, index);
	(*trains)[(*index)++] = initTrain(root->info.type, root->info.nb, root->info.route, root->info.isElectric, 
		root->info.maxSpeed, root->info.nbOfCoaches, root->info.capacityPerCoach);
	collectTrains(root->copilDr, trains, index);
}

//Conversie de la BST la MaxHeap
void toHeap(Train** trains, int n, int i) {
	int largest = i;
	int left = 2 * i + 1;
	int right = 2 * i + 2;

	if (left < n && (*trains)[left].nb >(*trains)[largest].nb) {
		largest = left;
	}

	if (right < n && (*trains)[right].nb >(*trains)[largest].nb) {
		largest = right;
	}

	if (largest != i) {
		Train temp = (*trains)[i];
		(*trains)[i] = (*trains)[largest];
		(*trains)[largest] = temp;
		toHeap(trains, n, largest);
	}
}

void buildMaxHeap(Train** trains, int n) {
	for (int i = n / 2 - 1; i >= 0; i--) {
		toHeap(trains, n, i);
	}
}

void toMaxHeap(Nod* root, MaxHeap* mh) {
	int nodeCount = countNodes(root);
	mh->vector = (Train*)malloc(nodeCount * sizeof(Train));

	Train* temp = (Train*)malloc(sizeof(Train) * nodeCount);
	int index = 0;

	collectTrains(root, &temp, &index);
	buildMaxHeap(&temp, nodeCount);

	mh->size = nodeCount;
	for (int i = 0; i < mh->size; i++) {
		mh->vector[i] = initTrain(temp[i].type, temp[i].nb, temp[i].route,
			temp[i].isElectric, temp[i].maxSpeed, temp[i].nbOfCoaches, temp[i].capacityPerCoach);
	}

	free(temp);
}

//Filtrare
void filter(MaxHeap* mh, int threshold) {
	Train* vector = (Train*)malloc(sizeof(Train) * mh->size);
	int count = 0;

	for (int i = 0; i < mh->size; i++) {
		if (mh->vector[i].nb > threshold) {
			vector[count++] = mh->vector[i];
		}
		else {
			if (mh->vector[i].type != NULL) free(mh->vector[i].type);
			if (mh->vector[i].route != NULL) free(mh->vector[i].route);
			if (mh->vector[i].capacityPerCoach != NULL) free(mh->vector[i].capacityPerCoach);
		}
	}

	free(mh->vector);
	mh->vector = vector;
	mh->size = count;

	buildMaxHeap(mh->vector, mh->size);
}

//Interschimbare
void swapTrains(Train** a, Train** b) {
	Train* temp = *a;
	*a = *b;
	*b = temp;
}

//Partitionare pt quickSort
int partition(Train* array, int min, int max) {
	int pivot = array[max].nb;
	int i = min - 1;

	for (int j = min; j <= max - 1; j++) {
		if (array[j].nb <= pivot) {
			i++;
			swapTrains(&array[i], &array[j]);
		}
	}
	swapTrains(&array[i + 1], &array[max]);
	return (i + 1);
}

//QuickSort
void quickSort(Train** array, int min, int max) {
	if (min < max) {
		int pi = partition(array, min, max);
		quickSort(&array, min, pi - 1);
		quickSort(&array, pi + 1, max);
	}
}

//Contorizar elemente
int countiInArray(MaxHeap mh, float maxSpeed) {
	int count = 0;
	for (int i = 0; i < mh.size; i++) {
		if (mh.vector[i].maxSpeed == maxSpeed) {
			count++;
		}
	}
	return count;
}

//Returnare vector
Train* maxHeapToArray(MaxHeap mh, float maxSpeed, int count) {

	if (count == 0) {
		return NULL;
	}

	Train* result = (Train*)malloc(sizeof(Train) * count);
	int index = 0;
	for (int i = 0; i < mh.size; i++) {
		if (mh.vector[i].maxSpeed == maxSpeed) {
			result[index] = initTrain(mh.vector[i].type, mh.vector[i].nb, mh.vector[i].route,
				mh.vector[i].isElectric, mh.vector[i].maxSpeed, mh.vector[i].nbOfCoaches,
				mh.vector[i].capacityPerCoach);
			index++;
		}
	}

	quickSort(&result, 0, count - 1);

	return result;
}

//Stergere elemente
void deleteFromMaxHeap(MaxHeap* mh) {
	int newSize = 0;
	for (int i = 0; i < mh->size; i++) {
		if (mh->vector[i].nb % 2 != 0) {
			mh->vector[newSize] = mh->vector[i];
			newSize++;
		}
		else {
			if (mh->vector[i].type != NULL) free(mh->vector[i].type);
			if (mh->vector[i].route != NULL) free(mh->vector[i].route);
			if (mh->vector[i].capacityPerCoach != NULL) 
				free(mh->vector[i].capacityPerCoach);
		}
	}
	mh->size = newSize;
	buildMaxHeap(mh->vector, mh->size);
}

//Dezalocari pentru structuri
void freeTrain(Train t) {
	if (t.type != NULL) {
		free(t.type);
	}
	if (t.route != NULL) {
		free(t.route);
	}
	if (t.capacityPerCoach != NULL) {
		free(t.capacityPerCoach);
	}
}

void freeBST(Nod* root){
	if (root == NULL) return;
	freeBST(root->copilSt);
	freeBST(root->copilDr);
	freeTrain(root->info);
	free(root);
}

void freeMaxHeap(MaxHeap* mh) {
	for (int i = 0; i < mh->size; i++) {
		freeTrain(mh->vector[i]);
	}
	free(mh->vector);
	mh->size = 0;
}

void freeTrainArray(Train* array, int size) {
	for (int i = 0; i < size; i++) {
		freeTrain(array[i]);
	}
	free(array);
}

void main() {
	Nod* root = NULL;
	/*2 Citirea din fisier*/
	readBST(&root);

	//Afisarea elementelor BST:
	printf("===================== The trains from the BTS (inorder) =======================\n");
	showInOrderBST(root);

	/*3 Calculul numarului de noduri frunze*/
	printf("\n\nThe number of leaves with nb under %d is %d.\n\n", 1000, countLeavesByNb(root, 1000));

	/*4 Adaugare elemente din BST in MaxHeap*/ 
	MaxHeap maxHeap;
	toMaxHeap(root, &maxHeap);
	printf("\n=============================== MaxHeap (nb) ==================================\n");
	showMaxHeap(maxHeap);

	/*5 Filatrare MaxHeap*/ 
	filter(&maxHeap, 1000);
	printf("\n=============================== Filtered MaxHeap ===============================\n");
	showMaxHeap(maxHeap);

	/*6 Conversie de la MaxHeap la vector*/
	float maxSpeed = 100.00;
	int size = countiInArray(maxHeap, maxSpeed);
	Train* trainArray = maxHeapToArray(maxHeap, maxSpeed, size);
	printf("\n================================== Train Array ==================================\n");
	for (int i = 0; i < size; i++) {
		showTrain(trainArray[i]);
		printf("\n------------------------------------------------------------------------------\n");
	}

	/*8 Stergere elemente din MaxHeap*/
	printf("\n=============================== MaxHeap after eliminations ===============================\n");
	deleteFromMaxHeap(&maxHeap);
	showMaxHeap(maxHeap);

	/*Eliberare memorie*/
	freeBST(root);
	freeMaxHeap(&maxHeap);
	if (trainArray != NULL) {
		freeTrainArray(trainArray, size);
	}

	//Nota: 8
}