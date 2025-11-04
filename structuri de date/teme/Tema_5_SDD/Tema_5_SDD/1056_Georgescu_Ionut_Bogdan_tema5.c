#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>
#include <stdbool.h>

typedef struct Phone Phone;
typedef struct Node Node;
typedef struct DoubleList DoubleList;
typedef struct MainNode MainNode;
typedef struct SecondaryNode SecondaryNode;
typedef struct AVL AVL;

struct Phone {
	int id;
	char* model;
	char* manufacturer;
	int bateryCapacity;
	int releaseYear;
	float price;
	bool waterproof;
	int* ratings;
};

struct Node {
	int ID;
	Node* next;
	Node* prev;
};

struct DoubleList {
	Node* first;
	Node* last;
};

struct MainNode {
	Phone info;
	MainNode* next;
	MainNode* neighbors;
};

struct SecondaryNode {
	MainNode* info;
	SecondaryNode* next;
};

struct AVL {
	Phone info;
	AVL* left;
	AVL* right;
	int height;
};

//Initializare element PHONE
Phone initPhone(int id, const char* model, const char* manufacturer, int bateryCapacity, int releaseYear,
	float price, bool waterproof, int* ratings) {
	Phone p;

	p.id = id;

	if (model != NULL) {
		p.model = (char*)malloc(sizeof(char) * (strlen(model) + 1));
		strcpy(p.model, model);
	}
	else {
		p.model = NULL;
	}

	if (manufacturer != NULL) {
		p.manufacturer = (char*)malloc(sizeof(char) * (strlen(manufacturer) + 1));
		strcpy(p.manufacturer, manufacturer);
	}
	else {
		p.manufacturer = NULL;
	}

	p.bateryCapacity = bateryCapacity;

	p.releaseYear = releaseYear;

	p.price = price;

	p.waterproof = waterproof;

	if (ratings != NULL) {
		p.ratings = (int*)malloc(5 * sizeof(int));
		for (int i = 0; i < 4; i++) {
			p.ratings[i] = ratings[i];
		}
	}
	else {
		p.ratings = NULL;
	}

	return p;
}

//Afisare element PHONE
void printPhone(Phone p) {
	printf("===========================================================\n");
	printf("ID: %d\n", p.id);
	printf("Model: %s\n", p.model ? p.model : "N/D");
	printf("Manufacturer: %s\n", p.model ? p.model : "N/D");
	printf("Batery capacity: %dmAh\n", p.bateryCapacity);
	printf("Release year: %d\n", p.releaseYear);
	printf("Price: %.2f\n", p.price);
	if (p.waterproof == true) printf("Waterproof? Yes/n");
	else printf("Waterproof? No/n");
	printf("Ratings: ");
	if (p.ratings != NULL) for (int i = 0; i < 4; i++) printf("%d* - %d", i + 1, p.ratings[i]);
	else printf("N/A");
	printf("\n");
	printf("===========================================================\n");
}

//Citire element PHONE
Phone readPhone(FILE* fileStream) {
	Phone p;
	char buffer[50];
	char* temp;

	//ID
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Phone) { 0 };
	}
	p.id = atoi(buffer);

	//Model
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Phone) { 0 };
	}
	temp = strtok(buffer, "\n");
	p.model = (char*)malloc(sizeof(char) * (strlen(temp) + 1));
	strcpy(p.model, temp);

	//Manufacturer
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Phone) { 0 };
	}
	temp = strtok(buffer, "\n");
	p.manufacturer = (char*)malloc(sizeof(char) * (strlen(temp) + 1));
	strcpy(p.manufacturer, temp);

	//Batery Capacity
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Phone) { 0 };
	}
	p.bateryCapacity = atoi(buffer);

	//Release Year
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Phone) { 0 };
	}
	p.releaseYear = atoi(buffer);

	//Price
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Phone) { 0 };
	}
	p.price = atof(buffer);

	//Waterproof
	if (!fgets(buffer, sizeof(buffer), fileStream)) {
		return (Phone) { 0 };
	}
	temp = strtok(buffer, "\n");
	if (strcmp(temp, "Yes") == 0) {
		p.waterproof = true;
	}
	else {
		p.waterproof = false;
	}

	//Ratings
	p.ratings = (int*)malloc(5 * sizeof(int));
	for (int i = 0; i < 4; i++) {
		if (!fgets(buffer, sizeof(buffer), fileStream)) {
			return (Phone) { 0 };
		}
		p.ratings[i] = atoi(buffer);
	}

	return p;
}

