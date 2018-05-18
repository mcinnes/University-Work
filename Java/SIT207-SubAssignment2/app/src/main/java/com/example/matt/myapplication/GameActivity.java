package com.example.matt.myapplication;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.v7.app.ActionBarActivity;
import android.util.DisplayMetrics;
import android.view.Display;
import android.view.Menu;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.WindowManager;


import java.util.Random;
import java.util.Timer;
import java.util.TimerTask;



public class GameActivity extends ActionBarActivity {

    // width of the game table
    private int tableWidth;
    // height of the game table
    private int tableHeight;
    // location of the racket in Y axis
    private int racketY;
    // height and width of the racket
    private int RACKET_HEIGHT = 20;
    private int RACKET_WIDTH = 130;
    // size of the ball

    private int BALL_SIZE = 50;
    // Moving speed of the ball in y axis
    private int ySpeed = global.difficulty;
    // A random number
    Random rand = new Random();
    // Return a value with [-0.5,0.5], which is used to control the moving direction of the ball
    // rand.nextDouble() generate a number between 0 and 1
    private double xyRate = rand.nextDouble() - 0.5;
    // The speed that the ball moves in the x axis
    private int xSpeed = (int) (ySpeed * xyRate * 2);
    // Location of the ball in the x, y axis
    // rand.nextInt(n) returns a pseudo-random uniformly distributed int in the half-open range [0, n).
    private int ballX = rand.nextInt(200) + 20;
    private int ballY = rand.nextInt(10) + 20;
    // location of the racket in the x axis
    private int racketX = rand.nextInt(200);
    // if the game is over or not
    private boolean isLose = false;

    // Define a variable to track the game time
    private long initialTime;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // Remove the window title
        //requestWindowFeature(Window.FEATURE_NO_TITLE);
        // Make the game full screen
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        // Create a new object from the GameView class
        // The GameView class is defined later as an inner class. It defines the method to draw the ball and racket.
        final GameView gameView = new GameView(this);
        // Apply the gameView object for the activity
        setContentView(gameView);
        // Access the window manager to retrieve the dimensions window.
        WindowManager windowManager = getWindowManager();
        Display display = windowManager.getDefaultDisplay();
        DisplayMetrics metrics = new DisplayMetrics();
        display.getMetrics(metrics);
        // Set the width and height of the game table to the screen size
        tableWidth = metrics.widthPixels;
        tableHeight = metrics.heightPixels;
        racketY = (int) (tableHeight*0.85);

        // Read the time when the game starts
        initialTime = System.currentTimeMillis();

        // Launch a new thread for game
        final Handler handler = new Handler()
        {
            public void handleMessage(Message msg)
            {
                if (msg.what == 0x123)
                {
                    // call invalidate() method of the view class to draw the view object
                    gameView.invalidate();
                }
            }
        };

        final Timer timer = new Timer();
        timer.schedule(new TimerTask()
        {

            @Override
            public void run()
            {
                // If the ball hits the table on the left, change the direction of the ball
                if (ballX <= 0 || ballX >= tableWidth - BALL_SIZE)
                {
                    xSpeed = -xSpeed;
                }
                // If ball hits the bottom and is outside the racket, then stop the game
                if (ballY >= racketY - BALL_SIZE
                        && (ballX < racketX || ballX > racketX
                        + RACKET_WIDTH))
                {
                    timer.cancel();
                    // Set the tag to be true which indicates that the game is over
                    isLose = true;
                }
                // If the ball hits the racket, then change the direction of the ball
                else if (ballY <= 0
                        || (ballY >= racketY - BALL_SIZE
                        && ballX > racketX && ballX <= racketX
                        + RACKET_WIDTH))
                {
                    ySpeed = -ySpeed;
                }
                // update the location of the ball
                ballY += ySpeed;
                ballX += xSpeed;
                // Send the message to handler to draw the gameView object
                handler.sendEmptyMessage(0x123);
            }
        }, 0, 100);
    }

    // Create a new class extended from the View class
    class GameView extends View
    {
        Paint paint = new Paint();

        // Constructor
        public GameView(Context context)
        {
            super(context);
            setFocusable(true);
        }

        // Override the onDraw method of the View class to configure
        public void onDraw(Canvas canvas)
        {
            // Configure the paint which will be used to draw the view
            paint.setStyle(Paint.Style.FILL);
            paint.setAntiAlias(true);
            // If the game is over
            if (isLose) {
                paint.setColor(Color.RED);
                paint.setTextSize(20);

                // Get the time spent in the game
                final long[] timeSpent = {System.currentTimeMillis() - initialTime};
                timeSpent[0] = (long) (timeSpent[0] / 1000.0);

                SharedPreferences keyValues = getContext().getSharedPreferences("scores", Context.MODE_PRIVATE);
                SharedPreferences.Editor keyValuesEditor = keyValues.edit();
                String scores = keyValues.getString("scores", null);


                StringBuilder sb = new StringBuilder(scores);
                sb.append(",").append("Player1").append(" scored ").append(String.valueOf(timeSpent[0]));
                //}
                keyValuesEditor.putString("scores", sb.toString());
                keyValuesEditor.commit();


                AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(this.getContext());

                // set title
                alertDialogBuilder.setTitle("You Lose");

                // set dialog message
                alertDialogBuilder
                        .setMessage("Your time was " + String.valueOf(timeSpent[0]))
                        .setPositiveButton("Exit", new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                // if this button is clicked, close
                                // current activity
                                startActivity(new Intent(getApplicationContext(), ScoreActivity.class));

                            }
                        })
                        .setNegativeButton("Restart", new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                // if this button is clicked, just close
                                // the dialog box and do nothing
                                startActivity(new Intent(getApplicationContext(), MainActivity.class));

                            }
                        });

                // create alert dialog
                AlertDialog alertDialog = alertDialogBuilder.create();

                // show it
                alertDialog.show();


            }

            // Otherwise
            else
            {
                // set the color of the ball
                paint.setColor(Color.rgb(240, 240, 80));
                canvas.drawCircle(ballX, ballY, BALL_SIZE, paint);
                // set the color of the racket
                paint.setColor(Color.rgb(80, 80, 200));
                canvas.drawRect(racketX, racketY, racketX + RACKET_WIDTH,
                        racketY + RACKET_HEIGHT, paint);
            }
        }


        // Override the onTouchEvent method in the View class
        @Override
        public boolean onTouchEvent(MotionEvent event) {
            super.onTouchEvent(event);
            // Get the location of user's figure
            float x = event.getX();
            // Determine if the user's figure is on racket or not
            if (x > racketX && x < racketX + (RACKET_WIDTH * 2)) {
                // if yes, set the location of the racket to user's figure location so that the user can drag the racket
                racketX = (int) x - RACKET_WIDTH / 2;
                // draw the game view object
                invalidate();
            }
            return true;
        }
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
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}

