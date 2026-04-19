package ro.ase.acs.task3;

import java.util.HashMap;
import java.util.Map;

public class CartierCollection {
    protected Map<String, Cartier> collection = new HashMap<>();

    public CartierCollection() {
        collection.put("CARTIER_MODEL", new CartierModel());
    }

    public Cartier getCartier(String key) {
        try {
            return (Cartier) collection.get(key).clone();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }
}