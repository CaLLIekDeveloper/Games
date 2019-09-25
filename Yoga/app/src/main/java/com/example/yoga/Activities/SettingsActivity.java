package com.example.yoga.Activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.SeekBar;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import com.example.yoga.Classes.Globals;
import com.example.yoga.R;

import java.util.Locale;


public class SettingsActivity extends AppCompatActivity {
    String [] SPINNERLIST = {"Русский","English"};
    Spinner spinner;
    SeekBar seekBar;
    TextView tvTime;

    @Override
    protected  void onStart()
    {
        super.onStart();

        if(Globals.Language==0)ChangeLanguage(0);
        else
            ChangeLanguage(1);

        tvTime.setText(""+ Globals.TimeOfGame);
        seekBar.setProgress(Globals.TimeOfGame-1);

        if(Globals.Language==1)
        if(spinner.getSelectedItem().toString().equals(SPINNERLIST[0]))
        {
            spinner.setSelection(1);
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);


        tvTime = findViewById(R.id.tvTime);

        spinner = findViewById(R.id.spinner);
        seekBar = findViewById(R.id.seekBar);

        spinner.getBackground().setColorFilter(0xFFFFFFFF, PorterDuff.Mode.SRC_ATOP);
        //((TextView) spinner.getSelectedView()).setTextColor(Color.BLACK);
        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener(){
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                ((TextView) spinner.getSelectedView()).setTextColor(Color.BLACK);
                int prevLang = Globals.Language;
                if(parent.getSelectedItem().toString().equals(SPINNERLIST[0]))
                {
                    Globals.Language = 0;
                    SaveText();
                    ChangeLanguage(0);
                }
                if(parent.getSelectedItem().toString().equals(SPINNERLIST[1]))
                {
                    Globals.Language = 1;
                    SaveText();
                    ChangeLanguage(1);
                }
            }
            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });


        seekBar.setOnSeekBarChangeListener(
                new SeekBar.OnSeekBarChangeListener() {
                    int progress_value;
                    @Override
                    public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                        TextView text2 = (TextView)findViewById(R.id.tvTime);
                        text2.setText(Integer.toString(progress+1));
                        progress_value = progress;
                        SaveText();
                    }

                    @Override
                    public void onStartTrackingTouch(SeekBar seekBar) {

                    }

                    @Override
                    public void onStopTrackingTouch(SeekBar seekBar) {
                        SaveText();
                    }
                }
        );
    }
    private void ChangeLanguage(int flag) {
        Locale locale;
        if(flag==0) {
            locale = new Locale("ru");

        }else
        {
            locale = new Locale("en");
        }
        Locale.setDefault(locale);
        Configuration config = new Configuration();
        config.locale = locale;
        getBaseContext().getResources().updateConfiguration(config, null);
    }

    // Сохраняю настройки пользователя
    void SaveText()
    {
        SharedPreferences.Editor ed = Globals.sPref.edit();
        ed.putString(Globals.SAVED_TIME, String.valueOf(seekBar.getProgress()+1));
        ed.putInt(Globals.SAVED_LANGUAGE, Globals.Language);
        ed.commit();
        Globals.TimeOfGame = seekBar.getProgress()+1;
    }
    /*
    // Загружаю данные из предпочтений
    void loadText() {
        Log.e("ЗАГРУЖАЮ","loadtext");
        Globals.sPref = getPreferences(MODE_PRIVATE);
        Globals.TimeOfGame = Integer.parseInt(Globals.sPref.getString(Globals.SAVED_TIME,"5"));
        seekBar.setProgress(Globals.TimeOfGame-1);
        tvTime.setText(""+Globals.TimeOfGame);
        Globals.Language = Integer.parseInt(Globals.sPref.getString(Globals.SAVED_LANGUAGE, "0"));
        Log.e("ЗАГРУЖАЮ", String.valueOf(Globals.Language));
        spinner.setSelection(Globals.Language);
    }
    */

    private void OpenActivityGame()
    {
        Intent intent_fac = new Intent(this, GameActivity.class);
        startActivity(intent_fac);
    }

    private void OpenActivityHighscores()
    {
        Intent intent_fac = new Intent(this, HighscoresActivity.class);
        startActivity(intent_fac);
    }

    private void OpenActivitySettings()
    {
        Intent intent_fac = new Intent(this, SettingsActivity.class);
        startActivity(intent_fac);
    }

    private void OpenActivityMainMenu()
    {
        Intent intent_fac = new Intent(this, MainActivity.class);
        startActivity(intent_fac);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_game, menu);
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
            OpenActivitySettings();
        }

        if (id == R.id.mmNew_Game) {
            OpenActivityGame();
        }

        if (id == R.id.mmHighscores) {
            OpenActivityHighscores();
        }

        if(id == R.id.mmMainMenu){
            OpenActivityMainMenu();
        }
        return super.onOptionsItemSelected(item);
    }
}
