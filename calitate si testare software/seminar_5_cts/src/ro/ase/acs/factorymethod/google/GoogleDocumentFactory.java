package ro.ase.acs.factorymethod.google;

import ro.ase.acs.factorymethod.contracts.AbstractDocumentFactory;
import ro.ase.acs.factorymethod.contracts.Document;
import ro.ase.acs.factorymethod.contracts.DocumentType;

public class GoogleDocumentFactory implements AbstractDocumentFactory {
    @Override
    public Document createDocument(DocumentType documentType, String title) {
            return switch (documentType) {
                case DocumentType.TEXT -> new GoogleDocsDocument(title);
                case DocumentType.SPREADSHEET -> new GoogleSheetsDocument(title);
                case DocumentType.PRESENTATION -> new GoogleSlidesDocument(title);
                default -> throw new IllegalArgumentException("Invalid document type");
            };
    }
}
