package com.example.yoga.Classes;

import android.database.Cursor;

public class StructDB {
    public int id;
    public String date;
    public String name;
    public int fullTime;
    public int gameTime;
    public int chips;


    public void getStructDB(Cursor userCursor)
    {
        id = userCursor
                .getInt(userCursor.getColumnIndex("id"));
        date = userCursor.getString(userCursor
                .getColumnIndex("date"));
        name = userCursor.getString(userCursor
                .getColumnIndex("name"));
        fullTime = userCursor
                .getInt(userCursor.getColumnIndex("fullTime"));
        gameTime = userCursor
                .getInt(userCursor.getColumnIndex("gameTime"));
        chips = userCursor
                .getInt(userCursor.getColumnIndex("chips"));
    }
}
