package com.example.parsh;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.ActivityInfo;
import android.media.MediaPlayer;
import android.os.CountDownTimer;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Random;

public class Game extends AppCompatActivity implements View.OnClickListener {

    TextView a1;
    TextView a2;
    TextView a3;
    TextView a4;
    ImageButton b1;
    ImageButton b2;
    ImageButton b3;
    ImageButton b4;
    ImageButton[] buttons = new ImageButton[4];
    TextView question;
    TextView tMoney;
    TextView[] tA = new TextView[4];
    TextView tTime;


    ImageButton home;
    ImageButton bMusic;
    ImageButton bHelp;

    CountDownTimer timer;

    String Answer;

    String checkAnswer;

    int money = 64;
    int round = 1;

    int savedMoney = 0;

    boolean inGame;
    boolean isSelected = false;

    int milliseconds = 30000;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game);
        Intent intent = getIntent();
        this.setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
        String tMusic = intent.getStringExtra("music");
        setTitle(MainActivity.settings.getString(MainActivity.APP_TITLE,"Кто хочет стать миллионером"));

        question = (TextView)findViewById(R.id.tQuestion);
        a1 = (TextView)findViewById(R.id.a1);
        a2 = (TextView)findViewById(R.id.a2);
        a3 = (TextView)findViewById(R.id.a3);
        a4 = (TextView)findViewById(R.id.a4);
        b1 = (ImageButton)findViewById(R.id.b1);
        b2 = (ImageButton)findViewById(R.id.b2);
        b3 = (ImageButton)findViewById(R.id.b3);
        b4 = (ImageButton)findViewById(R.id.b4);
        tMoney = (TextView)findViewById(R.id.tMoney);
        tTime = (TextView)findViewById(R.id.tLanguage);
        home = (ImageButton)findViewById(R.id.bHome);
        bMusic = (ImageButton)findViewById(R.id.bMusic);

        bHelp = (ImageButton)findViewById(R.id.bHelp);

        milliseconds = MainActivity.settings.getInt(Settings.SETTINGS_TIME_S,30)*1000;
        sheck();

        tA[0] = a1; tA[1]=a2; tA[2]=a3; tA[3]=a4;
        buttons[0]=b1; buttons[1]=b2; buttons[2]=b3; buttons[3]=b4;
        inGame = true;
        setRound();
        restartTime();
        startMusic();
    }
    void sheck()
    {
        if(MainActivity.settings.getBoolean(MainActivity.APP_MUSIC,true))bMusic.setImageResource(R.drawable.music);
        else
            bMusic.setImageResource(R.drawable.no_music);
    }

    void startMusic()
    {
        if(MainActivity.settings.getBoolean(MainActivity.APP_MUSIC,true))
            startService(new Intent(this, MyService.class));
        else
            stopService(new Intent(this, MyService.class));
    }

    void restartTime()
    {
        timer = new CountDownTimer(milliseconds+300,1000) {
            @Override
            public void onTick(long l) {
                tTime.setText("" +l/1000);
            }

            @Override
            public void onFinish() {
                tTime.setText("0");
                if(inGame)lose();
                inGame = false;
            }
        }.start();
    }
    void stopTimer()
    {
        if(timer!=null)timer.cancel();
    }

    void selectAnswer(ImageButton temp)
    {
        stopTimer();
        isSelected = true;
        temp.setImageResource(R.drawable.select);
        setEnabledButtons(temp);
    }

    void lose()
    {
        EndGame.win = false;
        MediaPlayer mPlayer = MediaPlayer.create(getApplicationContext(), R.raw.lose); // in 2nd param u have to pass your desire ringtone
        mPlayer.start();
        question.setText("");
        setPrize();

        Intent intent = new Intent(this, EndGame.class);
        startActivity(intent);
/*
        stopService(new Intent(this, MyService.class));
        for(int i=0; i<tA.length; i++)
        {
            tA[i].setText("");
        }
        setVisibleB(false);
        */
    }
    void wrongAnswer(ImageButton temp)
    {
        inGame=false;
        temp.setImageResource(R.drawable.wrong);
        setEnableButtons(false);
        int tempI = 0;
        for(int i=0; i<tA.length; i++)
        {
            if(tA[i].getText().equals(Answer)){tempI=i; break;}
        }
        buttons[tempI].setImageResource(R.drawable.correct);

        new CountDownTimer(1500,1000) {
            @Override
            public void onTick(long l) {
            }
            @Override
            public void onFinish() {
                lose();

            }}.start();

    }

    void nextRound(ImageButton temp)
    {
        if(round%5==0)savedMoney = money;
        round++;
        money*=2;
        tMoney.setText(Integer.toString(money));
        temp.setImageResource(R.drawable.ram1);
        setEnableButtons(true);
        isSelected = false;
        if(round==15){savedMoney = money; win();}
        else
        {setRound();restartTime();}
    }

    void setEnabledButtons(ImageButton temp)
    {
        for(int i=0; i<buttons.length; i++)
        {
            if(buttons[i]!=temp)buttons[i].setEnabled(false);
        }
    }
    void setEnableButtons(boolean temp)
    {
        for(int i=0; i<buttons.length; i++)
        {
            buttons[i].setEnabled(temp);
            //buttons[i].setVisibility(View.VISIBLE);
        }
    }

    void setVisibleB(boolean temp)
    {
        for(int i=0; i<buttons.length; i++)
        {
            buttons[i].setVisibility(View.INVISIBLE);
        }
    }


    void pause(final ImageButton temp)
    {
        new CountDownTimer(1000,1000) {
            @Override
            public void onTick(long l) {
            }
            @Override
            public void onFinish() {
                if(checkAnswer==Answer&&inGame)
                {
                    temp.setImageResource(R.drawable.correct);

                    new CountDownTimer(1000,1000) {
                        @Override
                        public void onTick(long l) {
                        }
                        @Override
                        public void onFinish() {
                            nextRound(temp);

                        }}.start();
                }else{wrongAnswer(temp); inGame = false;}
            }
        }.start();
    }
    void help_Fifty_Fifty()
    {
        ArrayList<TextView> tempTA = new ArrayList<TextView>();
        tempTA.add(a1);
        tempTA.add(a2);
        tempTA.add(a3);
        tempTA.add(a4);
        ArrayList<ImageButton> tempButtons = new ArrayList<ImageButton>();
        tempButtons.add(b1);
        tempButtons.add(b2);
        tempButtons.add(b3);
        tempButtons.add(b4);
        int tempI = 0;
        for(int i=0; i<tA.length; i++)
        {
            if(tA[i].getText().equals(Answer)){tempI=i; break;}
        }
        tempTA.remove(tempI);
        tempButtons.remove(tempI);
        Random rand = new Random();
        int random_number_answer = rand.nextInt(tempTA.size());
        if(random_number_answer==3)random_number_answer-=1;
        tempTA.remove(random_number_answer);
        tempButtons.remove(random_number_answer);
        for(int i=0; i<tempTA.size(); i++)
        {
            tempTA.get(i).setText("");
            tempButtons.get(i).setEnabled(false);
        }

    }
    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.bHome:
                Intent intent = new Intent();
                setResult(RESULT_OK, intent);
                stopService(new Intent(this, MyService.class));
                stopTimer();
                finish();
                break;
            case R.id.bHelp:
                if(!isSelected&&inGame) {
                    bHelp.setImageResource(R.drawable.no_fifry_fifty);
                    bHelp.setEnabled(false);
                    help_Fifty_Fifty();
                }
                break;
            case R.id.bMusic:
                SharedPreferences.Editor prefEditor = MainActivity.settings.edit();
                prefEditor.putBoolean(MainActivity.APP_MUSIC,!MainActivity.settings.getBoolean(MainActivity.APP_MUSIC,true));
                prefEditor.apply();
                sheck();
                startMusic();
                break;
            case R.id.b1:
                if(!isSelected) {
                    selectAnswer(b1);
                    checkAnswer = a1.getText().toString();
                    pause(b1);
                }
                break;
            case R.id.b2:
                if(!isSelected) {
                    selectAnswer(b2);
                    checkAnswer = a2.getText().toString();
                    pause(b2);
                }
                break;
            case R.id.b3:
                if(!isSelected) {
                    selectAnswer(b3);
                    checkAnswer = a3.getText().toString();
                    pause(b3);
                }
                break;
            case R.id.b4:
                if(!isSelected) {
                    selectAnswer(b4);
                    checkAnswer = a4.getText().toString();
                    pause(b4);
                }
                break;

            default:
                break;
        }
    }

    void setPrize()
    {
        EndGame.gain = Integer.toString(savedMoney);
    }
    void win()
    {
        MediaPlayer mPlayer = MediaPlayer.create(getApplicationContext(), R.raw.win); // in 2nd param u have to pass your desire ringtone
        mPlayer.start();
        EndGame.win = true;
        inGame=false;
        setPrize();
        Intent intent = new Intent(this, EndGame.class);
        startActivity(intent);

/*
        question.setText("");
        stopService(new Intent(this, MyService.class));
        for(int i=0; i<tA.length; i++)
        {
            tA[i].setText("");
        }
        setVisibleB(false);
        tTime.setVisibility(View.INVISIBLE);
        stopTimer();
        */
    }
    void setRound()
    {
        Random rand = new Random();
        if(Questions.ANSWERS.size()>0) {
            int random_number1 = 0 + (int) (Math.random() * Questions.ANSWERS.size() - 1);
            Question tempQ = Questions.ANSWERS.get(random_number1);
            Answer = tempQ.correctAnswer;
            question.setText(tempQ.question);
            for (int i = 0; i < 4; i++) {
                int random_number_answer = rand.nextInt(tempQ.answers.size());
                if(random_number_answer==tempQ.answers.size())random_number_answer-=1;
                tA[i].setText(tempQ.answers.get(random_number_answer));
                tempQ.answers.remove(random_number_answer);
            }
            //Log.d("myApp", "Количество вопросов"+Integer.toString(Questions.ANSWERS.size()));
            Questions.ANSWERS.remove(random_number1);
        }
    }
    @Override
    protected void onDestroy() {
        super.onDestroy();
        stopService(new Intent(this, MyService.class));
    }
    //окно становится невидимым для пользователя
    @Override
    protected void onStop() {
        super.onStop();
        Intent intent = new Intent();
        setResult(RESULT_OK, intent);
        stopService(new Intent(this, MyService.class));
        stopTimer();
        finish();
    }
    @Override
    protected void onStart() {
        super.onStart();
        startMusic();
    }
}
