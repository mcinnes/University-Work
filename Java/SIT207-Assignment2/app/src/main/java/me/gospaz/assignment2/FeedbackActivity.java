//Matt McInnes
//214119048
//SIT207
//Assignment 2
package me.gospaz.assignment2;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.RatingBar;
import android.widget.TextView;

import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicHeader;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;
import org.apache.http.protocol.HTTP;
import org.apache.http.util.EntityUtils;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;


public class FeedbackActivity extends ActionBarActivity {
    TextView title;
    TextView studentNumber;
    TextView message;
    Button submitBtn;
    RatingBar ratingBar;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_feedback);

        title = (TextView) findViewById(R.id.titleBox);
        studentNumber = (TextView) findViewById(R.id.studentNumberBox);
        message = (TextView) findViewById(R.id.messageBox);
        ratingBar = (RatingBar) findViewById(R.id.ratingBar);

        submitBtn = (Button) findViewById(R.id.submitButton);
       // submitBtn.setOnClickListener(submitListener);
    }

    private View.OnClickListener submitListener = new View.OnClickListener() {
        public void onClick(View v) {
            String titleString;
            String studentNumberString;
            String messageString;

            titleString= title.toString();
            studentNumberString = studentNumber.toString();
            messageString = message.toString();
//create json object
            JSONObject json = new JSONObject();
//add data to json object
            try {
                json.put("title", titleString);
                json.put("studentNumber", studentNumberString);
                json.put("message", messageString);
                json.put("rating", String.valueOf(ratingBar.getRating()));
            } catch (JSONException e) {
                e.printStackTrace();
            }
//post data to server
            sendFeedback("http://gospaz.me/getFeedback.php", json);
        }
    };

    public void sendFeedback(String url,JSONObject obj) {
        // Create a new HttpClient and Post Header

        HttpParams myParams = new BasicHttpParams();
        HttpConnectionParams.setConnectionTimeout(myParams, 10000);
        HttpConnectionParams.setSoTimeout(myParams, 10000);
        HttpClient httpclient = new DefaultHttpClient(myParams );
        String json=obj.toString();

        try {
//post json file using html
            HttpPost httppost = new HttpPost(url.toString());
            httppost.setHeader("Content-type", "application/json");

            StringEntity se = new StringEntity(obj.toString());
            se.setContentEncoding(new BasicHeader(HTTP.CONTENT_TYPE, "application/json"));
            httppost.setEntity(se);

            HttpResponse response = httpclient.execute(httppost);
            String temp = EntityUtils.toString(response.getEntity());
            Log.i("tag", temp);


        } catch (ClientProtocolException e) {

        } catch (IOException e) {

        }
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_feedback, menu);
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
