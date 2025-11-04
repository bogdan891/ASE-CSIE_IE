package com.ase.csie.java.io;

public class Guest implements Serializeable {
	private String name;

	public Guest(String name) {
		this.name = name;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	
}
