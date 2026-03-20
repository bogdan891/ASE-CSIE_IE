package ro.ase.acs.simplefactory;

public class RestApiFactory {

    public static final String PRODUCTION = "production";
    public static final String DEVELOPMENT = "development";

    public RestApi getRestApi(String apiType) {
        if (PRODUCTION.equalsIgnoreCase(apiType))
            return new RestApiProduction();
        else if (DEVELOPMENT.equalsIgnoreCase(apiType))
            return new RestApiDevelopment();
        else throw new IllegalArgumentException("Invalid api type");
    }
}
