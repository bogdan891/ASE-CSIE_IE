package csie.ase.functions;

import java.io.IOException;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.List;

import csie.ase.ro.classes.*;

public class Serialize4Server {
	public static void serializeMobilePhone(MobilePhone obj, Socket socket) {
		try (ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream())) {
			out.writeObject(obj);
			out.flush();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	 public static void serializeMobilePhoneList(List<MobilePhone> phones, Socket socket) {
	        try {
	        	ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
	            out.writeObject(phones);
	            out.flush();
	        } catch (IOException e) {
	            e.printStackTrace();
	        }
	    }
}
