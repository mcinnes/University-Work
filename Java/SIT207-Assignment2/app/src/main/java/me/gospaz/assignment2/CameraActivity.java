//Matt McInnes
//214119048
//SIT207
//Assignment 2
package me.gospaz.assignment2;

import android.app.Activity;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.net.Uri;
import android.os.Environment;
import android.provider.MediaStore;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.List;


public class CameraActivity extends ActionBarActivity implements View.OnClickListener {

    private static final int REQUEST_CODE = 1;
    private Bitmap bitmap;
    private ImageView imageView;
    private String studentNumber = "";
    private Button saveBtn;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_camera);
        Intent cameraIntent = getIntent();
        String sn = cameraIntent.getStringExtra("sn");
        Log.i("sn: ", sn);
        studentNumber = sn;

        saveBtn = (Button) findViewById(R.id.saveBtn);
        saveBtn.setOnClickListener(saveListener);


        imageView = (ImageView) findViewById(R.id.result);
        Intent intent = new Intent();
        intent.setType("image/*");
        intent.setAction(Intent.ACTION_GET_CONTENT);
        intent.addCategory(Intent.CATEGORY_OPENABLE);
        startActivityForResult(intent, REQUEST_CODE);
    }
private View.OnClickListener saveListener = new View.OnClickListener() {
    public void onClick(View v) {

    }
};
    public void onClick(View View) {
        Intent intent = new Intent();
        intent.setType("image/*");
        intent.setAction(Intent.ACTION_GET_CONTENT);
        intent.addCategory(Intent.CATEGORY_OPENABLE);
        startActivityForResult(intent, REQUEST_CODE);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        InputStream stream = null;
        if (requestCode == REQUEST_CODE && resultCode == Activity.RESULT_OK)
            try {
                // recyle unused bitmaps
                if (bitmap != null) {
                    bitmap.recycle();
                }
                stream = getContentResolver().openInputStream(data.getData());
                bitmap = BitmapFactory.decodeStream(stream);

                imageView.setImageBitmap(bitmap);

                saveToSD();
//return to main menu
                Intent mainIntent = new Intent(getApplicationContext(), MainActivity.class);
                startActivity(mainIntent);

            } catch (FileNotFoundException e) {
                e.printStackTrace();
            } ;
        }


    //Aditya Gupta http://stackoverflow.com/questions/20371803/saving-image-from-image-view-to-sd-card-android
    void saveToSD() {
        try
        {
            BitmapDrawable btmpDr = (BitmapDrawable) imageView.getDrawable();
            Bitmap bmp = btmpDr.getBitmap();
//set directory
            File sdCardDirectory = new File(Environment.getExternalStorageDirectory() + File.separator + "assignment2");
            sdCardDirectory.mkdirs();
//set image name
           String imageNameForSDCard = studentNumber + ".jpg";

            File image = new File(sdCardDirectory, imageNameForSDCard);
            FileOutputStream outStream;
//save file to sdcard
            outStream = new FileOutputStream(image);
            bmp.compress(Bitmap.CompressFormat.JPEG, 100, outStream);
    /* 100 to keep full quality of the image */
            outStream.flush();
            outStream.close();



            //Refreshing SD card
            sendBroadcast(new Intent(Intent.ACTION_MEDIA_MOUNTED, Uri.parse("file://"+ Environment.getExternalStorageDirectory())));
        }
        catch (Exception e)
        {
            e.printStackTrace();

        }
    }



}