package ro.ase.acs;

public class Main {
    public static void main(String[] args) {
        /**
         * Compania are nevoie de un modul care să gestioneze conexiunea cu serverul central de update-uri.
         * Deoarece resursele de rețea sunt limitate, este critic ca în toată aplicația de sistem a telefonului să existe
         * o singură instanță a managerului de conexiune, pentru a nu deschide porturi inutile către server.
         */

        SingletonServer singletonServer = SingletonServer.getInstance();
        singletonServer.update("Android 7 Nougat");
        SingletonServer server1 = SingletonServer.getInstance();
        server1.update("Android 8 Oreo");
    }
}