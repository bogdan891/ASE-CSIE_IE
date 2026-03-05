package ro.ase.acs.classes;

import java.util.List;

public class SumCalculator {
    public long compute(List<Integer> array) {
        long sum = 0;
        for(int x : array) sum += x;
        return sum;
    }
}
