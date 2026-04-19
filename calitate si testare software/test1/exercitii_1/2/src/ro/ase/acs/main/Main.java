package ro.ase.acs.main;

import ro.ase.acs.task1.Reactor;
import ro.ase.acs.task2.Robot;
import ro.ase.acs.task2.RobotFactory;
import ro.ase.acs.task2.RobotType;
import ro.ase.acs.task3.ColectieModul;
import ro.ase.acs.task3.ModulSupravietuire;
import ro.ase.acs.task4.CostumSpatial;

public class Main {
    public static void main(String[] args) throws CloneNotSupportedException {
        //1
        Reactor reactor = Reactor.getInstance();
        reactor.use();

        //2
        RobotFactory robotFactory = new RobotFactory();
        Robot r = robotFactory.createRobot(RobotType.TRANSPORTER);
        r.showRobotSpecs();

        //3
        ColectieModul colectie = new ColectieModul();
        ModulSupravietuire modul = colectie.getModul("MODUL_SUPRAVIETUIRE");
        modul.afisareStatus();

        //4
        CostumSpatial costumAstronaut = new CostumSpatial.Builder()
                .addJetpack(true)
                .addNightVision(true)
                .addOxigen(true)
                .build();
        System.out.println(costumAstronaut);
    }
}