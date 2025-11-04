package csie.ase.servers;

import java.io.*;
import java.net.*;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ServerTCP {
    private static final int PORT = 12345;

    public static void main(String[] args) {
        ExecutorService executor = Executors.newFixedThreadPool(5); // max 5 clienți simultan
        try (ServerSocket serverSocket = new ServerSocket(PORT)) {
            System.out.println("Serverul a pornit pe portul " + PORT);
            while (true) {
                Socket clientSocket = serverSocket.accept();
                executor.submit(new FileReceiver(clientSocket));
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        executor.shutdown();
    }
}

