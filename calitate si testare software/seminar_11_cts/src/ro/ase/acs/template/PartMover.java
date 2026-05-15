package ro.ase.acs.template;

public abstract class PartMover {
    protected abstract void liftPart();
    protected abstract void movePart();
    protected abstract void dropPart();

    public final void transport() {
        liftPart();
        movePart();
        dropPart();
    }
}
