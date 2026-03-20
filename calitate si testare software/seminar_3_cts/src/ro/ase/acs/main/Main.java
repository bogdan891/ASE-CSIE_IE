package ro.ase.acs.main;

import ro.ase.acs.classes.AverageCalculator;
import ro.ase.acs.classes.ValuePrinter;
import ro.ase.acs.classes.ValuesReader;
import ro.ase.acs.dip.IocContainer;
import ro.ase.acs.dip.ServiceLocator;
import ro.ase.acs.exceptions.DependencyNotSetException;
import ro.ase.acs.interfaces.AbstractCalculator;
import ro.ase.acs.interfaces.AbstractValuePrinter;
import ro.ase.acs.interfaces.AbstractValuesReader;

public class Main {
    public static void main(String[] args) {
        // Option 1: constructor and/or setter injection
        Orchestrator orchestrator = new Orchestrator(new ValuesReader(), new ValuePrinter());
        orchestrator.setCalculator(new AverageCalculator());
        try {
            orchestrator.execute();
        } catch (DependencyNotSetException e) {
            e.printStackTrace();
        }

        // Option 2: ServiceLocator
        ServiceLocator serviceLocator = new ServiceLocator();
        serviceLocator.register(AbstractValuesReader.class.getSimpleName(),
                new ValuesReader());
        serviceLocator.register(AbstractCalculator.class.getSimpleName(),
                new AverageCalculator());
        serviceLocator.register(AbstractValuePrinter.class.getSimpleName(),
                new ValuePrinter());

        Orchestrator orchestrator2 = new Orchestrator(serviceLocator);
        try {
            orchestrator2.execute();
        } catch (DependencyNotSetException e) {
            e.printStackTrace();
        }

        // Option 3: IoC Container

        IocContainer iocContainer = new IocContainer();
        iocContainer.register(AbstractValuesReader.class.getName(),
                ValuesReader.class.getName());
        iocContainer.register(AbstractCalculator.class.getName(),
                AverageCalculator.class.getName());
        iocContainer.register(AbstractValuePrinter.class.getName(),
                ValuePrinter.class.getName());
        iocContainer.register(Orchestrator.class.getName(),
                Orchestrator.class.getName());

        Orchestrator orchestrator3 = iocContainer.initialize();
        try {
            orchestrator3.execute();
        } catch (DependencyNotSetException e) {
            e.printStackTrace();
        }
    }

}
