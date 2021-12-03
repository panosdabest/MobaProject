public interface IAttacker {
    void InflictPhysicalDamage(float damage, Hero hero);
    void InflictStatisticalDamage(float debuff, Hero hero);
}