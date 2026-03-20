package ro.ase.acs.classes;

import ro.ase.acs.interfaces.AbstractCalculator;

import java.util.List;

public class AverageCalculator implements AbstractCalculator {
    @Override
    public long compute(List<Integer> list) {
        long sum = list != null ? list.stream().mapToLong(i -> i).sum() : 0;
        return (list != null && list.size() > 0) ? sum / list.size() : 0;
    }
}
