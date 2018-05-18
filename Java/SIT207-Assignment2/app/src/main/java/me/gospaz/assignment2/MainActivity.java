//Matt McInnes
//214119048
//SIT207
//Assignment 2
package me.gospaz.assignment2;

import android.app.AlertDialog;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.provider.ContactsContract;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;

import java.util.List;



public class MainActivity extends ActionBarActivity {
    public static final String MyPREFERENCES = "MyPrefs" ;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //First run
        SharedPreferences sharedpreferences = getSharedPreferences(MyPREFERENCES, Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedpreferences.edit();
        //editor.clear();
        String firstRunString = sharedpreferences.getString("firstRun", null);
        if (firstRunString == "firstRun") {
            editor.putString("firstRun", "firstRun");
            editor.commit();
            Intent profileSetupActivity = new Intent(getApplicationContext(), ProfileSetupActivity.class);
            startActivity(profileSetupActivity);
        }

//
        //Setup buttons
        Button assInfoBtn = (Button)findViewById(R.id.assInfoBtn);
        assInfoBtn.setOnClickListener(assignmentListener); // Register the onClick listener with the implementation

        Button groupMembers = (Button)findViewById(R.id.groupBtn);
        assInfoBtn.setOnClickListener(groupListener);

        Button feedbackButton = (Button)findViewById(R.id.feedbackBtn);
        feedbackButton.setOnClickListener(feedbackListener);

        Button aboutBtn = (Button)findViewById(R.id.aboutBtn);
        feedbackButton.setOnClickListener(aboutListener);

        Button newProfileBtn = (Button)findViewById(R.id.newProfileBtn);
        feedbackButton.setOnClickListener(profileListener);




    }

//Create an anonymous implementation of OnClickListener
private View.OnClickListener assignmentListener = new View.OnClickListener() {
    public void onClick(View v) {
        Intent assInfoIntent = new Intent(getApplicationContext(), AssignmentActivity.class);
        startActivity(assInfoIntent);
    }
};
    private View.OnClickListener profileListener = new View.OnClickListener() {
        public void onClick(View v) {
            Intent newProfileIntent = new Intent(getApplicationContext(), ProfileSetupActivity.class);
            startActivity(newProfileIntent);
        }
    };
    private View.OnClickListener groupListener = new View.OnClickListener() {
        public void onClick(View v) {
            Intent groupIntent = new Intent(getApplicationContext(), MyGroupActivity.class);
            startActivity(groupIntent);
        }
    };
    private View.OnClickListener feedbackListener = new View.OnClickListener() {
        public void onClick(View v) {
            Intent feedbackIntent = new Intent(getApplicationContext(), FeedbackActivity.class);
            startActivity(feedbackIntent);
        }
    };

    private View.OnClickListener aboutListener = new View.OnClickListener() {
        public void onClick(View v) {
            Intent aboutIntent = new Intent(getApplicationContext(), AboutActivity.class);
            startActivity(aboutIntent);
        }
    };

    DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
        @Override
        public void onClick(DialogInterface dialog, int which) {
            switch (which){
                case DialogInterface.BUTTON_POSITIVE:
                    addContact();
                    break;

                case DialogInterface.BUTTON_NEGATIVE:
                    //No button clicked
                    break;
            }
        }
    };

    void confirmContactAdd(){
        AlertDialog.Builder builder = new AlertDialog.Builder(this.getApplicationContext());
        builder.setMessage("Are you sure?").setPositiveButton("Yes", dialogClickListener)
                .setNegativeButton("No", dialogClickListener).show();
    }
    void addContact() {

       DatabaseHandler db = new DatabaseHandler(this);

       // Create a string array for the result
       List<Profile> profiles = db.getAllProfiles();
//add all profiles to phone book using api
       for (Profile cn : profiles) {

           ContentValues values = new ContentValues();
           values.put(ContactsContract.Data.RAW_CONTACT_ID, 001);
           values.put(ContactsContract.Data.MIMETYPE, ContactsContract.CommonDataKinds.Phone.CONTENT_ITEM_TYPE);
           values.put(ContactsContract.CommonDataKinds.Phone.NUMBER, cn.get_studentNumber());
           values.put(ContactsContract.CommonDataKinds.Phone.TYPE, ContactsContract.CommonDataKinds.Phone.TYPE_CUSTOM);
           values.put(ContactsContract.CommonDataKinds.Phone.DISPLAY_NAME, cn.getName());
           Uri dataUri = getContentResolver().insert(android.provider.ContactsContract.Data.CONTENT_URI, values);       }

        db.close();

    };

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
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
            addContact();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
