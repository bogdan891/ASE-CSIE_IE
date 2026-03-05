package ro.ase.acs.main;

import ro.ase.acs.classes.AverageCalculator;
import ro.ase.acs.classes.SumCalculator;
import ro.ase.acs.classes.ValuePrinter;
import ro.ase.acs.classes.ValuesReader;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        ValuesReader reader = new ValuesReader();
        SumCalculator calculator = new AverageCalculator();
        ValuePrinter printer = new ValuePrinter();

        List<Integer> array = reader.readValues(5);
        long result = calculator.compute(array);
        printer.printResult(result);
    }
}
