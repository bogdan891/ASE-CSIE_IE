#include <stdio.h>
#include <malloc.h>

void interschimbare_valoare(int nr1, int nr2)
{
	int aux = nr1;
	nr1 = nr2;
	nr2 = aux;
}
void interschimbare_adresa(int* nr1, int* nr2)
{
	int aux = *nr1;
	*nr1 = *nr2;
	*nr2 = aux;
}

void main()
{
	/*
	int numarExamene = 5;
	float medieFinala = 9.5;
	char caracter = 'A';

	printf("Numarul de examene: ");
	printf("%d", numarExamene);
	printf("\n");
	printf("Media Finala: ");
	printf("%.2f", medieFinala);
	printf("\n");
	printf("Caracter: ");
	printf("%c", caracter);
	printf("\n");
	printf("Codul ASCII pentru litera %c este %d", caracter, caracter);
	printf("\n");

	char nume[7];
	nume[0] = 65;
	nume[1] = 110;
	nume[2] = 100;
	nume[3] = 114;
	nume[4] = 101;
	nume[5] = 105;
	nume[6] = '\0';

	printf("Numele este: %s", nume);
	printf("\n");

	//ALOCARE
	char* locatie = (char*)malloc(5 * sizeof(char));

	strcpy(locatie, "Cluj");
	printf("Locatia este: %s", locatie);
	printf("\n");

	//DEZALOCARE
	free(locatie); */

	int nr1, nr2;
	nr1 = 3, nr2 = 5;

	printf("Inainte de interschimbare:\n");
	printf("%d \n", nr1);
	printf("%d \n", nr2);


	printf("Transmitere prin valoare:\n");
	interschimbare_valoare(nr1, nr2);

	printf("%d \n", nr1);
	printf("%d \n", nr2);

	printf("Transmitere prin adresa:\n");
	interschimbare_adresa(&nr1, &nr2);

	printf("%d \n", nr1);
	printf("%d \n", nr2);
}