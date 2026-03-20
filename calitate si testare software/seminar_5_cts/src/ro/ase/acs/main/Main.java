package ro.ase.acs.main;

import ro.ase.acs.factorymethod.contracts.AbstractDocumentFactory;
import ro.ase.acs.factorymethod.contracts.Document;
import ro.ase.acs.factorymethod.google.GoogleDocumentFactory;
import ro.ase.acs.factorymethod.microsoft.MicrosoftDocumentFactory;
import ro.ase.acs.factorymethod.contracts.DocumentType;
import ro.ase.acs.singletonregistry.SingletonRegistry;
import ro.ase.acs.singletonregistry.SingletonRegistry.Logger;
import ro.ase.acs.singletonregistry.SingletonRegistry.DatabaseConnection;

public class Main {
    public static void main(String[] args) {
        SingletonRegistry singletonRegistry = new SingletonRegistry();
        Logger logger = (Logger) singletonRegistry.getSingleton(Logger.class.getSimpleName());
        logger.log("Hello World!");

        DatabaseConnection databaseConnection = (DatabaseConnection) singletonRegistry.getSingleton(DatabaseConnection.class.getSimpleName());
        databaseConnection.connect();

        AbstractDocumentFactory documentFactory = new MicrosoftDocumentFactory();
        Document documentMS = documentFactory.createDocument(DocumentType.SPREADSHEET, "untitled");
        documentMS.open();

        documentFactory = new GoogleDocumentFactory();
        Document documentGoogle = documentFactory.createDocument(DocumentType.PRESENTATION, "presentation");
        documentGoogle.open();
    }
}