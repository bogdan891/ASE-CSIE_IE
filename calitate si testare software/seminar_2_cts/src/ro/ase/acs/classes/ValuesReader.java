package ro.ase.acs.classes;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class ValuesReader {
    private static final Scanner scanner = new Scanner(System.in);
    public List<Integer> readValues(int nbOfValues) {
        List<Integer> array = new ArrayList<>();
        for (int i = 0; i < 5; i++) {
            System.out.print("Value = ");
            array.add(scanner.nextInt());
        }

        return array;
    }
}
