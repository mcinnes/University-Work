//Matt McInnes
//214119048
//SIT207
//Assignment 2
package me.gospaz.assignment2;

/**
 * Created by matt on 24/09/2015.
 */
public class Profile {

    //private variables
    int _id;
    String _name;
    String _studentNumber;
    String _profilePicURL;
    String _courseCode;

    // Empty constructor
    public Profile(){

    }
    // constructor
    public Profile(int id, String name, String _studentNumber, String _profilePicURL, String _courseCode){
        this._id = id;
        this._name = name;
        this._studentNumber = _studentNumber;
        this._profilePicURL = _profilePicURL;
        this._courseCode = _courseCode;
    }

    // constructor
    public Profile(String name, String _studentNumber, String _profilePicURL, String _courseCode){
        this._name = name;
        this._studentNumber = _studentNumber;
        this._profilePicURL = _profilePicURL;
        this._courseCode = _courseCode;
    }


    // setting id
    public void setID(int id){
        this._id = id;
    }
    // setting name
    public void setName(String name){
        this._name = name;
    }
    public void set_studentNumber(String studentNumber){
        this._studentNumber = studentNumber;
    }
    public void set_profilePicURL(String profilePicURL){
        this._profilePicURL = profilePicURL;
    }
    public void set_courseCode(String courseCode){
        this._courseCode = courseCode;
    }



    //Get
    // getting ID
    public int getID(){
        return this._id;
    }
    // getting name
    public String getName(){
        return this._name;
    }
    // getting phone number
    public String get_studentNumber(){
        return this._studentNumber;
    }
    public String get_profilePicURL(){
        return this._profilePicURL;
    }
    public String get_courseCode(){
        return this._courseCode;
    }

}