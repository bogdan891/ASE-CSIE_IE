package ro.ase.acs.classes;

import ro.ase.acs.interfaces.AbstractValuesReader;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class ValuesReader implements AbstractValuesReader {
    private final static Scanner scanner = new Scanner(System.in);

    @Override
    public List<Integer> readValues(int noOfValues) {
        List<Integer> list = new ArrayList<>();

        for (int i = 0; i < noOfValues; i++) {
            System.out.print("value = ");
            int value = scanner.nextInt();
            list.add(value);
        }

        return list;
    }
}
