package com.example.parsh;

import android.content.SharedPreferences;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.SeekBar;
import android.widget.Spinner;
import android.widget.TextView;

public class Settings extends AppCompatActivity {

    public static final String  PREF_NAME = "strings.xml";
    private static final String SETTINGS_LANGUAGE = "SETTINGS_LANGUAGE";
    private static final String SETTINGS_TIME = "SETTINGS_TIME";
    public static final String SETTINGS_TIME_S = "SETTINGS_TIME_S";
    String [] SPINNERLIST = {"Русский","Украинский","English"};
    Spinner spinner;
    SeekBar seekBar;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings);


        spinner = (Spinner)findViewById(R.id.spinner);
        spinner.setSelection(MainActivity.settings.getInt(MainActivity.APP_LANG,0),false);
        spinner.getBackground().setColorFilter(0xFFFFFFFF, PorterDuff.Mode.SRC_ATOP);
        ((TextView) spinner.getSelectedView()).setTextColor(0xFFFFFFFF);
        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener(){
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

                ((TextView) spinner.getSelectedView()).setTextColor(0xFFFFFFFF);
                if(parent.getSelectedItem().toString().equals(SPINNERLIST[0]))
                {
                    SharedPreferences.Editor prefEditor = MainActivity.settings.edit();
                    prefEditor.putInt(MainActivity.APP_LANG,0);
                    prefEditor.putString(MainActivity.APP_TITLE,"Кто хочет стать миллионером");
                    prefEditor.putString(MainActivity.APP_NEW_GAME,"Новая игра");
                    prefEditor.putString(MainActivity.APP_SETTINGS, "Настройки");
                    prefEditor.putString(MainActivity.APP_EXIT, "Выход");
                    prefEditor.putString(SETTINGS_LANGUAGE, "Язык");
                    prefEditor.putString(SETTINGS_TIME, "Время:");
                    prefEditor.putString(EndGame.ENDGAME_WIN, "Поздравляю вы победили");
                    prefEditor.putString(EndGame.ENDGAME_LOSE, "Вы проиграли =(");
                    prefEditor.putString(EndGame.ENDGAME_PRIZE, "Ваш выигрыш");

                    prefEditor.apply();
                    ChangeLanguage();
                }
                if(parent.getSelectedItem().toString().equals(SPINNERLIST[1]))
                {
                    SharedPreferences.Editor prefEditor = MainActivity.settings.edit();
                    prefEditor.putInt(MainActivity.APP_LANG,1);
                    prefEditor.putString(MainActivity.APP_TITLE,"Хто хоче стати міліонером");
                    prefEditor.putString(MainActivity.APP_NEW_GAME,"Нова гра");
                    prefEditor.putString(MainActivity.APP_SETTINGS, "Налаштування");
                    prefEditor.putString(MainActivity.APP_EXIT, "Вихід");
                    prefEditor.putString(SETTINGS_LANGUAGE, "Мова");
                    prefEditor.putString(SETTINGS_TIME, "Час:");
                    prefEditor.putString(EndGame.ENDGAME_WIN, "Вітаю ви перемогли");
                    prefEditor.putString(EndGame.ENDGAME_LOSE, "Ви програли =(");
                    prefEditor.putString(EndGame.ENDGAME_PRIZE, "Ваш виграш");

                    prefEditor.apply();
                    ChangeLanguage();
                }
                if(parent.getSelectedItem().toString().equals(SPINNERLIST[2]))
                {
                    SharedPreferences.Editor prefEditor = MainActivity.settings.edit();
                    prefEditor.putInt(MainActivity.APP_LANG,2);
                    prefEditor.putString(MainActivity.APP_TITLE,"Who want to be a millionaire");
                    prefEditor.putString(MainActivity.APP_NEW_GAME,"New game");
                    prefEditor.putString(MainActivity.APP_SETTINGS, "Settings");
                    prefEditor.putString(MainActivity.APP_EXIT, "Exit");
                    prefEditor.putString(SETTINGS_LANGUAGE, "Language");
                    prefEditor.putString(SETTINGS_TIME, "Time:");
                    prefEditor.putString(EndGame.ENDGAME_WIN, "Congratulations you won");
                    prefEditor.putString(EndGame.ENDGAME_LOSE, "You lose =(");
                    prefEditor.putString(EndGame.ENDGAME_PRIZE, "Your winnings");

                    prefEditor.apply();
                    ChangeLanguage();
                }
            }
            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        seekBar = (SeekBar)findViewById(R.id.seekBar);
        seekBar.setOnSeekBarChangeListener(
                new SeekBar.OnSeekBarChangeListener() {
                    int progress_value;
                    @Override
                    public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                        TextView text2 = (TextView)findViewById(R.id.tTimeS);
                        text2.setText(Integer.toString(progress+5));
                        progress_value = progress;
                    }

                    @Override
                    public void onStartTrackingTouch(SeekBar seekBar) {

                    }

                    @Override
                    public void onStopTrackingTouch(SeekBar seekBar) {
                        SharedPreferences.Editor prefEditor = MainActivity.settings.edit();
                        prefEditor.putInt(SETTINGS_TIME_S, progress_value+5);
                        prefEditor.apply();
                    }
                }
        );
        ChangeLanguage();

    }
    private void ChangeLanguage() {
        setTitle(MainActivity.settings.getString(MainActivity.APP_TITLE, "Кто хочет стать миллионером"));
        TextView text = (TextView) findViewById(R.id.tLanguage);
        text.setText(MainActivity.settings.getString(SETTINGS_LANGUAGE, "Язык"));

        TextView text1 = (TextView) findViewById(R.id.tTime);
        text1.setText(MainActivity.settings.getString(SETTINGS_TIME, "Время:"));

        TextView text2 = (TextView)findViewById(R.id.tTimeS);
        //text2.setText(Integer.toString(MainActivity.settings.getInt(SETTINGS_TIME_S, 30)));
        seekBar.setProgress(MainActivity.settings.getInt(SETTINGS_TIME_S, 35)-5);
        text2.setText(Integer.toString(seekBar.getProgress()+5));
    }
}
