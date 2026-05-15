package ro.ase.acs.chain;

public class CallCentreManager extends CallCentreHandler {

    private static final int MANAGER_THRESHOLD = 500;

    @Override
    public void refund(double sum) {
        if (sum<= MANAGER_THRESHOLD) {
            System.out.println("Refund accepted by manager");
        } else {
            if(nextHandler!=null) {
                nextHandler.refund(sum);
            }
        }
    }
}
