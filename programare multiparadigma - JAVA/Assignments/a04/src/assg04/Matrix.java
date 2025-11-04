package assg04;

import java.util.Random;

public class Matrix {
	private int[][] val;
	private int rows;
	private int columns;
	
	public Matrix(int rows, int columns) {
		this.rows = rows;
		this.columns = columns;
		val = new int[rows][columns];
	}
	
	public void insertVal(int min, int max) {
		Random value = new Random();
		for (int i = 0; i < rows; i++)
			for (int j = 0; j < columns; j++) 
				val[i][j] = value.nextInt(max - min + 1) + min;
	}
		
	public void showMatrix() {
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				System.out.printf(" %4d ", val[i][j]);
			}
			System.out.println();
		}
				
	}
	
	public Matrix transpose() {
		Matrix transposed = new Matrix(columns, rows);
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				transposed.val[j][i] = this.val[i][j];
			}
		}
		return transposed;
			
	}
}
