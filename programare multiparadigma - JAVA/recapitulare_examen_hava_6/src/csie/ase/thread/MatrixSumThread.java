package csie.ase.thread;

import java.io.BufferedReader;
import java.io.EOFException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class MatrixSumThread implements Runnable{

    int[][] matrix1, matrix2;
    String fileName1, fileName2, fileName3;
    int start, end;
    static int[][] result;
    public MatrixSumThread(int[][] matrix1, int[][] matrix2, String fileName1, String fileName2, String fileName3,
            int start, int end) {
        super();
        this.matrix1 = matrix1;
        this.matrix2 = matrix2;
        this.fileName1 = fileName1;
        this.fileName2 = fileName2;
        this.fileName3 = fileName3;
        this.start = start;
        this.end = end;
    }

    public int[][] readFromFile(String fileName,int rows, int cols) {
        int[][] matrix = new int[rows][cols];
        try(BufferedReader reader = new BufferedReader(new FileReader(fileName))){

            String line;
            int currentRow = 0;

            while((line = reader.readLine()) != null && currentRow < rows) {
                String[] tokens = line.trim().split("\s+");
                for (int i = 0; i < cols && i < tokens.length; i++) {
                    matrix[currentRow][i] = Integer.parseInt(tokens[i]);
                }
                currentRow++;
            }


        }catch(IOException e) {
            e.printStackTrace();
        }
        return matrix;
    }

	@Override
	public void run() {
		// TODO Auto-generated method stub
		
	}

}