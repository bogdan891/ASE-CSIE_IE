package ro.ase.acs.classes;

import ro.ase.acs.interfaces.AbstractValuePrinter;

public class ValuePrinter implements AbstractValuePrinter {

    @Override
    public void printValue(long value) {
        System.out.println("Result = " + value);
    }
}
