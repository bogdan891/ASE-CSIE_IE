package csie.ase.utils;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

import csie.ase.classes.*;

public class InputOutput {

    public static void serialize(String fileName, List<House> houses) {
        try (BufferedWriter out = new BufferedWriter(new FileWriter(fileName, true))) {
            for (House h : houses) {
                StringBuilder sb = new StringBuilder();
                sb.append(h.getId_house()).append(",");
                sb.append(h.getLocation()).append(",");
                sb.append(h.getAdmin_company()).append(",");

                List<Expense> expenses = h.getExpenses();
                for (int i = 0; i < expenses.size(); i++) {
                    sb.append(expenses.get(i).getType())
                      .append(":")
                      .append(expenses.get(i).getAmount());
                    if (i < expenses.size() - 1) {
                        sb.append(";");
                    }
                }
                out.write(sb.toString());
                out.newLine();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static List<House> deserialize(String fileName) {
        List<House> list = new ArrayList<>();
        try (BufferedReader in = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = in.readLine()) != null) {
                if (line.trim().isEmpty() || line.startsWith("#")) continue;

                String[] parts = line.split(",", 4); // 4 părți: id, location, company, expenses
                int id = Integer.parseInt(parts[0].trim());
                String location = parts[1].trim();
                String company = parts[2].trim();
                String[] expenseParts = parts[3].split(";");

                List<Expense> expenses = new ArrayList<>();
                for (String ep : expenseParts) {
                    String[] kv = ep.split(":");
                    if (kv.length == 2) {
                        expenses.add(new Expense(kv[0].trim(), Double.parseDouble(kv[1].trim())));
                    }
                }

                list.add(new House(id, location, company, expenses));
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return list;
    }

    public static void serializeExp(String fileName, List<Expense> expenses) {
        try (BufferedWriter out = new BufferedWriter(new FileWriter(fileName, true))) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < expenses.size(); i++) {
                sb.append(expenses.get(i).getType())
                  .append(":")
                  .append(expenses.get(i).getAmount());
                if (i < expenses.size() - 1) {
                    sb.append(";");
                }
            }
            out.write(sb.toString());
            out.newLine();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static List<Expense> deserializeExp(String fileName) {
        List<Expense> list = new ArrayList<>();
        try (BufferedReader in = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = in.readLine()) != null) {
                if (line.trim().isEmpty() || line.startsWith("#")) continue;

                String[] expenseParts = line.split(";");
                for (String ep : expenseParts) {
                    String[] kv = ep.split(":");
                    if (kv.length == 2) {
                        String type = kv[0].trim();
                        double amount = Double.parseDouble(kv[1].trim());
                        list.add(new Expense(type, amount));
                    }
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return list;
    }
}