package ro.ase.acs.classes;

import ro.ase.acs.interfaces.AbstractCalculator;

import java.util.List;

public class SumCalculator implements AbstractCalculator {

    @Override
    public long compute(List<Integer> list) {
        long sum = 0;
        for (int i : list) {
            sum += i;
        }
        return sum;
    }
}
