package seminar_8_java;

class ThreadNonSync extends Thread {
	public static int a = 0;
	public static int b = 0 ;
	
	public ThreadNonSync(String name) {
		super(name);
	}
	
	@Override
	public void run() {
		for (int i = 0; i < 3; i++) {
			System.out.println("Thread = " + getName() + " - a = " + a + ", b = " + b);
			a++;
			try {
				sleep((int)(Math.random() * 1000));
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
			b++;
		}
		System.out.println("My thread with name " + getName() + " is finished!");
	}
	
}

public class Main {

	public static void main(String[] args) {
		ThreadNonSync t1 = new ThreadNonSync("T1");
		ThreadNonSync t2 = new ThreadNonSync("T2");
		
		t1.start();
		t2.start();
		
		System.out.println("The main thread is finished!");
	}

}
