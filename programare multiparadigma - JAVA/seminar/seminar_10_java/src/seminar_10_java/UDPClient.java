package seminar_10_java;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

public class UDPClient {

	public static void main(String[] args) {
		try {
			DatagramSocket client = new DatagramSocket();
			
			byte[] buf1 = new byte[256];
			buf1[0] = 'H'; buf1[1] = 'e'; buf1[2] = 'l'; 
			buf1[3] = 'l'; buf1[4] = 'o'; buf1[5] = '!';
			//InetAddress addr = InetAddress.getLocalHost();
			InetAddress addr = InetAddress.getByName("localhost");
			DatagramPacket packet1 = new DatagramPacket(buf1, 0, buf1.length, addr, 8333);
			client.send(packet1);
			
			byte[] buf2 = (new String("Salut!")).getBytes();
			DatagramPacket packet2 = new DatagramPacket(buf2, 0, buf2.length, addr, 8333);
			client.send(packet2);
			
			byte[] bufResp = new byte[256];
			DatagramPacket response = new DatagramPacket(bufResp,bufResp.length);
			client.receive(response);
			
			System.out.println("Client received: " + new String(bufResp));
			
			client.close();

			
		} catch (IOException e) {
			e.printStackTrace();
		}

	}

}
