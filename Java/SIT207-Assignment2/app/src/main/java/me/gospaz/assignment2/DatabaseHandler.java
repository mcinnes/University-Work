//Matt McInnes
//214119048
//SIT207
//Assignment 2
package me.gospaz.assignment2;

/**
 * Created by matt on 30/09/2015.
 */

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;


import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import java.util.ArrayList;
import java.util.List;

public class DatabaseHandler extends SQLiteOpenHelper {

    // All Static variables
    // Database Version
    private static final int DATABASE_VERSION = 11;

    // Database Name
    private static final String DATABASE_NAME = "profiles";

    // Profiles table name
    private static final String TABLE_PROFILES = "profiles";

    /* Profiles Table Columns names */
    private static final String KEY_ID = "id";
    private static final String KEY_NAME = "name";
    private static final String KEY_STUDENTNUMBER = "studentNumber";
    private static final String KEY_PROFILEPICURL = "profilePicURL";
    private static final String KEY_COURSECODE = "courseCode";


    public DatabaseHandler(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    // Creating Tables
    @Override
    public void onCreate(SQLiteDatabase db) {
        String CREATE_PROFILES_TABLE = "CREATE TABLE " + TABLE_PROFILES + "("
                + KEY_ID + " INTEGER PRIMARY KEY," + KEY_NAME + " TEXT,"
                + KEY_STUDENTNUMBER + " TEXT," +  KEY_PROFILEPICURL + " TEXT," + KEY_COURSECODE + " TEXT" + ")";
        Log.i("strign", CREATE_PROFILES_TABLE);
        db.execSQL(CREATE_PROFILES_TABLE);

       // db.execSQL("CREATE TABLE IF NOT EXISTS " + TABLE_PROFILES + " (id INTEGER PRIMARY KEY, name TEXT, studentNumber INT(9), profilePicURL TEXT, courseCode TEXT");
        Log.i("db", "db creataed");
    }

    // Upgrading database
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // Drop older table if existed
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_PROFILES);
        Log.i("db", "db dropped");

        // Create tables again
        onCreate(db);
    }

    /**
     * All CRUD(Create, Read, Update, Delete) Operations
     */

    // Adding new profile
    void addProfile(Profile profile) {
        SQLiteDatabase db = this.getWritableDatabase();

        ContentValues values = new ContentValues();
        values.put(KEY_NAME, profile.getName()); // Profile Name
        values.put(KEY_STUDENTNUMBER, profile.get_studentNumber()); // Profile Phone
        values.put(KEY_PROFILEPICURL, profile.get_profilePicURL()); // Profile Phone
        values.put(KEY_COURSECODE, profile.get_courseCode()); // Profile Phone

        // Inserting Row
        db.insert(TABLE_PROFILES, null, values);
        db.close(); // Closing database connection
    }

    // Getting single profile
    Profile getProfile(int id) {
        SQLiteDatabase db = this.getReadableDatabase();

        Cursor cursor = db.query(TABLE_PROFILES, new String[] { KEY_ID,
                        KEY_NAME }, KEY_ID + "=?",
                new String[] { String.valueOf(id) }, null, null, null, null);
        if (cursor != null)
            cursor.moveToFirst();

        Profile profile = new Profile(Integer.parseInt(cursor.getString(0)),
                cursor.getString(1),cursor.getString(2),cursor.getString(3),cursor.getString(4));
        // return profile
        return profile;
    }

    // Getting All Profiles
    public List<Profile> getAllProfiles() {
        List<Profile> profileList = new ArrayList<Profile>();
        // Select All Query
        String selectQuery = "SELECT  * FROM " + TABLE_PROFILES + " ORDER BY " + KEY_STUDENTNUMBER + " DESC";

        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);

        // looping through all rows and adding to list
        if (cursor.moveToFirst()) {
            do {
                Profile profile = new Profile();
                profile.setID(Integer.parseInt(cursor.getString(0)));
                profile.setName(cursor.getString(1));
                profile.set_studentNumber(cursor.getString(2));
                profile.set_profilePicURL(cursor.getString(3));
                profile.set_profilePicURL(cursor.getString(4));

                // Adding profile to list
                profileList.add(profile);
            } while (cursor.moveToNext());
        }

        // return profile list
        return profileList;
    }

    // Updating single profile
    public int updateProfile(Profile profile) {
        SQLiteDatabase db = this.getWritableDatabase();

        ContentValues values = new ContentValues();
        values.put(KEY_PROFILEPICURL, profile.get_profilePicURL()); // Profile Phone

        // updating row
        return db.update(TABLE_PROFILES, values, KEY_STUDENTNUMBER + " = ?",
                new String[] { String.valueOf(profile.get_studentNumber()) });
    }

    // Deleting single profile
    public void deleteProfile(Profile profile) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_PROFILES, KEY_ID + " = ?",
                new String[] { String.valueOf(profile.getID()) });
        db.close();
    }


    // Getting profiles Count
    public int getProfilesCount() {
        String countQuery = "SELECT  * FROM " + TABLE_PROFILES;
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery(countQuery, null);
        cursor.close();

        // return count
        return cursor.getCount();
    }

}

