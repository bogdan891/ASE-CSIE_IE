package ro.ase.acs.template;

public class RoboticArm extends PartMover{
    @Override
    protected void liftPart() {
        System.out.println("The arm is lifting the part...");
    }

    @Override
    protected void movePart() {
        System.out.println("The arm is moving the part...");
    }

    @Override
    protected void dropPart() {
        System.out.println("The arm is dropping the part...");
    }
}
