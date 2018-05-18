//Matt McInnes
//214119048
//SIT207
//Assignment 2
package me.gospaz.assignment2;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;


public class ProfileSetupActivity extends ActionBarActivity {
    TextView name;
    TextView studentNumber;
    TextView courseCode;
    Button submitBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile_setup);


        name = (TextView) findViewById(R.id.titleBox);
        studentNumber = (TextView) findViewById(R.id.studentNumberBox);
        courseCode = (TextView) findViewById(R.id.unitBox);

        submitBtn = (Button) findViewById(R.id.submitButton);
        submitBtn.setOnClickListener(submitListener); // Register the onClick listener with the implementation

    }
    private View.OnClickListener submitListener = new View.OnClickListener() {
        public void onClick(View v) {
            submit();
        }
    };
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_profile_setup, menu);
        return true;
    }

    void submit () {

//open database
       DatabaseHandler db = new DatabaseHandler(this);

        //save to database
        String combinedURL = studentNumber.getText().toString() + ".jpg";
        db.addProfile(new Profile(name.getText().toString(), studentNumber.getText().toString(),combinedURL, courseCode.getText().toString()));
//open camera activity to continue profile setup
        Intent cameraActivity = new Intent(getApplicationContext(), CameraActivity.class);
        //send studnetNumber to cameraactivity for filename
        cameraActivity.putExtra("sn", studentNumber.getText().toString());
        startActivity(cameraActivity);
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
