package ro.ase.acs.main;

import ro.ase.acs.simplefactory.ApiType;
import ro.ase.acs.simplefactory.RestApi;
import ro.ase.acs.simplefactory.RestApiFactory;
import ro.ase.acs.simplefactory.RestApiFactoryV2;
import ro.ase.acs.singleton.Logger;
import ro.ase.acs.singleton.LoggerV2;
import ro.ase.acs.singleton.LoggerV3;

public class Main {
    public static void main(String[] args) {
        Logger logger = Logger.getInstance();
        logger.log("Hello World!");

        LoggerV2 loggerV2 = LoggerV2.instance;
        loggerV2.log("10PLM");

        LoggerV3 loggerV3 = LoggerV3.INSTANCE;
        loggerV3.log("Miau ^_^ <3");

        RestApiFactory factory = new RestApiFactory();
        RestApi api = factory.getRestApi(RestApiFactory.PRODUCTION);
        api.connect();

        RestApiFactoryV2 factory2 = new RestApiFactoryV2();
        api = factory2.getRestApi(ApiType.DEV);
        if (api != null) api.connect();
    }
}