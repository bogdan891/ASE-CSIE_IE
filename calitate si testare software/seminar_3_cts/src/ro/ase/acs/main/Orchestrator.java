package ro.ase.acs.main;

import ro.ase.acs.dip.ServiceLocator;
import ro.ase.acs.exceptions.DependencyNotSetException;
import ro.ase.acs.interfaces.AbstractCalculator;
import ro.ase.acs.interfaces.AbstractValuePrinter;
import ro.ase.acs.interfaces.AbstractValuesReader;

import java.util.List;

public class Orchestrator {
    private final AbstractValuesReader valuesReader;
    private AbstractCalculator calculator;
    private final AbstractValuePrinter valuePrinter;

    public Orchestrator(ServiceLocator serviceLocator) {
        valuesReader = (AbstractValuesReader) serviceLocator.resolve("AbstractValuesReader");
        calculator = (AbstractCalculator) serviceLocator.resolve(AbstractCalculator.class.getSimpleName());
        valuePrinter = (AbstractValuePrinter) serviceLocator.resolve(AbstractValuePrinter.class.getSimpleName());
    }

    public Orchestrator(AbstractValuesReader valuesReader, AbstractValuePrinter valuePrinter) {
        this.valuesReader = valuesReader;
        this.valuePrinter = valuePrinter;
    }

    public Orchestrator(AbstractValuesReader valuesReader, AbstractCalculator calculator, AbstractValuePrinter valuePrinter) {
        this.valuesReader = valuesReader;
        this.calculator = calculator;
        this.valuePrinter = valuePrinter;
    }

    public void setCalculator(AbstractCalculator calculator) {
        this.calculator = calculator;
    }

    public void execute() throws DependencyNotSetException {
        if (this.calculator == null) {
            throw new DependencyNotSetException();
        }
        List<Integer> list = valuesReader.readValues(5);
        long result = calculator.compute(list);
        valuePrinter.printValue(result);
    }
}
