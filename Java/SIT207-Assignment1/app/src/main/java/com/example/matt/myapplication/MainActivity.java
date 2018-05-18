package com.example.matt.myapplication;

import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.widget.Button;
import android.view.View;
import android.content.Intent;
public class MainActivity extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //set buttons and function
        final Button button = (Button) findViewById(R.id.newGameBtn);
        button.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                generateListDialog();
            }
        });


        Button aboutBtn = (Button) findViewById(R.id.aboutBtn);
        aboutBtn.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                startActivity(new Intent(getApplicationContext(), AboutScreen.class));
            }
        });
        Button exitBtn = (Button) findViewById(R.id.exitBtn);
        exitBtn.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                System.exit(0);
            }
        });


    }

    void generateListDialog () {
        //function to create difficulty menu
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        //set title
        builder.setTitle("Difficulty");
        //add items from array
        builder.setItems(R.array.difficulty, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                //when game is made different options will do different things
                //for now it opens the GameScreen class
                startActivity(new Intent(getApplicationContext(), GameScreen.class));
            }
        });
        //create and show
        AlertDialog dialog = builder.create();
        dialog.show();

    }
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
        if (id == R.id.action_reset) {
            //restarts the application
            Intent intent = getIntent();
            finish();
            startActivity(intent);

            return true;
        }
        if (id == R.id.action_exit) {
            finish();
            return true;
        }
        if (id == R.id.action_difficulty) {
            //cal function to create difficulty menu
            generateListDialog();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
