package com.ase.csie;

public class MainBox {
	public static void main(String[] args) {
		Box<String> b1 = new Box<>("1");
		Box<Integer> b2 = new Box<>(1);
		
		String str = (String)b1.getT();
	}
}
