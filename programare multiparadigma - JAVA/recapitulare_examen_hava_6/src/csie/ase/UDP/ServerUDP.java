package csie.ase.UDP;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

import csie.ase.classes.*;
import csie.ase.utils.*;

public class ServerUDP {
	public static void main(String[] args) {
        byte[] bufferReceived;
           byte[] bufferResponse;

       try {
           DatagramSocket serverSocket = new DatagramSocket(8333);
           System.out.println("Serverul UDP ascultă pe portul 8333");

           while (true) {
               bufferReceived = new byte[1024];
               DatagramPacket packet = new DatagramPacket(bufferReceived, bufferReceived.length);
               serverSocket.receive(packet);

               String received = new String(packet.getData(), 0, packet.getLength());
               //System.out.println("The packet received from client is:\n" + received);
               Bus bus = CSV.fromCSV(received);

               System.out.println("Bus primit de la client:\n" + bus);

               bus.setRoute("MODIFICAT_RUTA");
               bus.setNbOfStops(bus.getNbOfStops() + 1);

               String modifiedBusCSV = CSV.toCSV(bus);
               bufferResponse = modifiedBusCSV.getBytes();
               DatagramPacket response = new DatagramPacket(
                       bufferResponse, bufferResponse.length, packet.getAddress(), packet.getPort());
               serverSocket.send(response);
           }

       } catch (IOException e) {
           e.printStackTrace();
       }


   }
}
