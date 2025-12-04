from functools import reduce

temperaturi = [3, 5, 6, 2, -1, 0, 4, 7, 10, 12, 15, 14, 9, 5]
umiditate = [80, 78, 75, 82, 90, 88, 85, 70, 65, 60, 55, 57, 68, 72]
ore_soare = [1, 3, 2, 0, 0, 1, 4, 5, 6, 7, 8, 6, 5, 3]
zile = ["L", "Ma", "Mi", "J", "V", "S", "D",
        "L", "Ma", "Mi", "J", "V", "S", "D"]

import numpy as np

# cerinta 1

# 1.    Afișează:
                # prima temperatură,
                # ultima temperatură,
                # temperatura medie.
# 2.    Modifică temperatura din ziua 5 la valoarea 2

print("Prima temperatura: ", temperaturi[0])
print("Ultima temperatura: ", temperaturi[len(temperaturi) - 1])
print("Temperatura medie: ", np.mean(temperaturi))
temperaturi[3] = -2

#   cerinta 2

# 1.	Creează un set cu temperaturile unice.
# 2.	Arată câte valori diferite există.
# 3.	Creează un set cu zilele și explică de ce ordinea nu se păstrează.

set_temperaturi = set(temperaturi)
set_zile = set(zile)
print(set_temperaturi, set_zile)

#   cerinta 3

# 1.	Creează un tuplu interval cu maximele și minimele temperaturilor.
# 2.	Încearcă să modifici o valoare și observă eroarea.

tuplu_temperaturi = (min(temperaturi), max(temperaturi))
print("Tuplu interval cu maximele și minimele temperaturilor: ", tuplu_temperaturi)

#   cerinta 4
# 1.	Asociază fiecărei zile o temperatură:
# 2.	Afișează:
            # o	toate cheile
            # o	toate valorile
            # o	item-urile

meteo = {zi: t for zi, t in zip(zile, temperaturi)}
print("Keys: ", meteo.keys())
print("Values: ", meteo.values())
print("Items: ", meteo.items())

# cerinta 5
# 1.	Creează o listă cu temperaturile în Fahrenheit.
# 2.	Creează un dicționar în care cheia este indicele zilei, iar valoarea este „rece” dacă temperatura < 5 și „cald” pentru restul.

fahrenheit = [round(c * 9/5 + 32, 1) for c in temperaturi]
print("Temperaturile exprimate in Fahrenheit: ", fahrenheit)
dictionar_temperaturi = {
    zi: ("cald" if temp >= 5 else "rece")
    for zi, temp in zip(zile, temperaturi)
}

print("Dictionar temperaturi: ", dictionar_temperaturi)

# cerinta 6

# 1.	Folosește map pentru a calcula pătratul fiecărei temperaturi.
# 2.	Folosește filter pentru a extrage doar temperaturile pozitive.
# 3.	Folosește reduce pentru a calcula suma tuturor orelor de soare.

map_temp = map(lambda t: t ** 2, temperaturi)
print("Map temperaturi: ", list(map_temp))

temp_poz = filter(lambda t: t >= 0, temperaturi)
print("Temperaturile pozitive: ", list(temp_poz))

total_ore_soare = reduce(lambda a, b:  a + b, ore_soare)
print("Nr total de oare cu soare: ", total_ore_soare)

# cerinta 7

# Afișează pentru umiditate transformat intr-un array:
        # o	shape
        # o	ndim
        # o	dtype
        # o	itemsize
        # o	size
        # o	nbytes

u = np.array(umiditate)
print("Shape: ", u.shape)
print("Dim: ", u.ndim)
print("Tipul de date: ", u.dtype)
print("Dimensiunea unui element: ", u.itemsize)
print("Nr de elemente: ", u.size)
print("Numarul de bytes ocupati: ", u.nbytes)

# cerinta 8

# 1.	Afișează temperaturile din zilele 3-7.
# 2.	Afișează temperaturile doar din zilele pare.
# 3.	Inversează lista temperaturilor ([::-1]).

print("Temperaturile din zilele 3-7: ", temperaturi[2:7])
print("Temperaturile din zilele pare: ", temperaturi[1::2])
print("Temperaturile in ordine inversa: ", temperaturi[::-1])

# cerinta 9

# 1.	Creează o matrice 14×3 cu toate datele:
# 2.	M = np.array([temperaturi, umiditate, ore_soare]).T
# 3.	Afișează:
            # o	toate rândurile unde temperatura este > 5
            # o	coloana umiditate
            # o	primele 5 rânduri

M = np.array([temperaturi, umiditate, ore_soare]).T
print("Randuri cu temperatura > 5:")
print(M[M[:, 0] > 5])
print("Coloana umiditate:")
print(M[:, 1])
print("\nPrimele 5 randuri:")
print(M[:5])

# cerinta 10

# 1.	Creează:
            # o	un array de zeros de lungime 5
            # o	un array 3×3 plin cu 7
            # o	o matrice identitate 4×4

zero = np.zeros(5)
full7 = np.full((3, 3), 7)
i4 = np.identity(4, dtype = "int")

# cerinta 11

a = np.array([1,2,3])
print("Tile:", np.tile(a, 4))
print("Repeat:", np.repeat(a, 5))