using UnityEngine;

[System.Serializable]
public struct StatsData
{
    public float appliedDamage;
    public float gettingDamage;
    public float battleTime;
    public int totalKills;
    public int totalDeads;

    /* TODO*/
    //public float physicalDamage;
    //public float fireDamage;
    //public float iceDamage;
    //public float trueDamage;

    public StatsData(float apDamage, float getDamage, int kills, int deads, float time)
    {
        appliedDamage = apDamage;
        gettingDamage = getDamage;
        battleTime = time;
        totalKills = kills;
        totalDeads = deads;
    }

    public static StatsData Empty => new StatsData(0, 0, 0, 0, 0);
}
