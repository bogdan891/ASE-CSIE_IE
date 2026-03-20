package ro.ase.acs.simplefactory;

public class RestApiFactoryV2 {
    public RestApi getRestApi(ApiType apiType) {
        return switch (apiType) {
            case DEV -> new RestApiDevelopment();
            case PROD -> new RestApiProduction();
            default -> null;
        };
    }
}
