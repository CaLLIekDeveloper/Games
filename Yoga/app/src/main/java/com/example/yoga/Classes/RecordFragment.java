package com.example.yoga.Classes;


import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.fragment.app.Fragment;

import com.example.yoga.R;

public class RecordFragment extends Fragment {

    static int id = 0;

    View view;
    TextView tvName;
    TextView tvDate;
    TextView tvFullTime;
    TextView tvGameTime;
    TextView tvChips;

    public RecordFragment() {

    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        view = inflater.inflate(R.layout.fragment_record, container, false);

        tvName = container.findViewById(R.id.fName);
        tvDate = container.findViewById(R.id.fDate);
        tvFullTime = container.findViewById(R.id.fTimeForGame);
        tvGameTime = container.findViewById(R.id.fTimeGame);
        tvChips = container.findViewById(R.id.fChips);
        return view;
    }



    public View getView()
    {
        return view;
    }

}
