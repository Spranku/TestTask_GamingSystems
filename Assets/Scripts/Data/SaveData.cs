using System;

[Serializable]
public class SaveData
{
    public int currency;
    public float bestTime;
    public int bestKills;
    public int totalKills;
    public int totalDeaths;
    public int gamesPlayed;

    public static SaveData Default => new SaveData
    {
        currency = 0,
        bestTime = 0f,
        bestKills = 0,
        totalKills = 0,
        totalDeaths = 0,
        gamesPlayed = 0
    };
}
