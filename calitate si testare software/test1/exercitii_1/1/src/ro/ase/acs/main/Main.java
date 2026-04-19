package ro.ase.acs.main;

import ro.ase.acs.task1.PunctControl;
import ro.ase.acs.task2.Ticket;
import ro.ase.acs.task2.TicketFactory;
import ro.ase.acs.task2.TicketType;
import ro.ase.acs.task3.Cartier;
import ro.ase.acs.task3.CartierCollection;
import ro.ase.acs.task3.CartierModel;
import ro.ase.acs.task4.ServiciiPublice;
import ro.ase.acs.task6.RegistruServicii;
import ro.ase.acs.task5.Factory;
import ro.ase.acs.task5.HightechFactory;
import ro.ase.acs.task5.RezidentialFactory;
import ro.ase.acs.task5.Sector;

import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        //task1
        PunctControl punctControl = PunctControl.getInstance();
        punctControl.use();

        //task2
        TicketFactory simpleFactory = new TicketFactory();
        Ticket ticket = simpleFactory.create(TicketType.ELEV);
        ticket.showDiscount();

        //task3
        Cartier cartier = new CartierModel();
        cartier.setBuildings(new ArrayList<>(List.of("Bloc Rezidential", "Spital", "Centru comercial")));
        cartier.setUtilities(new ArrayList<>(List.of("Gaze", "Apa", "Apa calda", "Curent electric")));
        cartier.setParcuri(5);
        cartier.setPollutionSensors(true);

        CartierCollection matrix = new CartierCollection();
        Cartier copie = matrix.getCartier("CARTIER_MODEL");
        copie.show();

        //task4
        ServiciiPublice.Builder builder = new ServiciiPublice.Builder();
        ServiciiPublice sp = builder.addBiblioteca(true).addColectare(false).addIluminat(true).build();
        System.out.println(sp.toString());

        //task5
        Factory factory = new HightechFactory();
        Sector s1 = factory.createSector();
        s1.gestiuneEnergie();

        factory = new RezidentialFactory();
        Sector s2 = factory.createSector();
        s2.gestiuneEnergie();

        //task6
        RegistruServicii.Serviciu rs1 = RegistruServicii.getSingleton("POLITIE");
        RegistruServicii.Serviciu rs2 = RegistruServicii.getSingleton("POLITIE");
        rs1.execute();
        rs2.execute();
    }
}