package csie.ase.server;

import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.nio.file.Files;
import java.nio.file.Path;

public class Client3 {
	public static void main(String[] args) {
		final int port = 9876;
		final String path = "airplanes3.bin";
		
		try(Socket socket = new Socket("localhost", port)){
			byte[] buffer = Files.readAllBytes(Path.of(path));
			DataOutputStream out = new DataOutputStream(socket.getOutputStream());
			out.writeInt(buffer.length);
			out.write(buffer);
			out.flush();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
