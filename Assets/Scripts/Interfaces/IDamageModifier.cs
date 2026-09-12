
public interface IDamageModifier
{
    /* Returns changed damage */
    float Modify(float Damage, DamageData data, IDamageable target);
}
