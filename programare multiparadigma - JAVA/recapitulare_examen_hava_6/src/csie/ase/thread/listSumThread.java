package csie.ase.thread;

import java.util.ArrayList;
import java.util.List;

public class listSumThread implements Runnable {
	List<Integer> list1;
	List<Integer> list2;
	int start;
	int end;
	private static final Object lock = new  Object();
	private static List<Integer> result = new ArrayList<>();
	
	public listSumThread(List<Integer> list1, List<Integer> list2, int start, int end) {
		super();
		this.list1 = list1;
		this.list2 = list2;
		this.start = start;
		this.end = end;
	}
	
	public static List<Integer> getResult(){
		return result;
	}
	
	@Override
	public void run() {
		for (int i = start; i < end; i++) {
			synchronized (lock) {
				result.add(list1.get(i) + list2.get(i));
			}
		}
	}
}