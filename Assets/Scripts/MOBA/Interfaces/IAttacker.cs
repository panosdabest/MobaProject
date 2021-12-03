public interface IAttacker {
    void InflictPhysicalDamage(float originalInflictedValue, float damage);
    void InflictStatisticalDamage(float originalValue, float debuff);
}