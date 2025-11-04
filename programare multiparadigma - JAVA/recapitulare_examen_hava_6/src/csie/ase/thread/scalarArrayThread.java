package csie.ase.thread;

import java.util.List;
import java.util.concurrent.Callable;

public class scalarArrayThread implements Callable<Integer>{
	List<Integer> list1;
	List<Integer> list2;
	private final Object lock = new Object();
	private static int result = 0;
	int start;
	int end;
	
	public scalarArrayThread(List<Integer> list1, List<Integer> list2, int start, int end) {
		super();
		this.list1 = list1;
		this.list2 = list2;
		this.start = start;
		this.end = end;
	}
	
	@Override
	public Integer call() throws Exception {
		for(int i = start; i < end; i++) {
			synchronized (lock) {
				result += list1.get(i) * list2.get(i);
			}
		}
		return result;
	}
}