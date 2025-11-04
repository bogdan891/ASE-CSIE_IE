package csie.ase.utils;

import java.io.IOException;
import java.io.ObjectOutputStream;
import java.io.OutputStream;

import csie.ase.classes.*;

public class IO {
	public static void serialize(Airplane x, OutputStream output) {
		try{
			ObjectOutputStream out = new ObjectOutputStream(output);
			out.writeObject(x);
			out.flush();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
