package ro.ase.acs;

import java.util.HashMap;
import java.util.Map;

public class PhoneCollection {
    private Map<String, Phone> collection  = new HashMap<>();

    public PhoneCollection() {
        TestPhone standardTest = new TestPhone();
        collection.put("STANDARD_TEST", standardTest);
    }

    public Phone getPhone(String key) throws CloneNotSupportedException {
        return (Phone) collection.get(key).clone();
    }
}
