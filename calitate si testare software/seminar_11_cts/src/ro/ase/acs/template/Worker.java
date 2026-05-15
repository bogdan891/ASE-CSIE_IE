package ro.ase.acs.template;

public class Worker extends PartMover{
    @Override
    protected void liftPart() {
        System.out.println("The worker is lifting the part");
    }

    @Override
    protected void movePart() {
        System.out.println("The worker is moving the part");
    }

    @Override
    protected void dropPart() {
        System.out.println("The worker is dropping the part");
    }
}
