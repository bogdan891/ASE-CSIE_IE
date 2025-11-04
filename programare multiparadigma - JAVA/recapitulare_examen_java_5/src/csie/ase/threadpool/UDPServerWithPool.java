package csie.ase.threadpool;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class UDPServerWithPool {
	public static void main(String[] args) {
		final int port = 9896;
		final int bufferSize = 1024;
		ExecutorService pool = Executors.newFixedThreadPool(4);

		try (DatagramSocket socket = new DatagramSocket(port)) {
			System.out.println("UDP Server with thread pool running...");

			while (true) {
				byte[] buffer = new byte[bufferSize];
				DatagramPacket packet = new DatagramPacket(buffer, buffer.length);

				socket.receive(packet);

				// trimite și socket-ul către handler pentru a putea trimite un răspuns
				pool.submit(new UDPPacketHandler(packet, socket));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
