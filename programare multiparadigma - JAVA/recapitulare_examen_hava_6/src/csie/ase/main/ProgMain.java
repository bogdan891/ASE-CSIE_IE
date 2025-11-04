package csie.ase.main;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;

import csie.ase.thread.*;
public class ProgMain {

	public static void main(String[] args) {
		int SIZE = 1_000;
        List<Integer> list1 = new ArrayList<>(SIZE);
        List<Integer> list2 = new ArrayList<>(SIZE);

        Random random = new Random();

        for (int i = 0; i < SIZE; i++) {
            list1.add(random.nextInt(100)); // valori între 0 și 99
            list2.add(random.nextInt(100));
        }
        
//        //2 THREADS
//		long startTime1 = System.currentTimeMillis();
//		ExecutorService executor = Executors.newFixedThreadPool(2);
//		Thread t1 = new Thread(new listSumThread(list1, list2, 0, (list1.size())/2));
//		Thread t2 = new Thread(new listSumThread(list1, list2, (list1.size())/2, list1.size()));
//		executor.execute(t1);
//		executor.execute(t2);
//		executor.shutdown();
//		try {
//			executor.awaitTermination(Long.MAX_VALUE, TimeUnit.MILLISECONDS);
//		} catch (InterruptedException e) {
//			e.printStackTrace();
//		}
//		long endTime1 = System.currentTimeMillis();
//		
//		System.out.println("The sum was calculated in " + (endTime1 - startTime1) + "ms with 2 THREADS.");
//		
//		//4 THREADS
//		long startTime2 = System.currentTimeMillis();
//		ExecutorService executor2 = Executors.newFixedThreadPool(4);
//		int size = list1.size(); 
//		int quarter = size / 4;
//
//		Thread t12 = new Thread(new listSumThread(list1, list2, 0, quarter));
//		Thread t22 = new Thread(new listSumThread(list1, list2, quarter, 2 * quarter));
//		Thread t32 = new Thread(new listSumThread(list1, list2, 2 * quarter, 3 * quarter));
//		Thread t42 = new Thread(new listSumThread(list1, list2, 3 * quarter, size));
//		executor2.execute(t12);
//		executor2.execute(t22);
//		executor2.execute(t32);
//		executor2.execute(t42);
//		executor2.shutdown();
//		try {
//			executor2.awaitTermination(Long.MAX_VALUE, TimeUnit.MILLISECONDS);
//		} catch (InterruptedException e) {
//			e.printStackTrace();
//		}
//		long endTime2 = System.currentTimeMillis();
//		
//		System.out.println("The sum was calculated in " + (endTime2 - startTime2) + "ms with 4 THREADS.");
//		
//		//8 THREADS
//		long startTime3 = System.currentTimeMillis();
//		ExecutorService executor3 = Executors.newFixedThreadPool(8);
//		int part = size / 8;
//
//		Thread t13 = new Thread(new listSumThread(list1, list2, 0 * part, 1 * part));
//		Thread t23 = new Thread(new listSumThread(list1, list2, 1 * part, 2 * part));
//		Thread t3 = new Thread(new listSumThread(list1, list2, 2 * part, 3 * part));
//		Thread t4 = new Thread(new listSumThread(list1, list2, 3 * part, 4 * part));
//		Thread t5 = new Thread(new listSumThread(list1, list2, 4 * part, 5 * part));
//		Thread t6 = new Thread(new listSumThread(list1, list2, 5 * part, 6 * part));
//		Thread t7 = new Thread(new listSumThread(list1, list2, 6 * part, 7 * part));
//		Thread t8 = new Thread(new listSumThread(list1, list2, 7 * part, size)); // ultimul merge până la final
//
//		executor3.execute(t1);
//		executor3.execute(t2);
//		executor3.execute(t3);
//		executor3.execute(t4);
//		executor3.execute(t5);
//		executor3.execute(t6);
//		executor3.execute(t7);
//		executor3.execute(t8);
//
//		executor3.shutdown();
//		try {
//			executor3.awaitTermination(Long.MAX_VALUE, TimeUnit.MILLISECONDS);
//		} catch (InterruptedException e) {
//			e.printStackTrace();
//		}
//		long endTime3 = System.currentTimeMillis();
//		System.out.println("The sum was calculated in " + (endTime3 - startTime3) + "ms with 8 THREADS.");
        
//        //Ex2
//        int noTh = 4;
//        int part = SIZE/noTh;
//        int result = 0;
//        List<Future<Integer>> futures = new ArrayList<>();
//        ExecutorService executor = Executors.newFixedThreadPool(noTh);
//        for(int i = 0; i < noTh; i++) {
//        	int start = i * part;
//        	int end;
//        	if(i == noTh - 1) {
//        		end = SIZE;
//        	} else {
//        		end = start + part;
//        	}
//        	futures.add(executor.submit(new scalarArrayThread(list1, list2, start, end)));
//        }
//        
//        executor.shutdown();
//        try {
//			executor.awaitTermination(Long.MAX_VALUE, TimeUnit.MILLISECONDS);
//		} catch (InterruptedException e) {
//			e.printStackTrace();
//		}
//        
//        for (Future<Integer> f : futures) {
//            try {
//				result += f.get();
//			} catch (InterruptedException | ExecutionException e) {
//				e.printStackTrace();
//			}
//        }
//        
//        System.out.println("The result is " + result);
        
        //Ex3
        
	}
}
