//Matt McInnes
//214119048
//SIT207
//Assignment 2
package me.gospaz.assignment2;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Environment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.io.File;
import java.util.List;

/**
 */
public class MyGroupListAdapter extends ArrayAdapter {
    private final Context context;
    private final String[] values;
    private final String[] profilePics;

    // Constructor which is called when the custom adapter is created
    public MyGroupListAdapter(Context context, String[] values, String[] profilePics) {
        // Select the layout for the cell
        super(context, R.layout.list_row_layout, values);
        this.context = context;
        this.values = values;
        this.profilePics = profilePics;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater)
                context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View rowView = inflater.inflate(R.layout.list_row_layout, parent, false);

        // Link the widgets on the layout with the Java codes
        TextView textView = (TextView) rowView.findViewById(R.id.listLabel);
        ImageView imageView = (ImageView) rowView.findViewById(R.id.listIcon);

        // Set the content of the text based on the values string in the main activity
        textView.setText(values[position]);

        // Change the icon for items of specific position
        //imageView.setImageResource(R.drawable.champion);
        File sdCardDirectory = new File(Environment.getExternalStorageDirectory() + File.separator + "assignment2");

        //get image file off sdcard

        File imgFile = new File(sdCardDirectory + profilePics[position]);
        if(imgFile.exists()){

            Bitmap myBitmap = BitmapFactory.decodeFile(imgFile.getAbsolutePath());
//draw image into imageView
           imageView.setImageBitmap(myBitmap);

        }
        return rowView;
        //return rowView;
    }
}