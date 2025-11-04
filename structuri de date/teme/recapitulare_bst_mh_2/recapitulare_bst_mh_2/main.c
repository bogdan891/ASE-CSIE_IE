#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Carte Carte;
typedef struct Nod Nod;
typedef struct MaxHeap MaxHeap;

struct Carte {
	int id;
	char* titlu;
	char* autor;
	int anAparitie;
};

struct Nod {
	Carte info;
	Nod* st;
	Nod* dr;
};

struct MaxHeap {
	Carte* vector;
	int dim;
};

//Initializare carte
Carte initCarte(int id, const char* titlu, const char* autor, int anAparitie) {
	Carte c;

	c.id = id;

	if (titlu) {
		c.titlu = (char*)malloc(sizeof(char) * (strlen(titlu) + 1));
		strcpy(c.titlu, titlu);
	}
	else {
		c.titlu = NULL;
	}

	if (autor) {
		c.autor = (char*)malloc(sizeof(char) * (strlen(autor) + 1));
		strcpy(c.autor, autor);
	}
	else {
		c.autor = NULL;
	}

	c.anAparitie = anAparitie;
	return c;
}

//Copiere carte
Carte copyCarte(Carte c) {
	Carte copy = initCarte(c.id, c.titlu, c.autor, c.anAparitie);
	return copy;
}

//Dezalocare carte
void freeCarte(Carte* c) {
	if (c->autor)
		free(c->autor);
	if (c->titlu)
		free(c->titlu);
}

//Afisare carte
void afiseazaCarte(Carte c) {
	printf("========================================\n");
	printf("Id: %d\n", c.id);
	printf("Titlu: %s\n", c.titlu ? c.titlu : "N/A");
	printf("Autor: %s\n", c.autor ? c.autor : "N/A");
	printf("Anul aparitiei: %d\n", c.anAparitie);
	printf("========================================\n");
}


//Inserare in bst
void inserareInBST(Nod** radacina, Carte c) {
	if (!(*radacina)) {
		Nod* temp = (Nod*)malloc(sizeof(Nod));
		temp->info = copyCarte(c);
		temp->st = temp->dr = NULL;
		*radacina = temp;
	}
	else {
		if (c.id < (*radacina)->info.id) {
			inserareInBST(&(*radacina)->st, c);
		}
		else {
			inserareInBST(&(*radacina)->dr, c);
		}
	}
}

//Parcurgere inordine
void inordine(Nod* radacina) {
	if (!radacina)
		return;
	inordine(radacina->st);
	afiseazaCarte(radacina->info);
	inordine(radacina->dr);
}

//Parcurgere postordine
void postordine(Nod* radacina) {
	if (!radacina)
		return;
	postordine(radacina->st);
	postordine(radacina->dr);
	afiseazaCarte(radacina->info);
}

//Parcurgere preordine
void preordine(Nod* radacina) {
	if (!radacina)
		return;
	afiseazaCarte(radacina->info);
	preordine(radacina->st);
	preordine(radacina->dr);
}

//Cautare in bst
Carte cautareDupaId(Nod* radacina, int id) {
	if (!radacina) {
		(Carte) {
		0
	};
	}
	else if (radacina->info.id == id)
		return copyCarte(radacina->info);
	else if (id < radacina->info.id)
		cautareDupaId(radacina->st, id);
	else
		cautareDupaId(radacina->dr, id);
}

//Numar noduri
int nrNoduri(Nod* radacina) {
	if (!radacina)
		return 0;
	return 1 + nrNoduri(radacina->st) + nrNoduri(radacina->dr);
}

//Conversie BST -> vector
void conversieVector(Nod* radacina, Carte* vector, int* index) {
	if (radacina) {
		conversieVector(radacina->st, vector, index);
		vector[(*index)++] = radacina->info;
		conversieVector(radacina->dr, vector, index);
	}
}

//Filtrare
void filtrare(MaxHeap mh, int index) {
	if (mh.dim > 0) {
		int max = index;
		int st = 2 * index + 1;
		int dr = 2 * index + 2;

		if (st < mh.dim && mh.vector[max].id < mh.vector[st].id)
			max = st;
		if (dr < mh.dim && mh.vector[max].id < mh.vector[dr].id)
			max = dr;

		if (max != index) {
			Carte temp = mh.vector[max];
			mh.vector[max] = mh.vector[index];
			mh.vector[index] = temp;

			if (max <= index / 2 + 1)
				filtrare(mh, max);
		}
	}
}

