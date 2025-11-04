#define _CRT_SECURE_NO_WARNINGS
#include<malloc.h>
#include<stdio.h>
#include<string.h>

typedef struct NodPrincipal NodPrincipal;
typedef struct NodSecundar NodSecundar;
typedef struct Examen Examen;

typedef struct Nod Nod;
typedef struct ListaDubla ListaDubla;

struct Nod {
	int ID;
	Nod* next;
	Nod* prev;
};

//1-2-3=>> 2 si 3 ar fi vecini lui 1 si lista secundara a lui 1
struct ListaDubla {//pt lucrul cu arbori
	Nod* first;
	Nod* last;
};


struct Examen {
	int id;
	char* materie;
	float nota;
};


struct NodPrincipal {//pt lista princ
	Examen info;
	NodPrincipal* next;
	NodSecundar* vecini;//noduri lista secundara
};

struct NodSecundar {
	NodPrincipal* info;//adr unui nod princ
	NodSecundar* next;
};


void push(ListaDubla* ld, int ID) {//la stiva e discutata
	//pt lista dubla inalt
	Nod* nou = (Nod*)malloc(sizeof(Nod));
	nou->next = ld->first;
	nou->prev = NULL;
	nou->ID = ID;

	if (ld->first == NULL) {
		ld->first = ld->last = nou;
	}
	else {
		ld->first->prev = nou;
		ld->first = nou;
	}
}

void put(ListaDubla* ld, int ID) {//la coada
	Nod* nou = (Nod*)malloc(sizeof(Nod));
	nou->next = NULL;
	nou->prev = ld->last;
	nou->ID = ID;

	if (ld->last == NULL) {
		ld->first = ld->last = nou;
	}
	else {
		ld->last->next = nou;
		ld->last = nou;
	}
}

int pop(ListaDubla* ld) {//pop si get(scoatere si din stiva si din coada)
	//inseram ID, ne intereseaza cand parcurgem nodurile
	int ID = -1;
	if (ld->first) {
		ID = ld->first->ID;
		Nod* aux = ld->first;
		ld->first = ld->first->next;
		if (ld->first == NULL) {
			ld->last = NULL;
		}
		free(aux);
	}
	return ID;
}



Examen initExamen(int id, const char* materie, float nota)
{
	Examen examen;
	examen.id = id;
	examen.materie = (char*)malloc(strlen(materie) + 1);
	strcpy(examen.materie, materie);
	examen.nota = nota;

	return examen;
}


void inserareListaPrincipala(NodPrincipal** cap, Examen examen) {//lista simpla inalt
	NodPrincipal* nou = (NodPrincipal*)malloc(sizeof(NodPrincipal));
	nou->info = examen;
	nou->next = NULL;
	nou->vecini = NULL;
	NodPrincipal* aux = *cap;
	if (*cap) {
		while (aux->next) {
			aux = aux->next;
		}
		aux->next = nou;
	}
	else {
		*cap = nou;
	}
}

void inserareListaSecundara(NodSecundar** cap, NodPrincipal* info)//lista simpla inalt
{
	NodSecundar* nou = (NodSecundar*)malloc(sizeof(NodSecundar));
	nou->info = info;
	nou->next = NULL;
	if (*cap)
	{
		NodSecundar* aux = *cap;
		while (aux->next)
		{
			aux = aux->next;
		}
		aux->next = nou;
	}
	else
	{
		*cap = nou;
	}
}

void afisareExamen(Examen e) {
	printf("\n%d. Nota minima de promovare a examenului la materia %s: %.2f", e.id, e.materie, e.nota);
}



NodPrincipal* cautareNodDupaId(NodPrincipal* graf, int id) {//cauta adr unui nod dupa un id
	//id ul nodului pe care il cautam
	while (graf != NULL && id != graf->info.id) {//cat tp ca id nu e cel cautat si graf ul nu i null
		graf = graf->next;//trecem mai departe
	}
	return graf;//fiec returnez nodul cautat, fie nu l gasesc si afis null
}


//adaugare intre 2 noduri
void adaugaMuchie(NodPrincipal* graf, int id1, int id2) {
	//ca sa i fac vecini, inserez ca la 1 e muchia 2, si la 2 e muchia 1,adtfel ex muchie intre ei
	NodPrincipal* nod1 = cautareNodDupaId(graf, id1);
	NodPrincipal* nod2 = cautareNodDupaId(graf, id2);
	if (nod1 != NULL && nod2 != NULL) {
		inserareListaSecundara(&nod1->vecini, nod2);//dc &?
		//directie de la 1 la 2
		inserareListaSecundara(&nod2->vecini, nod1);//directie de la 2 la 1
	}

}


