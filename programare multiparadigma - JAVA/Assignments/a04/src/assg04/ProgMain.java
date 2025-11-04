package assg04;

public class ProgMain {

	public static void main(String[] args) {
		Matrix matrix = new Matrix(3, 3);
		matrix.insertVal(-10,10);
		
		System.out.println("The original matrix:");
		System.out.println();
		matrix.showMatrix();
		
		System.out.println();
		
		Matrix transposed = matrix.transpose();
		
		System.out.println("The transposed matrix:");
		System.out.println();
		transposed.showMatrix();
	}

}
