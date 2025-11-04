package csie.ase.utils;

import csie.ase.classes.*;

public class CSV {
	public static String toCSV(Bus b) {

        StringBuilder sb = new StringBuilder();
        sb.append(b.getManufacturer()).append(",");
        sb.append(b.getPlate()).append(",");
        sb.append(b.getEngineFuel()).append(",");
        sb.append(b.getModel()).append(",");
        sb.append(b.getRoute()).append(",");
        sb.append(b.getIdRoute()).append(",");
        sb.append(b.getNbOfStops()).append(",");
        for (int i = 0; i < b.getNbOfStops(); i++) {
            sb.append(b.getTimeBetweenStops()[i]);
            if (i < b.getNbOfStops() - 1)
                sb.append(";");
        }

        return sb.toString();
    }

    public static Bus fromCSV(String csv) {

        String[] parts = csv.split(",", 8);
        String manufacturer = parts[0];
        String plate = parts[1];
        FuelType fuel = FuelType.valueOf(parts[2]);
        String model = parts[3];
        String route = parts[4];
        int idRoute = Integer.parseInt(parts[5]);
        int nbOfStops = Integer.parseInt(parts[6]);
        String[] timesStr = parts[7].split(";");
        float[] times = new float[timesStr.length];
        for (int i = 0; i < times.length; i++) {
            times[i] = Float.parseFloat(timesStr[i]);
        }

        return new Bus(manufacturer, plate, fuel, model, route, idRoute, nbOfStops, times);
    }
}
