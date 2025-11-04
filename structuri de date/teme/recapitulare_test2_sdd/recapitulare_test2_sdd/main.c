#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>
#include <stdbool.h>

typedef struct Train Train;
typedef struct Node Node;
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

struct Node {
	Train info;
	Node* left;
	Node* right;
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
	printf("============================================================================\n");
	printf("Train: %s %d\n", t.type ? t.type : "", t.nb);
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
	printf("\n============================================================================\n");
}

void insertInBST(Node** root, Train t) {
	if (*root == NULL) {
		Node* temp = (Node*)malloc(sizeof(Node));
		temp->info = initTrain(t.type, t.nb, t.route, t.isElectric, t.maxSpeed, t.nbOfCoaches, t.capacityPerCoach);
		temp->left = NULL;
		temp->right = NULL;
		*root = temp;
	}
	else {
		if ((*root)->info.nb < t.nb) {
			insertInBST(&(*root)->right, t);
		}
		else {
			insertInBST(&(*root)->left, t);
		}
	}
}

//Parcurgeri BST
void inorder(Node* root) {
	if (root == NULL) {
		return;
	}

	inorder(root->left);
	showTrain(root->info);
	inorder(root->right);
}

void postorder(Node* root) {
	if (root == NULL) {
		return;
	}

	postorder(root->left);
	postorder(root->right);
	showTrain(root->info);
}

//Returnare frunza
Train returnTrainByNb(Node* root, int nb) {
	if (root == NULL) {
		return (Train) { 0 };
	}
	else if (root->info.nb == nb) {
		return root->info = initTrain(root->info.type, root->info.nb, root->info.route, root->info.isElectric,
			root->info.maxSpeed, root->info.nbOfCoaches, root->info.capacityPerCoach);

	}
	else if (nb < root->info.nb) {
		returnTrainByNb(root->left, nb);
	}
	else {
		returnTrainByNb(root->right, nb);
	}
}
//Dezalocare memorie
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

void freeBST(Node* root) {
	if (root == NULL) return;
	freeBST(root->left);
	freeBST(root->right);
	freeTrain(root->info);
	free(root);
}

void freeMaxHeap(MaxHeap mh) {
	if (mh.vector == NULL) {
		return;
	}
	for (int i = 0; i < mh.size; i++) {
		freeTrain(mh.vector[i]);
	}
	free(mh.vector);
}

//Conversie BST -> Vector
void BSTToVector(Node* root, Train* vector, int* size) {
	if (root != NULL) {
		BSTToVector(root->left, vector, size);
		vector[(*size)++] = root->info;
		BSTToVector(root->right, vector, size);
	}
}

//Nr de noduri din BST
int countNodes(Node* root) {
	if (root == NULL) {
		return 0;
	}

	return 1 + countNodes(root->left) + countNodes(root->right);
}


//Filtrare MaxHeap
void filter(MaxHeap mh, int index) {
	if (mh.size > 0) {
		int max = index;
		int left = 2 * index + 1;
		int right = 2 * index + 2;

		if (left < mh.size && mh.vector[max].nb < mh.vector[left].nb) {
			max = left;
		}

		if (right < mh.size && mh.vector[max].nb < mh.vector[right].nb) {
			max = right;
		}

		if (max != index) {
			Train aux = mh.vector[max];
			mh.vector[max] = mh.vector[index];
			mh.vector[index] = aux;

			if (max <= mh.size / 2 - 1) {
				filter(mh, max);
			}
		}
	}
}

//Converise vector -> MaxHeap
MaxHeap toMaxHeap(Node* root, int nbOfNodes) {
	int size = 0;
	Train* vector = (Train*)malloc(sizeof(Train) * nbOfNodes);
	BSTToVector(root, vector, &size);
	MaxHeap mh = { vector, size };
	for (int i = mh.size; i < mh.size / 2 - 1; i--) {
		filter(mh, i);
	}
	return mh;
}

//Parcurgere / Traversare MaxHeap
void showMaxHeap(MaxHeap mh) {
	if (mh.size <= 0 && mh.vector == NULL) {
		printf("The maxheap is empty!\n");
		return;
	}

	for (int i = 0; i < mh.size; i++) {
		showTrain(mh.vector[i]);
	}
}

//Cautare element in MaxHeap
Train returnTrainFromMaxHeap(MaxHeap mh, const char* type) {
	for (int i = 0; i < mh.size; i++) {
		if (strcmp(mh.vector[i].type, type) == 0) {
			return mh.vector[i];
		}
	}
	return(Train) { 0 };
}

//Copiere element Train
Train copyTrain(Train t) {
	Train copy = initTrain(t.type, t.nb, t.route, t.isElectric, t.maxSpeed, t.nbOfCoaches, t.capacityPerCoach);
	return copy;
 }
//extragere nod din MaxHeap
Train extractFromMaxHeap(MaxHeap* mh, int nb) {
	if (mh->vector != NULL && mh->size > 0) {
		for (int i = 0; i < mh->size; i++) {
			if (mh->vector[i].nb == nb) {
				Train aux = copyTrain(mh->vector[i]);
				mh->vector[i] = mh->vector[mh->size - 1];
				mh->vector = (Train*)realloc(mh->vector, mh->size * sizeof(Train));
				return aux;
			}
		}
	}
	return (Train) { 0 };
}

int main() {
	//Initializare elemente Train
	int cap1[6] = { 80, 80, 80, 80, 80, 80 };
	Train t1 = initTrain("Regio", 1571, "Bucuresti Nord - Galati", 0, 120.0f, 6, cap1);

	int cap2[8] = { 60, 60, 60, 60, 60, 60, 60, 60 };
	Train t2 = initTrain("Interregio", 1742, "Cluj Napoca - Bucuresti Nord", 1, 160.0f, 8, cap2);

	int cap3[4] = { 70, 70, 70, 70 };
	Train t3 = initTrain("Regio", 3005, "Brasov - Sfantu Gheorghe", 0, 100.0f, 4, cap3);

	int cap4[10] = { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
	Train t4 = initTrain("Intercity", 1234, "Constanta - Bucuresti Nord", 1, 200.0f, 10, cap4);

	int cap5[5] = { 75, 75, 75, 75, 75 };
	Train t5 = initTrain("Regio", 4110, "Iasi - Pascani", 0, 110.0f, 5, cap5);

	int cap6[6] = { 65, 65, 65, 65, 65, 65 };
	Train t6 = initTrain("Interregio", 1823, "Sibiu - Brasov", 1, 140.0f, 6, cap6);


	//Inserarile in BST
	Node* root = NULL;
	insertInBST(&root, t1);
	insertInBST(&root, t2);
	insertInBST(&root, t3);
	insertInBST(&root, t4);
	insertInBST(&root, t5);
	insertInBST(&root, t6);

	//Afisari
	/*printf("\nInorder exploration: \n");
	inorder(root);
	printf("\n\nPostorder exploration: \n");
	postorder(root);

	printf("\nThe details of train 1234:\n");
	showTrain(returnTrainByNb(root, 1234));*/

	//printf("%d", countNodes(root));

	MaxHeap mh = toMaxHeap(root, countNodes(root));
	Train extracted = extractFromMaxHeap(&mh, 1234);
	showTrain(extracted);
	printf("The elements of vector of MaxHeap: \n");
	showMaxHeap(mh);

	freeBST(root);
	//freeMaxHeap(mh);

}