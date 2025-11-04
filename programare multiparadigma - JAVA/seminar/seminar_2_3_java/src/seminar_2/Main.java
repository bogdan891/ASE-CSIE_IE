package seminar_2;

public class Main {
	public static void main(String[] args) {
		//(!) Doar acestea sunt stocate in stack restul sunt referinte (!)
		int a = 0; //4 bytes
		short b = 1111; //2 bytes
		long c = 1_111_111_111_111_111l; //8 bytes
		float d = 1.1f; //4 bytes
		double e = 1.1; //8 bytes
		byte f = 0x01; //1 byte
		char g = 'a'; //2 bytes
		boolean h = false; //1 bit
		
		
		final int a1 = 20;
		System.out.println(a1);
		
		//Class wrapper De ex: Integer-referinta, int-primitiva
		Integer a2 = 1; //autoboxing
		Short b1 = 1;
		Long c1 = 1l;
		Float d1 = 1.1f;
		Double e1 = 1.2;
		Byte f1 = 0x02;
		Character g1 = 'a';
		Boolean h1 = false;
		
		//Masive
		//Media notelor unor studenti
		
		int noStudents = 2;
		int noLect = 3;
		
		float[] avgStudentMark = new float[noStudents];
		
		//short[][] studentMarks = new short[noStudents][noLect];
		short[][] studentMarks = new short[][] {{5, 8, 9}, {8, 7, 9}};
		
		for (int i = 0; i < noStudents; i++) {
			avgStudentMark[i] = 0;
			for (int j = 0; j < noLect; j++) {
				avgStudentMark[i] += studentMarks[i][j];
			}
			avgStudentMark[i] /= noLect;
		}
		
		for (int i = 0; i < noStudents; i++) {
			System.out.println("The average mark for Student " + i + " is " + avgStudentMark[i]);
		}
	}
}
