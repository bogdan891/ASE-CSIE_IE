package ro.ase.acs;

public class SingletonServer {
    private static SingletonServer instance;

    private SingletonServer() {}

    public static synchronized SingletonServer getInstance() {
        if (instance == null) {
            instance = new SingletonServer();
        }
        return instance;
    }

    public void update(String osVersion) {
        System.out.println("You have received updates to " + osVersion);
    }
}
