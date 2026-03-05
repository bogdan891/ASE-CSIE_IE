package ro.ase.acs.classes;

import java.util.List;

public class AverageCalculator extends SumCalculator{
    @Override
    public long compute(List<Integer> array) {
        long sum =  super.compute(array);
        return (array != null && array.size() > 0) ? sum / array.size() : 0;
    }
}