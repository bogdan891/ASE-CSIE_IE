package seminar_7_java;

@FunctionalInterface
interface GreetingService {
	void sayMessage(String message);
}

@FunctionalInterface
interface MathOperation {
	int operation(int a, int b);
}

class MathOpClass {
	
	public int operate(int a, int b, MathOperation op) {
		return op.operation(a,b);
	}
}

public class Main {

	public static void main(String[] args) {
		MathOpClass opClass = new MathOpClass();
		
		MathOperation addition = (int a, int b) -> {
			int result = 0;
			result = a + b;
			return result;
		};
		
		MathOperation substraction = (a,b) -> a - b;
		
		MathOperation multiplication = (int a, int b) -> {
			return a * b;
		};
		
		MathOperation division = (a,b) -> a/b;
		
		System.out.println("10 + 5 = " + opClass.operate(10,5,addition));
		
		System.out.println("10 - 5 = " + opClass.operate(10,5,substraction));

		System.out.println("10 * 5 = " + opClass.operate(10,5,multiplication));

		System.out.println("10 : 5 = " + opClass.operate(10,5,division));
		
		GreetingService gs1 = (String msg) -> {
			System.out.println("Hello " + msg + "!");
		};
		
		GreetingService gs2 = (String msg) -> {
			System.out.println("Bonjour " + msg + "!");
		};
		
		gs1.sayMessage("Kate");
		gs2.sayMessage("Marie");


	}

}
