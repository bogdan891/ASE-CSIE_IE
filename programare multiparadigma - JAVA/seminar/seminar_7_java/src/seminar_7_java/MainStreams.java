package seminar_7_java;

import java.util.Arrays;
import java.util.IntSummaryStatistics;
import java.util.List;
import java.util.Random;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class MainStreams {

	public static void main(String[] args) {
		
		List<String> strings = Arrays.asList("SM S24 Ultra", "iPhone 16 Pro", "",
				"SM A33 5G", "", "iPhone XR", "", "SM S24 Plus", "iPhone 16 Plus");
		
		long start = 0,  stop = 0;
		start = System.nanoTime();
		
		long count = 0;
		for(String s : strings) {
			if(s.isEmpty()) {
				count++;
			}
		}
		stop = System.nanoTime();
		
		System.out.println("Nb of empty strings is " + count + ", the time for execution is " + (stop-start));
		
		count = strings.stream().filter((s) -> s.isEmpty()).count();
		System.out.println("Nb of empty strings is " + count + ", the time for execution is " + (stop-start));
		
		Predicate<String> predicate = (s) -> s.length() == 9;
		count = strings.stream().filter(predicate).count();
		System.out.println("Nb of empty strings with 9 chars is " + count);
		
		List<String> result = strings.stream().filter(predicate).collect(Collectors.toList());
		System.out.println(result);
		
		String s1 = strings.stream().filter(predicate).collect(Collectors.joining("; "));
		System.out.println(s1);
		
		List<Integer> numbers = Arrays.asList(3,2,2,4,2,1,4,5,6);
		List<Integer> squareNumbers = numbers.stream().map((n) -> (n * n)).collect(Collectors.toList());
		System.out.println(squareNumbers);
		
		List<String> numbersString = Arrays.asList("1", "2", "3");
		IntSummaryStatistics intss = numbersString.stream().mapToInt((x) -> Integer.parseInt(x)).summaryStatistics();
		
		Random random = new Random();
		for(int i = 0; i < 10; i++) {
			System.out.println(random.nextInt(9) + 1);
		}
		System.out.println("--------------------------------------------------------------------");
		random.ints().limit(10).sorted().forEach(intss);
	}

}
