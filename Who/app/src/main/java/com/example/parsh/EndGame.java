package com.example.parsh;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;

public class EndGame extends AppCompatActivity implements View.OnClickListener{

    ImageButton bMusic;
    TextView tWin;
    TextView tLose;
    TextView tPrize;

    public static final String ENDGAME_WIN = "WIN";
    public static final String ENDGAME_LOSE = "LOSE";
    public static final String ENDGAME_PRIZE = "PRIZE";

    public static String gain = "0";
    public static Boolean win = false;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_end_game);
        bMusic = (ImageButton)findViewById(R.id.bMusic);
        tWin = (TextView)findViewById(R.id.tWin);
        tLose = (TextView)findViewById(R.id.tLose);
        tPrize = (TextView)findViewById(R.id.tPrize);
        tWin = (TextView)findViewById(R.id.tWin);
        tWin.setVisibility(View.INVISIBLE);
        tLose = (TextView)findViewById(R.id.tLose);
        tLose.setVisibility(View.INVISIBLE);
        sheckWin();
        SetLanguage();
        sheckMusic();
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.bHome:
                Intent intent = new Intent();
                setResult(RESULT_OK, intent);
                stopService(new Intent(this, MyService.class));
                finish();
                break;
            case R.id.bMusic:
                SharedPreferences.Editor prefEditor = MainActivity.settings.edit();
                prefEditor.putBoolean(MainActivity.APP_MUSIC, !MainActivity.settings.getBoolean(MainActivity.APP_MUSIC, true));
                prefEditor.apply();
                sheckMusic();
                break;
        }
    }
    void sheckWin()
    {
        if(win)
        {
            tWin.setVisibility(View.VISIBLE);
        }else
            tLose.setVisibility(View.VISIBLE);
    }

    void sheckMusic()
    {
        if(MainActivity.settings.getBoolean(MainActivity.APP_MUSIC,true))bMusic.setImageResource(R.drawable.music);
        else
            bMusic.setImageResource(R.drawable.no_music);
    }
    void SetLanguage()
    {
        setTitle(MainActivity.settings.getString(MainActivity.APP_TITLE, "Кто хочет стать миллионером"));
        tWin.setText(MainActivity.settings.getString(ENDGAME_WIN,"Поздравляю вы победили"));
        tLose.setText(MainActivity.settings.getString(ENDGAME_LOSE,"Вы проиграли =("));
        tPrize.setText(MainActivity.settings.getString(ENDGAME_PRIZE,"Ваш выигрыш") +"  "+ gain+ " .");
    }
}
