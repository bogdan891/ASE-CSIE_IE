package csie.ase.servers;

import java.io.*;
import java.net.Socket;

public class FileReceiver implements Runnable {
    private Socket socket;

    public FileReceiver(Socket socket) {
        this.socket = socket;
    }

    @Override
    public void run() {
        try (DataInputStream dis = new DataInputStream(socket.getInputStream())) {
            String fileName = dis.readUTF();
            long fileSize = dis.readLong();  
            FileOutputStream fos = new FileOutputStream("received_" + fileName);

            byte[] buffer = new byte[4096];
            int bytesRead;
            long totalRead = 0;

            while (totalRead < fileSize && (bytesRead = dis.read(buffer)) != -1) {
                fos.write(buffer, 0, bytesRead);
                totalRead += bytesRead;
            }

            System.out.println("Fișierul \"" + fileName + "\" a fost primit cu succes.");
            fos.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
