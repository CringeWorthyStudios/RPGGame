using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{

    //Var

    public string Race;

    bool raceDone = false;

    int totalPoints = 18;
    public Text totalPointsText;


    /*
    int strDefault;
    int agiDefault;
    int dexDefault;
    int conDefault;
    int endDefault;
    int intDefault;
    int wisDefault;
    int chaDefault;
    int lucDefault;
    */

    public int strDefault;
    public int agiDefault;
    public int dexDefault;
    public int conDefault;
    public int endDefault;
    public int intDefault;
    public int wisDefault;
    public int chaDefault;
    public int lucDefault;

    int strCurrent;
    int agiCurrent;
    int dexCurrent;
    int conCurrent;
    int endCurrent;
    int intCurrent;
    int wisCurrent;
    int chaCurrent;
    int lucCurrent;

    public Text strText;
    public Text agiText;
    public Text dexText;
    public Text conText;
    public Text endText;
    public Text intText;
    public Text wisText;
    public Text chaText;
    public Text lucText;


    //Functions


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        strText.text = strCurrent.ToString();
        agiText.text = agiCurrent.ToString();
        dexText.text = dexCurrent.ToString();
        conText.text = conCurrent.ToString();
        endText.text = endCurrent.ToString();
        intText.text = intCurrent.ToString();
        wisText.text = wisCurrent.ToString();
        chaText.text = chaCurrent.ToString();
        lucText.text = lucCurrent.ToString();
        totalPointsText.text = totalPoints.ToString();

    }

    public void ResetPoints()
    {
        totalPoints = 18;
    }

    public void ChooseHuman()
    {
        Race = "Human";
        RaceChoice();
    }

    public void ChooseElf()
    {
        Race = "Elf";
        RaceChoice();
    }

    public void ChooseOrc()
    {
        Race = "Orc";
        RaceChoice();
    }

    public void RaceChoice()
    {

        if (Race == "Human")
        {
            strDefault = 10;
            agiDefault = 10;
            dexDefault = 10;
            conDefault = 10;
            endDefault = 10;
            intDefault = 10;
            wisDefault = 10;
            chaDefault = 10;
            lucDefault = 10;
        }
        else if (Race == "Elf")
        {
            strDefault = 8;
            agiDefault = 12;
            dexDefault = 12;
            conDefault = 9;
            endDefault = 8;
            intDefault = 12;
            wisDefault = 11;
            chaDefault = 8;
            lucDefault = 10;
        }
        else if (Race == "Orc")
        {
            strDefault = 12;
            agiDefault = 10;
            dexDefault = 10;
            conDefault = 14;
            endDefault = 12;
            intDefault = 8;
            wisDefault = 8;
            chaDefault = 8;
            lucDefault = 8;
        }

    }

    public void RaceDone()
    {
        raceDone = true;

        strCurrent = strDefault;
        agiCurrent = agiDefault;
        dexCurrent = dexDefault;
        conCurrent = conDefault;
        endCurrent = endDefault;
        intCurrent = intDefault;
        wisCurrent = wisDefault;
        chaCurrent = chaDefault;
        lucCurrent = lucDefault;

    }



















    //level up/down the different Attributes

    public void IncStr()
    {
        if (totalPoints > 0)
        {
            strCurrent++;
            totalPoints--;
        }
    }

    public void DecStr()
    {
        if (strCurrent > strDefault)
        {
            strCurrent--;
            totalPoints++;
        }
    }

    public void LevelUpStr()
    {

    }

    public void IncAgi()
    {
        if (totalPoints > 0)
        {
            agiCurrent++;
            totalPoints--;
        }
    }

    public void DecAgi()
    {
        if (agiCurrent > agiDefault)
        {
            agiCurrent--;
            totalPoints++;
        }
    }

    public void LevelUpAgi()
    {

    }

    public void IncDex()
    {
        if (totalPoints > 0)
        {
            dexCurrent++;
            totalPoints--;
        }
    }

    public void DecDex()
    {
        if (dexCurrent > dexDefault)
        {
            dexCurrent--;
            totalPoints++;
        }
    }

    public void LevelUpDex()
    {

    }

    public void IncCon()
    {
        if (totalPoints > 0)
        {
            conCurrent++;
            totalPoints--;
        }
    }

    public void DecCon()
    {
        if (conCurrent > conDefault)
        {
            conCurrent--;
            totalPoints++;
        }
    }

    public void LevelUpCon()
    {

    }

    public void IncEnd()
    {
        if (totalPoints > 0)
        {
            endCurrent++;
            totalPoints--;
        }
    }

    public void DecEnd()
    {
        if (endCurrent > endDefault)
        {
            endCurrent--;
            totalPoints++;
        }
    }

    public void LevelUpEnd()
    {
        
    }

    public void IncInt()
    {
        if (totalPoints > 0)
        {
            intCurrent++;
            totalPoints--;
        }
    }

    public void DecInt()
    {
        if (intCurrent > intDefault)
        {
            intCurrent--;
            totalPoints++;
        }
    }

    public void LevelUpInt()
    {

    }

    public void IncWis()
    {
        if (totalPoints > 0)
        {
            wisCurrent++;
            totalPoints--;
        }
    }

    public void DecWis()
    {
        if (wisCurrent > wisDefault)
        {
            wisCurrent--;
            totalPoints++;
        }
    }

    public void LevelUpWis()
    {

    }

    public void IncCha()
    {
        if (totalPoints > 0)
        {
            chaCurrent++;
            totalPoints--;
        }
    }

    public void DecCha()
    {
        if (chaCurrent > chaDefault)
        {
            chaCurrent--;
            totalPoints++;
        }
    }

    public void LevelUpCha()
    {

    }

    public void IncLuc()
    {
        if (totalPoints > 0)
        {
            lucCurrent++;
            totalPoints--;
        }
    }

    public void DecLuc()
    {
        if (lucCurrent > lucDefault)
        {
            lucCurrent--;
            totalPoints++;
        }
    }

    public void LevelUpLuc()
    {

    }


}
