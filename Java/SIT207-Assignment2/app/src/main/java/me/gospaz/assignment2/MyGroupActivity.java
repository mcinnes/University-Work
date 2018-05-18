//Matt McInnes
//214119048
//SIT207
//Assignment 2
package me.gospaz.assignment2;

import android.app.ActionBar;
import android.app.ListActivity;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;

import java.util.ArrayList;
import java.util.List;


public class MyGroupActivity extends ListActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my_group);

        DatabaseHandler db = new DatabaseHandler(this);

        // Create a string array for the result
        List<Profile> profiles = db.getAllProfiles();

        ArrayList<String> profileList = new ArrayList<String>();

        for (Profile cn : profiles) {
            String log = "Name: " + cn.getName() + ", Student Number: " + cn.get_studentNumber();
            profileList.add(log);
        }
        db.close(); //close database connection

//load profile strings for list view
        String[] profileListStrings = new String[ profileList.size() ];

        for( int j = 0; j < profileListStrings.length; j++ ) {

            profileListStrings[j] = profileList.get(j).toString();
            Log.i("pls" + j, profileListStrings[j]);
        }

        ArrayList<String> profilePicList = new ArrayList<String>();

        for (Profile cn : profiles) {
            String url = cn.get_studentNumber();
            profilePicList.add(url);
        }
//picture array
        String[] profilePictures = new String[ profilePicList.size() ];

        for( int j = 0; j < profilePictures.length; j++ ) {

            profilePictures[j] = profilePicList.get(j).toString();
        }

        String[] values = profileListStrings;
        String[] profilePics = profilePictures; MyGroupListAdapter adapter = new MyGroupListAdapter(this, values, profilePics);
        setListAdapter(adapter);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_my_group, menu);
        return true;
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
