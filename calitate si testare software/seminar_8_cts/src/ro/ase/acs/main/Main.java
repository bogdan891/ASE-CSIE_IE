package ro.ase.acs.main;

import ro.ase.acs.adapter.*;
import ro.ase.acs.facade.*;
import ro.ase.acs.proxy.*;

public class Main {
    public static void main(String[] args) {
        System.out.println("========================================");
        System.out.println("Adapter");
        System.out.println("========================================");

        System.out.println();
        AbstractTrainTicketing trainTicketing = new TrainTicketing();
        trainTicketing.buyTicket(3, 30);
        System.out.println();

        AbstractBusTicketing busTicketing = new BusTicketing();
        busTicketing.reserveSeat();
        System.out.println();

        trainTicketing = new TicketingObjectAdapter(busTicketing);
        trainTicketing.buyTicket(3, 30);
        System.out.println();

        trainTicketing = new TicketingClassAdapter();
        trainTicketing.buyTicket(3, 30);

        System.out.println("========================================");
        System.out.println("Facade");
        System.out.println("========================================");

        System.out.println();
        CarFacade carFacade = new CarFacade();
        carFacade.start();
        System.out.println();
        carFacade.emrgencyBrake();
        System.out.println();
        carFacade.park();

        System.out.println("========================================");
        System.out.println("Proxy");
        System.out.println("========================================");

        AbstractAuthentificationService authentificationService = new AuthentificationService();
        boolean isAuthentificated = authentificationService.login("admin", "admin");
        System.out.println(isAuthentificated);

        authentificationService = new AuthentificationProxy(authentificationService);

        for (int i = 0; i < 5; i++) {
            authentificationService.login("x", "y");
        }

        isAuthentificated = authentificationService.login("admin", "admin");
        System.out.println(isAuthentificated);

        System.out.println("========================================");
    }
}