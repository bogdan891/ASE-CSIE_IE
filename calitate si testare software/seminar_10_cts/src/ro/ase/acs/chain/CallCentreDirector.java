package ro.ase.acs.chain;

public class CallCentreDirector extends CallCentreHandler {
    @Override
    public void refund(double sum) {
        System.out.println("Refund accepted by director");
    }
}