void insertInMainList(MainNode** head, Phone p) {
	MainNode* newNode = (MainNode*)malloc(sizeof(MainNode));
	newNode->info = initPhone(p.id, p.model, p.manufacturer, p.bateryCapacity, p.releaseYear, p.price, p.waterproof, p.ratings);
	newNode->next = NULL;
	newNode->neighbors = NULL;

	if (*head == NULL) *head = newNode;
	else {
		MainNode* aux = *head;
		while (aux->next != NULL) aux = aux->next;
		aux->next = newNode;
	}
}

void insertInSecondaryList(SecondaryNode** head, MainNode* info) {
	SecondaryNode* newNode = (SecondaryNode*)malloc(sizeof(SecondaryNode));
	newNode->info = info;
	newNode->next = NULL;
	if (*head)
	{
		SecondaryNode* aux = *head;
		while (aux->next)
		{
			aux = aux->next;
		}
		aux->next = newNode;
	}
	else
	{
		*head = newNode;
	}
}

MainNode* returnNodeById(MainNode* head, int ID) {
	while (head != NULL && ID != head->info.id) head = head->next;
	return head;
}

void addEdge(MainNode* head, int id1, int id2) {
	MainNode* node1 = returnNodeById(head, id1);
	MainNode* node2 = returnNodeById(head, id2);
	if (node1 != NULL && node2 != NULL) {
		insertInSecondaryList(&node1->neighbors, node2);
		insertInSecondaryList(&node2->neighbors, node1);
	}
}

//Citire arbore de PHONE
MainNode* readPhoneTree() {
	FILE* fileStream = fopen("phones.txt", "r");
	MainNode* tree = NULL;
	if (fileStream == NULL) {
		printf("Error! The file cannot be opened!\n");
		return;
	}
	while (!feof(fileStream)) {
		Phone p = readPhone(fileStream);
		insertInMainList(&tree, p);

		free(p.model);
		free(p.manufacturer);
		free(p.ratings);
	}

	fclose(fileStream);
	return tree;
}

void showGraph(MainNode* graph) {
	while (graph != NULL) {
		printPhone(graph->info);
		SecondaryNode* neighbors = graph->neighbors;
		printf("Neighbors:\n");
		while (neighbors != NULL) {
			printPhone(neighbors->info->info);
			neighbors = neighbors->next;
		}
		printf("\n");
		graph = graph->next;
	}
}

//Calcul capacitatea medie a bateriei
float avgBateryVapacity(MainNode* head) {
	int sum = 0, count = 0;
	while (head != NULL) {
		sum += head->info.bateryCapacity;
		count++;
		head = head->next;
	}

	return (float)sum / count;
}


//Conversie Graf -> AVL
void rightRotate(AVL** roof) {
	AVL* aux = (*roof)->left;
	(*roof)->left = aux->right;
	aux->right = *roof;
	*roof = aux;
}

void leftRotate(AVL** roof) {
	AVL* aux = (*roof)->right;
	(*roof)->right = aux->left;
	aux->left = *roof;
	*roof = aux;
}

int calculateHeightDiff(AVL* root) {
	if (root != NULL) {
		return calculateHeightDiff(root->left) - calculateHeightDiff(root->right);
	}
	return 0;
}

void push(DoubleList* list, int ID) {
	Node* newNode = (Node*)malloc(sizeof(Node));
	newNode->next = list->first;
	newNode->prev = NULL;
	newNode->ID = ID;

	if (list->first == NULL) {
		list->first = list->last = newNode;
	}
	else {
		list->first->prev = newNode;
		list->first = newNode;
	}
}

void put(DoubleList* list, int ID) {
	Node* newNode = (Node*)malloc(sizeof(Node));
	newNode->next = NULL;
	newNode->prev = list->last;
	newNode->ID = ID;

	if (list->last == NULL) {
		list->first = list->last = newNode;
	}
	else {
		list->last->next = newNode;
		list->last = newNode;
	}
}

