package csie.ase.servers;

import java.io.*;
import java.net.Socket;

public class ClientTCP {
    private static final String SERVER = "localhost";
    private static final int PORT = 12345;

    public static void main(String[] args) {
        String[] filesToSend = { "adminAlpha.txt", "adminBeta.txt" };

        for (String fileName : filesToSend) {
            try (Socket socket = new Socket(SERVER, PORT);
                 DataOutputStream dos = new DataOutputStream(socket.getOutputStream());
                 FileInputStream fis = new FileInputStream(fileName)) {

                File file = new File(fileName);
                long fileSize = file.length();

                dos.writeUTF(file.getName()); 
                dos.writeLong(fileSize);       

                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = fis.read(buffer)) != -1) {
                    dos.write(buffer, 0, bytesRead);
                }

                System.out.println("Fișierul \"" + fileName + "\" a fost trimis.");
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
