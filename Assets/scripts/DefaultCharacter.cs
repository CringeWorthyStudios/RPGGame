using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefaultCharacter : MonoBehaviour
{
    public Dictionary<string, int> defaultStatsDict = new Dictionary<string, int>();
    //public List<int> defaultStatsList = [10, 10, 10, 10, 10, 10, 10, 10, 10];
    public int[] defaultStats;
    public int[] currentStats;

    private void Start()
    {
        defaultStatsDict.Add("Strength", 10);
        defaultStatsDict.Add("Agility", 10);
        defaultStatsDict.Add("Dexterity", 10);
        defaultStatsDict.Add("Constitution", 10);
        defaultStatsDict.Add("Endurance", 10);
        defaultStatsDict.Add("Intelligence", 10);
        defaultStatsDict.Add("Wisdom", 10);
        defaultStatsDict.Add("Charisma", 10);
        defaultStatsDict.Add("Luck", 10);
        
        for(int i = 0; i < 9; i++)
        {
            defaultStats[i] = 10;
        }

        if (currentStats == null)
        {
            currentStats = defaultStats;
        }
    }

}