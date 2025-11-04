package csie.ase.utils;

import java.io.IOException;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.List;

import csie.ase.classes.*;

public class Serialize {
	public static void serialize2Server(List<Bus> buses, Socket clientSocket) {
		try{
			ObjectOutputStream out = new ObjectOutputStream(clientSocket.getOutputStream());
			out.writeObject(buses);
			out.flush();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
