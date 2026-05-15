package ro.ase.acs.strategy;

import java.util.List;

public class Product implements Operation {
    @Override
    public double compute(List<Integer> numbers) {
        double p = 1;
        for (int n : numbers) {
             p *= n;
        }

        return p;
    }
}
