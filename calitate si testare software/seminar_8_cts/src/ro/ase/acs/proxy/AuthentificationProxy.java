package ro.ase.acs.proxy;

public class AuthentificationProxy implements AbstractAuthentificationService {
    private final AbstractAuthentificationService abstractAuthentificationService;
    private int numberOfFailedAttempts = 0;
    private static final int MAXIMUM_NUMBER_OF_ATTEMPTS = 5;

    public AuthentificationProxy(AbstractAuthentificationService abstractAuthentificationService) {
        this.abstractAuthentificationService = abstractAuthentificationService;
    }

    @Override
    public boolean login(String username, String password) {
        if (numberOfFailedAttempts >= MAXIMUM_NUMBER_OF_ATTEMPTS) return false;

        boolean isSuccesful = abstractAuthentificationService.login(username, password);

        if(isSuccesful) {
            numberOfFailedAttempts = 0;
            return true;
        } else {
            numberOfFailedAttempts++;
            return false;
        }
    }
}
