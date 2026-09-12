using UnityEngine;

public struct DamageData 
{
    public float DamageAmount;
    public DamageType TypeOfDamage;
    public GameObject Instigator;
    public Vector3 HitPoint;

    public DamageData(float amount, DamageType type, GameObject source, Vector3 hitPoint = default)
    {
        DamageAmount = amount;
        TypeOfDamage = type;
        Instigator = source;
        HitPoint = hitPoint;
    }
}

public enum DamageType
{
    Physical, 
    Fire,
    Ice,
    True // clear damage, ignor any armor
}
