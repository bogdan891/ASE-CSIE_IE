package csie.ase.threadpool;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

import csie.ase.ro.classes.MobilePhone;

public class UDPClient {
    public static void main(String[] args) {
    	 try (DatagramSocket clientSocket = new DatagramSocket()) {
             InetAddress serverAddress = InetAddress.getByName("localhost");
             int port = 9896;

             // Creezi obiectul
             MobilePhone phone = new MobilePhone("iPhone 15", "Apple", 6999.99);

             // Trimiți doar .toString() — un String normal
             String message = phone.toString();
             byte[] sendData = message.getBytes();

             DatagramPacket sendPacket = new DatagramPacket(sendData, 
            		 sendData.length, serverAddress, port);
             clientSocket.send(sendPacket);
             System.out.println("Am trimis la server: " + message);

             // Așteptăm un răspuns text de la server
             byte[] receiveData = new byte[1024];
             DatagramPacket receivePacket = new DatagramPacket(receiveData, receiveData.length);
             clientSocket.receive(receivePacket);

             String response = new String(receivePacket.getData(), 0, receivePacket.getLength());
             System.out.println("Răspuns de la server: " + response);
    	 } catch (Exception e) {
            e.printStackTrace();
        }
    }
}

