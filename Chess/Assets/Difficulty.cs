using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty {

    public int skill;
    public Difficulty()
    {
        skill = 1;
    }

    public string CastSkill()
    {
        switch(this.skill)
        {
            case 1:
                return "1";
            case 2:
                return "2";
            case 3:
                return "3";
            case 4:
                return "100";
            default:
                return "1";
        }
    }
    public void SetFromString(string tempString)
    {
        if(tempString.Equals("1"))
        {
            skill = 1;
        }
        if (tempString.Equals("2"))
        {
            skill = 2;
        }
        if (tempString.Equals("3"))
        {
            skill = 3;
        }
        if (tempString.Equals("4"))
        {
            skill = 4;
        }
    }
}