//Conversie MaxHeap
MaxHeap conversieMaxHeap(Nod* radacina, int nrNoduri) {
	int nrCarti = 0;
	Carte* carti = (Carte*)malloc(sizeof(Carte) * nrNoduri);
	conversieVector(radacina, carti, &nrCarti);

	MaxHeap mh;
	mh.dim = nrCarti;
	mh.vector = (Carte*)malloc(sizeof(Carte) * mh.dim);
	for (int i = 0; i < nrCarti; i++) {
		mh.vector[i] = copyCarte(carti[i]);
	}

	for (int i = 0; i < nrCarti; i++)
		filtrare(mh, i);

	return mh;
}

//Parcurgere MaxHeap
void parcurgereMaxHeap(MaxHeap mh) {
	if (mh.vector)
		for (int i = 0; i < mh.dim; i++)
			afiseazaCarte(mh.vector[i]);
}

//Stergere MaxHeap dupa titlu
Carte extragereCarteMaxHeap(MaxHeap* mh, const char* titlu) {
	for (int i = 0; i < mh->dim; i++) {
		if (strcmp(mh->vector[i].titlu, titlu) == 0) {
			Carte extras;
			extras = copyCarte(mh->vector[i]);
			freeCarte(&(mh->vector[i]));
			mh->vector[i] = copyCarte(mh->vector[mh->dim - 1]);
			freeCarte(&(mh->vector[mh->dim - 1]));
			mh->dim--;
			filtrare(*mh, i);
			return extras;
		}
	}

	return (Carte) { 0 };
}

//Numarare carti in MaxHeap aparute dupa un anumit an
int nrCarti(MaxHeap mh, int an) {
	int contor = 0;
	for (int i = 0; i < mh.dim; i++) {
		if (mh.vector[i].anAparitie >= an)
			contor++;
	}
	return contor;
}

//Returnare vector de carti aparute dupa un anumit an
void returnVector(MaxHeap mh, Carte* vector, int an) {
	int index = 0;
	for (int i = 0; i < mh.dim; i++)
	{
		if (mh.vector[i].anAparitie >= an) {
			vector[index++] = copyCarte(mh.vector[i]);
		}
	}
}

//Dezalocare BST
void freeBST(Nod** radacina) {
	if (*radacina) {
		freeBST(&(*radacina)->st);
		freeBST(&(*radacina)->dr);

		freeCarte(&(*radacina)->info);

		free(*radacina);
		*radacina = NULL;
	}
}

//Dezalocare MaxHeap
void freeMaxHeap(MaxHeap* mh) {
	if (mh->vector) {
		for (int i = 0; i < mh->dim; i++) {
			freeCarte(&(mh->vector[i]));
		}
		free(mh->vector);
		mh->vector = NULL;
		mh->dim = 0;
	}
}

int main() {

	//Initializare carti
	Carte c1 = initCarte(105, "Povestea lui Harap-Alb", "Ion Creanga", 1881);
	Carte c2 = initCarte(102, "Harry Potter si Ordinul Phoenix", "J.K. Rowling", 2000);
	Carte c3 = initCarte(108, "Harry Potter si Camera Secretelor", "J.K. Rowling", 1999);
	Carte c4 = initCarte(104, "WarCross", "Marie Lu", 2017);
	Carte c5 = initCarte(109, "Jocurile Foamei", "Suzanne Collins", 2011);

	//Initializare BST
	Nod* radacina = NULL;
	inserareInBST(&radacina, c1);
	inserareInBST(&radacina, c2);
	inserareInBST(&radacina, c3);
	inserareInBST(&radacina, c4);
	inserareInBST(&radacina, c5);

	/*printf("Traversare BST:\n");
	preordine(radacina);*/

	//Initializare MaxHeap
	MaxHeap mh = conversieMaxHeap(radacina, nrNoduri(radacina));

	//Afisare intiala MaxHeap
	/*printf("Parcurgere MaxHeap:\n");
	parcurgereMaxHeap(mh);*/

	//Exatragere carte
	/*Carte extras = extragereCarteMaxHeap(&mh, "WarCross");
	printf("Cartea extrasa:\n");
	afiseazaCarte(extras);
	printf("\nParcurgere MaxHeap:\n");
	parcurgereMaxHeap(mh);*/

	//Returnare vector de carti
	int nrC = nrCarti(mh, 2007);
	Carte* carti = (Carte*)malloc(sizeof(Carte) * nrC);
	returnVector(mh, carti, 2007);
	printf("Cartile aparute dupa anul 2007:\n");
	for (int i = 0; i < nrC; i++) {
		afiseazaCarte(carti[i]);
	}

	freeBST(&radacina);
	freeMaxHeap(&mh);

	return 0;
}