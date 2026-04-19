package ro.ase.acs.task3;

import java.util.HashMap;
import java.util.Map;

public class ColectieModul {
    protected Map<String, ModulSupravietuire> colectie = new HashMap<>();

    public ColectieModul() {
        colectie.put("MODUL_SUPRAVIETUIRE", new ModulCercetare());
    }

    public ModulSupravietuire getModul(String key) throws CloneNotSupportedException {
        try {
            return (ModulSupravietuire) colectie.get(key).clone();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }
}
