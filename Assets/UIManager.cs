using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image HealthBar;
    [SerializeField] Image ManaBar;
    [SerializeField] Image CharacterImage;
    [SerializeField] Text CharacterLevel;
    [SerializeField] Text CharacterName;
    [SerializeField] Text Ability1;
    [SerializeField] Text Ability2;
  public  float AbilityCooldown;
    float SecondAbilityCooldown;
    bool FirstAbility;
    bool SecondAbility;
    bool playerWantstoUseFirstAbility;

    Player_MasterClass Player_Data;
    Ability ability;
    // Start is called before the first frame update
    void Start()
    {
        AbilityCooldown = 10;
        CharacterName.text = Player_Data.playerData.name;
        CharacterLevel.text = Player_Data.playerData.level.ToString();
        Ability1.text = ability.abilityName;

    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = Player_Data.playerData.health;
        ManaBar.fillAmount = Player_Data.playerData.mana;


        if (ability.abilityCoolDown > 0)
        {
            AbilityCooldown -= Time.deltaTime;
            Ability1.color = Color.gray;
        }
        else
        {
            Ability1.color = Color.white;
        }
        if (AbilityCooldown > 0 && playerWantstoUseFirstAbility)
        {
           
        }
        if (FirstAbility == true)
        {
           
        }
        


        if (SecondAbility == true)
        {
            Ability2.color = Color.gray;
        }

       
       



        if (SecondAbilityCooldown > 0)
        {
            Ability2.color = Color.white;
        }


    }
    public Text GetCharacterName()
    {
        return CharacterName;
    }
}
