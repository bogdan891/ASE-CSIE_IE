package ro.ase.acs.strategy;

import java.util.List;

public class Sum implements Operation {

    @Override
    public double compute(List<Integer> numbers) {
        double sum = 0;
        for (int n : numbers) {
            sum += n;
        }
        return sum;
    }
}
