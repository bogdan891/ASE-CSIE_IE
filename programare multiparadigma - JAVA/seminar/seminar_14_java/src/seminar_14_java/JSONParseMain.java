package seminar_14_java;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class JSONParseMain {

	public static void main(String[] args) {
		writeJSONObject("testJSON.txt");
		readJSONObject("testJSON.txt");
	}
	
	private static void readJSONObject(String fileName) {
		String line = "";
		StringBuilder sb = new StringBuilder();
		try {
			BufferedReader br = new BufferedReader(new FileReader(fileName));
			while((line = br.readLine())!= null) {
				sb.append(line);
			}
			
			JSONObject object = new JSONObject(sb.toString());
			String name = (String) object.get("name");
			Integer age = (Integer) object.get("age");
			System.out.println("Name: " + name);
			System.out.println("Age: " + age);
			
			JSONArray kids = (JSONArray) object.get("kids");
			JSONObject kid1 = (JSONObject) kids.getJSONObject(0);
			
			System.out.println("Name of first child is: " + kid1.getString("name"));
			br.close();
		} catch (IOException | JSONException e) {
			e.printStackTrace();
		}
	}

	public static void writeJSONObject(String fileName) {
		try {
			JSONObject object = new JSONObject();
			object.put("name", "John");
			object.put("age", 28);
			
			JSONObject kid1 = new JSONObject();
			kid1.put("name", "Alice");
			JSONObject kid2 = new JSONObject();
			kid2.put("name", "George");
			
			object.append("kids", kid1);
			object.append("kids", kid2);
			
			System.out.println(object);
			
			FileWriter fw = new FileWriter(fileName);
			fw.write(object.toString());
			fw.close();
		} catch(JSONException | IOException e) {
			e.printStackTrace();
		}
	}

}
