package ro.ase.acs.chain;

public abstract class CallCentreHandler {
    protected CallCentreHandler nextHandler;

    // ordinea o seteaza clientul
    public void setNextHandler(CallCentreHandler nextHandler) {
        this.nextHandler = nextHandler;
    }

    public abstract void refund(double sum);
}