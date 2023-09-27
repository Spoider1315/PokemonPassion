using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pokemon : MonoBehaviour
{
    public string Name;
    public int Level;
    public Type Type1;
    public Type Type2;
    public int BaseHP;
    public int BaseAttack;
    public int BaseDefense;
    public int BaseSpecialAttack;
    public int BaseSpecialDefense;
    public int BaseSpeed;
    
    public int HPIVS;
    public int AttackIVS;
    public int DefenseIVS;
    public int SpecialAttackIVS;
    public int SpecialDefenseIVS;
    public int SpeedIVS;
    
    public int HPEVS;
    public int AttackEVS;
    public int DefenseEVS;
    public int SpecialAttackEVS;
    public int SpecialDefenseEVS;
    public int SpeedEVS;

    public int MaxHP;
    public int CurrentHP;
    public int Attack;
    public int Defense;
    public int SpecialAttack;
    public int SpecialDefense;
    public int Speed;

    public double AttackModifier;
    public double DefenseModifier;
    public double SpecialAttackModifier;
    public double SpecialDefenseModifier;
    public double SpeedModifier;

    public Sprite PokeBackSprite;
    public Sprite PokeFrontSprite;

    public Move Move1;
    public Move Move2;
    public Move Move3;
    public Move Move4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(int Amount, string Target)
    {
        CurrentHP -= Amount;
        if(CurrentHP <= 0)
        {
            CurrentHP = 0;
            Faint();
        }
        if(Target == "Opponent")
        {
            GameObject.Find("EnemyHealthBar").transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>().offsetMax = new Vector2(-(7.0f - (7.0f * ((float)CurrentHP/(float)MaxHP))), GameObject.Find("CurrentHealth").GetComponent<RectTransform>().offsetMax.y);
        }
        else
        {
            GameObject.Find("PlayerHealthBar").transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>().offsetMax = new Vector2(-(7.0f - (7.0f * ((float)CurrentHP/(float)MaxHP))), GameObject.Find("CurrentHealth").GetComponent<RectTransform>().offsetMax.y);
        }
    }
    public void Faint()
    {
        CurrentHP = 0;
    }

    public void GenerateIVs()
    {
        HPIVS = Random.Range(0, 32);
        AttackIVS = Random.Range(0, 32);
        DefenseIVS = Random.Range(0, 32);
        SpecialAttackIVS = Random.Range(0, 32);
        SpecialDefenseIVS = Random.Range(0, 32);
        SpeedIVS = Random.Range(0, 32);
    }

    public void UpdateStats()
    {
        MaxHP = (int)((((2 * BaseHP) + HPIVS + (int)(HPEVS / 4)) * Level) / 100) + Level + 10;
        Attack = (int)((((2 * BaseAttack) + AttackIVS + (int)(AttackEVS / 4)) * Level) / 100) + 5;
        Defense = (int)((((2 * BaseDefense) + DefenseIVS + (int)(DefenseEVS / 4)) * Level) / 100) + 5;
        SpecialAttack = (int)((((2 * BaseSpecialAttack) + SpecialAttackIVS + (int)(SpecialAttackEVS / 4)) * Level) / 100) + 5;
        SpecialDefense = (int)((((2 * BaseSpecialDefense) + SpecialDefenseIVS + (int)(SpecialDefenseEVS / 4)) * Level) / 100) + 5;
        Speed = (int)((((2 * BaseSpeed) + SpeedIVS + (int)(SpeedEVS / 4)) * Level) / 100) + 5;
    }
    public void SetEVS(int hp, int attack, int defense, int specialAttack, int specialDefense, int speed)
    {
        HPEVS = hp;
        AttackEVS = attack;
        DefenseEVS = defense;
        SpecialAttackEVS = specialAttack;
        SpecialDefenseEVS = specialDefense;
        SpeedEVS = speed;
    }
    public void SetIVS(int hp, int attack, int defense, int specialAttack, int specialDefense, int speed)
    {
        HPIVS = hp;
        AttackIVS = attack;
        DefenseIVS = defense;
        SpecialAttackIVS = specialAttack;
        SpecialDefenseIVS = specialDefense;
        SpeedIVS = speed;
    }
    public void SetModifiers(double attack, double defense, double specialAttack, double specialDefense, double speed)
    {
        AttackModifier = attack;
        DefenseModifier = defense;
        SpecialAttackModifier = specialAttack;
        SpecialDefenseModifier = specialDefense;
        SpeedModifier = speed;
    }
}
