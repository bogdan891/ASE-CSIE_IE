package ro.ase.acs.factorymethod.contracts;

public interface AbstractDocumentFactory {
    Document createDocument(DocumentType documentType, String title);
}
