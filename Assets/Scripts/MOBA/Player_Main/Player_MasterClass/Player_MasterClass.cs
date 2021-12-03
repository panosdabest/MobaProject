using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Player_MasterClass : MonoBehaviour, IAttacker {
    //If someone prefers the struct approach is more than welcome to use it/recommend exclusive use...
    [System.Serializable]
    public struct PlayerData {
        public string name;
        public float health;
        public float mana;
        public float attackPoints;
        public float armor;
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
    [Tooltip("Assign the number of abilities & their properties")]
    [Header("Player Ability/ies")]
    [SerializeField] public Ability[] abillities;
    [Header("Player Data")]
    [SerializeField] public PlayerData playerData;
    [Header("Camera Movement")]
    [SerializeField] private Camera playerCamera;
    [Header("Player State")]
    public PlayerState playerState = PlayerState.Idle;
    public Player_MasterClass() { }
    public Player_MasterClass(PlayerData playerData) { }
    public virtual void InvokeAbility(string Name) {
        for (int i = 0; i < abillities.Length; i++) {
            if(abillities[i].abilityName.Equals(Name)) {
                abillities[i].InvokeAbility();
            }
        }
    }
    public virtual void InflictPhysicalDamage(float originalInflictedValue, float damage) { }

    public virtual void InflictStatisticalDamage(float originalValue, float debuff) { }
}