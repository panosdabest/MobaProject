using UnityEngine;
[System.Serializable]
public struct Ability  {
    public string abilityName;
    public GameObject abilityObject;
    public float abilityCoolDown;
    public float damagePoints;
    public void InvokeAbility() {
        //Method Functionality for invoking the ability...
        //to be invoked by Hero_Class/es...
    }
    public void AbillityCoolDown() {
        //Ability Cooldown when the ability is used...
    }
}