int pop(DoubleList* list) {
	int ID = -1;
	if (list->first) {
		ID = list->first->ID;
		Node* aux = list->first;
		list->first = list->first->next;
		if (list->first == NULL) {
			list->last = NULL;
		}
		free(aux);
	}
	return ID;
}

void insertAVL(AVL** roof, Phone p) {
	if (*roof == NULL) {
		AVL* nou = (AVL*)malloc(sizeof(AVL));
		nou->info = initPhone(p.id, p.model, p.manufacturer, p.bateryCapacity, p.releaseYear, p.price, p.waterproof, p.ratings);
		nou->left = NULL;
		nou->right = NULL;
		*roof = nou;
	}
	else if (p.id < (*roof)->info.id) {
		insertAVL(&(*roof)->left, p);
	}
	else {
		insertAVL(&(*roof)->right, p);
	}

	int dif = calculateHeightDiff(*roof);

	if (dif == 2) {
		if (calculateHeightDiff((*roof)->left) == -1) {
			leftRotate(&(*roof)->left);
		}
		rightRotate(roof);
	}
	if (dif == -2) {
		if (calculateHeightDiff((*roof)->right) == 1) {
			rightRotate(&(*roof)->right);
		}
		leftRotate(roof);
	}
}

AVL* convertGraphToAVL(MainNode* head) {
	AVL* root = NULL;
	while (head != NULL) {
		insertAVL(&root, head->info);
		head = head->next;
	}
	return root;
}

void inorder(AVL* root) {
	if (root) {
		inorder(root->left);
		printPhone(root->info);
		inorder(root->right);
	}
}

float sumByCriterias(AVL* root, int minBatery, bool waterproof) {
	if (root == NULL) return 0.2f;

	float sum = 0.2f;
	if (root->info.bateryCapacity >= minBatery && root->info.waterproof == waterproof) {
		sum += root->info.price;
	}
	sum += sumByCriterias(root->left, minBatery, waterproof);
	sum += sumByCriterias(root->right, minBatery, waterproof);

	return sum;
}

//parcurgere adancime
void depth(MainNode* graph, int idStart) {
	int size = 6;
	int* vector = (int*)malloc(size * sizeof(int));
	for (int i = 0; i < size; i++) {
		vector[i] = 0;
	}
	DoubleList stack;
	stack.first = stack.last = NULL;
	push(&stack, idStart);
	vector[idStart - 1] = 1;
	while (stack.first) {
		int idExtras = pop(&stack);
		MainNode* extractedNode = returnNodeById(graph, idExtras);
		printPhone(extractedNode->info);
		SecondaryNode* neighbors = extractedNode->neighbors;
		while (neighbors) {
			if (vector[neighbors->info->info.id - 1] == 0) {
				push(&stack, neighbors->info->info.id);
				vector[neighbors->info->info.id - 1] = 1;

			}
			neighbors = neighbors->next;
		}
	}

	free(vector);
}

void freePhone(Phone* p) {
	if (p->model) free(p->model);
	if (p->manufacturer) free(p->manufacturer);
	if (p->ratings) free(p->ratings);
}

void freeMainList(MainNode* head) {
	while (head) {
		MainNode* temp = head;
		freePhone(&temp->info);
		head = head->next;
		SecondaryNode* sec = temp->neighbors;
		while (sec) {
			SecondaryNode* secTemp = sec;
			sec = sec->next;
			free(secTemp);
		}
		free(temp);
	}
}

void freeAVL(AVL* root) {
	if (root) {
		freeAVL(root->left);
		freeAVL(root->right);
		freePhone(&root->info);
		free(root);
	}
}

int main() {
	MainNode* phoneList = readPhoneTree();
	printf("The elements of Graph: \n");
	showGraph(phoneList);
	printf("The average capacity of bateries is: %.2f\n.", avgBateryVapacity(phoneList));
	AVL* root = convertGraphToAVL(phoneList);
	printf("The elements of AVL: \n");
	inorder(root);
	printf("The total price of non-waterproof phone with a min. of 3500mAh batery capacity is %.2f\n", 
		sumByCriterias(root, 3500, false));
	printf("Depth exploration:\n");
	depth(phoneList, 1);

	freeMainList(phoneList);
	freeAVL(root);

	return 0;
}