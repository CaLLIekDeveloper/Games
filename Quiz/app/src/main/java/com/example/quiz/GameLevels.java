package com.example.quiz;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class GameLevels extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.game_levels);

        //убираем строку состояния андроида
        Window window = getWindow();
        window.setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);

        Button btnBack = findViewById(R.id.button_back);

        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                GoToMainMenu();
            }
        });

        TextView textView1 = findViewById(R.id.textView1);
        textView1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    Intent intent = new Intent(GameLevels.this,Level1.class);
                    startActivity(intent);
                }catch (Exception ex)
                {

                }
            }
        });
    }

    private void GoToMainMenu()
    {
        try{
            Intent intent = new Intent(GameLevels.this,MainActivity.class);
            startActivity(intent);
            finish();
        }catch (Exception ex)
        {

        }
    }

    @Override
    public void onBackPressed()
    {
        GoToMainMenu();
    }
}
