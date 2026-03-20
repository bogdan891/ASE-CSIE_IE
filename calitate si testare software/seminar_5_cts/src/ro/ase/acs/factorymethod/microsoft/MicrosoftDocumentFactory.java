package ro.ase.acs.factorymethod.microsoft;

import ro.ase.acs.factorymethod.contracts.DocumentType;
import ro.ase.acs.factorymethod.contracts.AbstractDocumentFactory;
import ro.ase.acs.factorymethod.contracts.Document;

public class MicrosoftDocumentFactory implements AbstractDocumentFactory {
    @Override
    public Document createDocument(DocumentType documentType, String title) {
        return switch (documentType) {
            case DocumentType.TEXT -> new WordDocument(title);
            case DocumentType.SPREADSHEET -> new ExcelDocument(title);
            case DocumentType.PRESENTATION -> new PowerPointDocument(title);
            default -> throw new IllegalArgumentException("Invalid document type");
        };
    }
}
