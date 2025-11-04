package seminar_10_java;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

public class UDPServer {

	public static void main(String[] args) {
		
		byte[] bufferReceived1 = null;
		byte[] bufferReceived2 = null;
		byte[] bufferResponse = null;
		
		try(DatagramSocket server = new DatagramSocket()) {
			System.out.println("UDP Server bined on port 8333");
			
			while(true) {
				bufferReceived1 = new byte[256];
				DatagramPacket packet1 = new DatagramPacket(bufferReceived1, bufferReceived1.length);
				server.receive(packet1);
				
				System.out.println("Server received from client packet 1 = " + new String(bufferReceived1));
				
				
				bufferReceived2 = new byte[256];
				DatagramPacket packet2 = new DatagramPacket(bufferReceived2, bufferReceived2.length);
				server.receive(packet2);
				
				System.out.println("Server received from client packet 1 = " + new String(bufferReceived2));
				
				
				bufferResponse = new String("OK!").getBytes();
				DatagramPacket packet3 = new DatagramPacket(bufferResponse, 0 , bufferResponse.length, 
						packet2.getAddress(), packet2.getPort());
				server.send(packet3);
				
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		
	}

}
