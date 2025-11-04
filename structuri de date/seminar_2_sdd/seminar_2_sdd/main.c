#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>

int* citire(FILE* f, int* dimensiune)
{
	fscanf(f, "%d", dimensiune);
	int* vector = (int*)malloc((*dimensiune) * sizeof(int));
	
	for (int i = 0; i < *dimensiune; i++)
	{
		fscanf(f, "%d", &vector[i]);
	}

	return vector;
}

void afisare(int* vector, int dimensiune)
{
	printf("\n");
	for (int i = 0; i < dimensiune; i++)
	{
		printf("%d ", vector[i]);
	}
}
void main()
{
	FILE* f = fopen("file.txt", "r");

	//int value1, value2;

	int* vector = NULL;
	int dimensiune = 0;

	if (f == NULL)
		printf("Eroare la deschiderea fisierului!");
	else
	{
		/*fscanf(f, "%d", &value1);
		fscanf(f, "%d", &value2);

		printf("Value 1: %d", value1);
		printf("\n");
		printf("Value 2: %d", value2);
		printf("\n");
		*/

		//citire si afisare elemente vector
		vector = citire(f, &dimensiune);
		
	}

	afisare(vector, dimensiune);
	free(vector);
	fclose(f);
}