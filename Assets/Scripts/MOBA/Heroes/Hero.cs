using UnityEngine;
using Photon.Pun;
[RequireComponent(typeof (PlayerDetection))]
public class Hero : Player_MasterClass {
    public Hero(PlayerData playerData) : base(playerData) { this.playerData = playerData; }
    Hero otherHero => detection.otherHero()?.GetComponent<Hero>();
    [Header("Inflict Damage Info")]
    [SerializeField] float debuffPoints;
    [SerializeField] public bool activeHero;
    void Start() { }
    // Update is called once per frame
    void Update() { CheckInput(); }
    public void CheckInput() {
        if (activeHero) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log($"INVOKING : {abillities[0].abilityName}");
                InvokeAbility("Heal");
            }
            if (otherHero != null) {
                if(GetComponent<PlayerDetection>().detectedObject)
                Debug.Log($"OTHER HERO : {otherHero.playerData.name}");
            }
        }
    }
    public override void InflictPhysicalDamage( float damage, Hero hero) {
        base.InflictPhysicalDamage(this.playerData.attackPoints, otherHero);
    }
    public override void InflictStatisticalDamage( float debuff, Hero hero) {
        base.InflictStatisticalDamage(debuffPoints, otherHero);
    }
    public override void HandleDamage(float damage) {}
    public override void HandleDeath() { base.HandleDeath(); }
}
