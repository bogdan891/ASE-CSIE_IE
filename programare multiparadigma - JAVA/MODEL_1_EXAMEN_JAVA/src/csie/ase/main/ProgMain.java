package csie.ase.main;

import java.util.ArrayList;
import java.util.List;

import csie.ase.classes.*;
import csie.ase.utils.*;

public class ProgMain {
	public static void main(String[] args) {
		// Creează cheltuieli pentru casa 1
        List<Expense> expenses1 = new ArrayList<>();
        expenses1.add(new Expense("water_in", 11));
        expenses1.add(new Expense("water_out", 7));
        expenses1.add(new Expense("recycled", 20));
        expenses1.add(new Expense("garbage", 8));
        expenses1.add(new Expense("shared_electricity", 25));

        // Creează cheltuieli pentru casa 2
        List<Expense> expenses2 = new ArrayList<>();
        expenses2.add(new Expense("water_in", 31));
        expenses2.add(new Expense("water_out", 12));
        expenses2.add(new Expense("recycled", 28));
        expenses2.add(new Expense("garbage", 14));
        expenses2.add(new Expense("shared_electricity", 25));

        // Creează obiectele House
        House house1 = new House(22, "IF - Pantelimon", "eBlocAdmin", expenses1);
        House house2 = new House(23, "IF - Pantelimon", "eBlocAdmin", expenses2);

        // Adaugă în listă
        List<House> houseList = new ArrayList<>();
        houseList.add(house1);
        houseList.add(house2);

        // Scrie în fișier folosind serialize
        InputOutput.serialize("adminAlpha.txt", houseList);
        

        // Acest apel scrie ȘI expenses în fișierul adminBeta.txt
        InputOutput.serializeExp("adminBeta.txt", expenses1);
        InputOutput.serializeExp("adminBeta.txt", expenses2);

    }
}
