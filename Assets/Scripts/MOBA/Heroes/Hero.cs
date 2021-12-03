using UnityEngine;
public class Hero : Player_MasterClass {
    void Start() { }
    // Update is called once per frame
    void Update() { }
    public void CheckInput() {
        if(Input.GetKeyDown("Fire1")) {
            InvokeAbility(abillities[0].abilityName);
        }
    }
    public override void InflictPhysicalDamage(float originalInflictedValue, float damage) {
        base.InflictPhysicalDamage(originalInflictedValue, damage);
    }
    public override void InflictStatisticalDamage(float originalValue, float debuff) {
        base.InflictStatisticalDamage(originalValue, debuff);
    }
    public override void ReceiveDamage(float damage) {
        base.ReceiveDamage(damage);
    }
    public override void HandleDeath() {
        base.HandleDeath();
    }
}