void afisareGraf(NodPrincipal* graf) {
	while (graf != NULL) {
		afisareExamen(graf->info);//afisam info utila
		NodSecundar* vecini = graf->vecini;
		printf("\"nVeicni:");
		while (vecini != NULL) {
			afisareExamen(vecini->info->info);//pt un nod princ-> pt un nod secundar
			vecini = vecini->next;
		}
		printf("\n");
		graf = graf->next;
	}
}


//parcurgereIN ADANC
void parcurgereInAdancime(NodPrincipal* graf, int idStart) {
	//am nev de un vector//sa trec prin toate noduri si sa incep de la primul
	//daca am trecut prin ele le notam ca 1, vizitat
	int dimensiune = 6;
	int* vectorVizitate = (int*)malloc(dimensiune * sizeof(int));

	for (int i = 0; i < dimensiune; i++) {
		vectorVizitate[i] = 0;//n am niciun nod vizitat si e cu 0
	}

	ListaDubla stiva;
	stiva.first = stiva.last = NULL;
	//luam primul nod
	push(&stiva, idStart);//nsh dc &
	//il marchez ca vizitta
	vectorVizitate[idStart-1] = 1;//ca inc de la 0 - 5 si daca e 1 adk prima poz va fi 1-1(al nostru)=0
	//pt ca asa au fost trecute id urile,depinde de fiec scenariu ///daca se schimba id urile, se schimba maparea
	
	//parcurg stiva pana se goleste

	while (stiva.first) {//daca mai are elem
		int idExtras = pop(&stiva);//iau id de start il pun in stiva
		//LIFOOOOOO->tine minte (asa se face cea in adanc)
		//caut nodul
		NodPrincipal* nodExtras = cautareNodDupaId(graf, idExtras);
		afisareExamen(nodExtras->info);//am afisat nodul respc
		NodSecundar* vecini = nodExtras->vecini;
		
		//parcurg lista de vecini
		while (vecini) {
			if (vectorVizitate[vecini->info->info.id-1] == 0) {//primul vecin n a fost vizitat
				//deci daca n a fost inserat
				//il inseram in stiva
				push(&stiva, vecini->info->info.id);
				vectorVizitate[vecini->info->info.id - 1] = 1;

			}
			vecini = vecini->next;
		}
		/////1 3 // dupa 5//6  ///4-> vizitat//  ->>>>>>>>    2
		//merg in while ul princ->scoatem pe 2->stiva va fi NULL
	}

	free(vectorVizitate);
}


void main() {
	NodPrincipal* graf = NULL;
	inserareListaPrincipala(&graf, initExamen(1, "SDD", 5));
	inserareListaPrincipala(&graf, initExamen(2, "PAW", 5));
	inserareListaPrincipala(&graf, initExamen(3, "PEAG", 5));
	inserareListaPrincipala(&graf, initExamen(4, "JAVA", 5));
	inserareListaPrincipala(&graf, initExamen(5, "MACRO", 5));
	inserareListaPrincipala(&graf, initExamen(6, "SGBD", 5));

	//definim muchiile
	adaugaMuchie(graf, 1, 2);//o muchie
	adaugaMuchie(graf, 1, 3);
	adaugaMuchie(graf, 2, 4);
	adaugaMuchie(graf, 3, 5);
	adaugaMuchie(graf, 4, 6);
	adaugaMuchie(graf, 5, 6);


	afisareGraf(graf);
	//lista de liste-> reprez unui graf
	//daca aveam orientat aveam doar o muchie, indiferent de directie

	//parcurge a grafului 1. in adancime
	print("\nParcurgere in adancime; ");
	parcurgereInAdancime(graf, 1);


}

//TEST ->> info generale: 30-35 de min
//heap , maxheap si arbori de cautare  ->>>sa faci dif exerct//cele 4 tipuri de exerc pt nota 4
// /cautare  /eliberare de mem /sortari
//fara avl si grafuri
//un pct din of
//si 3 pct..
// // nota 4: -> sa definim info utila
//sa def fct de afisare pt info, de initializare, nu cu fisiere
//inserare si afisare,traversare a strcutrii(pt ambele)
//sa definesc structura// si sa le testam in main
////////
//pt cel 3-> un exerct dat de el nota 4-7(o fct)
// nota 7-10-> la fel, ne da un exerct(o fct)



//examen