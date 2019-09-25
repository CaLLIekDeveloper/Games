package com.example.yoga.Activities;

import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import com.example.yoga.Classes.Globals;
import com.example.yoga.Classes.MovesYoga;
import com.example.yoga.R;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;

public class EndGameActivity extends AppCompatActivity {

    String name = "Неизвестный герой";
    int time  = 60;
    @Override
    protected  void onStart()
    {
        super.onStart();
        if(Globals.Language==0)ChangeLanguage(true);
        else
            ChangeLanguage(false);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        if(Globals.Language==0)ChangeLanguage(true);
        else
            ChangeLanguage(false);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_end_game);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        TextView tv = findViewById(R.id.tvTimeForGame);
        tv.setText(""+ MovesYoga.fullTime);
        tv = findViewById(R.id.tvGameTime);
        time  = (MovesYoga.fullTime- MovesYoga.endTime);
        if(time==0)time=MovesYoga.fullTime;
        tv.setText(""+time);

        tv = findViewById(R.id.tvCountMoves);
        tv.setText(""+ MovesYoga.countMove);

        Button btnSave = findViewById(R.id.btnSave);
        btnSave.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view)
            {
                SaveResult();
                OpenActivityHighscores();
            }
        });
    }

    private void SaveResult()
    {
        //получаю имя игрока
        EditText etName = findViewById(R.id.etName);
        if(etName.getText().toString().length()!=0)name = etName.getText().toString();

        Globals.sqlHelper.open();
        //получаю дату
        DateFormat df = new SimpleDateFormat("dd.MM.yyyy");
        String date = df.format(Calendar.getInstance().getTime());
        //исполняю sql запрос
        Globals.sqlHelper.database.execSQL("INSERT INTO Yoga(date,name,fullTime,gameTime,chips)\n" +
                "VALUES\n" +
                "(\""+date+"\",\""+name+"\","+ MovesYoga.fullTime+","+time+","+ MovesYoga.countMove+");");
        Globals.sqlHelper.close();
    }


    private void ChangeLanguage(boolean flag) {
        Locale locale;
        if(flag) {
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

    @Override
    public void onBackPressed() {
        return;
    }
}
