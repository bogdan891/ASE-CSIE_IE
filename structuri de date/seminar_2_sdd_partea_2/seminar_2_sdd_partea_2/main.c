#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
	char* tip;
	int numar;
	float distanta;
}Tren;

Tren citire(FILE* f)
{
	Tren t;
	char buffer[30];
	fgets(buffer, 30, f);
	char* tipul = strtok(buffer, "\n");
	t.tip = (char*)malloc((strlen(tipul) + 1) * sizeof(char));
	strcpy(t.tip, tipul);

	fgets(buffer, 10, f);
	t.numar = atof(buffer);

	fgets(buffer, 10, f);
	t.distanta = atoi(buffer);

	return t;

	free(tipul);
}

void main()
{
	FILE* f = fopen("file.txt", "r");

	if (f != NULL)
	{
		Tren t = citire(f);
		printf("Tip tren: %s", t.tip);
	}

	fclose(f);
}