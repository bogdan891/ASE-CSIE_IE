package ro.ase.acs.simplefactory;

public class RestApiDevelopment implements RestApi{
    @Override
    public void connect() {
        System.out.println("Connecting to the development API...");
    }
}
