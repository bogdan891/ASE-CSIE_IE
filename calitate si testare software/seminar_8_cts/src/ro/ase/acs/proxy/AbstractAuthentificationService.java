package ro.ase.acs.proxy;

public interface AbstractAuthentificationService {
    boolean login(String username, String password);
}
