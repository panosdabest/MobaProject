using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
[System.Serializable]
public class Player_MasterClass : MonoBehaviourPunCallbacks, IAttacker, IDestructable {
    //If someone prefers the struct approach is more than welcome to use it/recommend exclusive use...
    [System.Serializable]
    public struct PlayerData {
        public int level;
        public string name;
        public float health;
        public float mana;
        public float attackPoints;
        public float armor;
        public Image playerImage;
    }
    public enum PlayerState {
        Idle,
        Walking,
        Running,
        Healthy,
        Damaged,
        Attacking,
        Healing
    }
    public float MovementSpeed { get; set; }
    [Tooltip("Assign the number of abilities & their properties")]
    [Header("Player Ability/ies")]
    [SerializeField] public Ability[] abillities;
    [Header("Player Data")]
    [SerializeField] public PlayerData playerData;
    [Header("Camera Movement")]
    [SerializeField] private Camera playerCamera;
    [Header("Player State")]
    public PlayerState playerState = PlayerState.Idle;
    [Header("Object Detection")]
    [SerializeField] public PlayerDetection detection;
    public bool detectedObject;
    public override void OnEnable() {
        detectedObject = detection.detectedObject;
    }
    public Player_MasterClass() { }
    public Player_MasterClass(PlayerData playerData) { }
    public virtual void InvokeAbility(string Name) {
        for (int i = 0; i < abillities.Length; i++) {
            if(abillities[i].abilityName.Equals(Name)) {
                abillities[i].InvokeAbility();
            }
        }
    }
    [PunRPC]
    public virtual void InflictPhysicalDamage(float damage, Hero hero) { hero.playerData.health -= damage; }
    [PunRPC]
    public virtual void InflictStatisticalDamage(float debuff, Hero hero) {
        //Decrease some value by some value :P ...
        hero.playerData.armor -= debuff;
        hero.playerData.attackPoints -= debuff / 2;
    }
    [PunRPC]
    public virtual void HandleDamage(float damage) {
        this.playerData.health -= damage;
        if (playerData.health - damage < 0) {
            float difference = damage - playerData.health;
            playerData.health -= difference;
        }
    }
    [PunRPC]
    public virtual void HandleDeath() {
        if (this.playerData.health <= 0 && photonView.IsMine) {
            PhotonNetwork.LeaveRoom();
        }
    }
}