package com.example.matt.myapplication;

import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import org.json.JSONObject;
import org.json.JSONException;
import org.json.JSONArray;

public class GameScreen extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game_screen);


    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_game_screen, menu);
        return true;
    }

    public void saveScore(String name, Integer score){
        JSONObject newScore = new JSONObject();
        try {
            newScore.put("id", "3");
            newScore.put("name", name);
            newScore.put("score", score);
        } catch (JSONException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }


        JSONArray jsonArray = new JSONArray();

        jsonArray.put(newScore);

        JSONObject scoresOBJ = new JSONObject();
        try {
          scoresOBJ.put("Scores", jsonArray);
        } catch (JSONException e) {
               e.printStackTrace();
        }



        String jsonStr = scoresOBJ.toString();

        System.out.println("jsonString: "+jsonStr);

    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
