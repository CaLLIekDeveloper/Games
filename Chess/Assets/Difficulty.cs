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
}
