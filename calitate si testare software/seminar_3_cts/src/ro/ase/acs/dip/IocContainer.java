package ro.ase.acs.dip;

import ro.ase.acs.interfaces.AbstractCalculator;
import ro.ase.acs.interfaces.AbstractValuePrinter;
import ro.ase.acs.interfaces.AbstractValuesReader;
import ro.ase.acs.main.Orchestrator;

import java.util.HashMap;
import java.util.Map;

public class IocContainer {
    private Map<String, String> container = new HashMap<>();

    public void register(String contract, String implementation) {
        container.put(contract, implementation);
    }

    public Orchestrator initialize() {

        try {
            String dependencyName1 = container.get(AbstractValuesReader.class.getName());
            AbstractValuesReader dependency1 = (AbstractValuesReader) Class.forName(dependencyName1).
                    getConstructor().newInstance();

            String dependencyName2 = container.get(AbstractCalculator.class.getName());
            AbstractCalculator dependency2 = (AbstractCalculator) Class.forName(dependencyName2).
                    getConstructor().newInstance();

            String dependencyName3 = container.get(AbstractValuePrinter.class.getName());
            AbstractValuePrinter dependency3 = (AbstractValuePrinter) Class.forName(dependencyName3).
                    getConstructor().newInstance();

            String orchestratorName = container.get(Orchestrator.class.getName());

            return (Orchestrator) Class.forName(orchestratorName).getConstructor(AbstractValuesReader.class,
                    AbstractCalculator.class, AbstractValuePrinter.class).newInstance(dependency1,
                    dependency2, dependency3);

        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }
}
