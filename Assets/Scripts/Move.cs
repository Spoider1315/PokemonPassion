using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Move
{
    public static TypeDatabase Types = GameObject.Find("TypeDatabase").GetComponent<TypeDatabase>();
    public string Name;
    public Type ThisType;
    public string Form;
    public int Power;
    public int Accuracy;
    public int PP;
    public int MaxPP;

    public virtual void Use(Pokemon User, Pokemon Target, string TargetType)
    {
        PP--;
        if(CheckAccuracy())
        {
            Debug.Log("Missed");
            return;
        }
        double ThisAttack = CalculateAttack(User, Target);
        double ThisDefense = CalculateDefense(User, Target);

        double Targets = CalculateTargets();
        double ParentalBond = CalculateParentalBond();
        double Weather = CalculateWeather();
        double Critical = CalculateCritical();
        double Rand = (double)Random.Range(0.85f, 1.0f);
        double STAB = CalculateStab(User);
        double Effectiveness = ThisType.GetEffectivenessAgainst(Target);
        double Burn = 1;
        double Other = 1;

        Target.TakeDamage( (int)(((((((2*User.Level)/5) +2) * Power * (ThisAttack/ThisDefense))/50) + 2) * Targets * ParentalBond * Weather * Critical * Rand * STAB * Effectiveness * Burn * Other), TargetType );
    }

    public virtual bool CheckAccuracy()
    {
        return Random.Range(0, 101) > Accuracy;
    }
    
    public virtual int CalculateAttack(Pokemon User, Pokemon Target)
    {
        if (Form == "Physical")
        {
            return (int)(User.Attack * User.AttackModifier);
        }
        else if (Form == "Special")
        {
            return (int)(User.SpecialAttack * User.SpecialAttackModifier);
        }
        else
        {
            return 0;
        }
    }

    public virtual int CalculateDefense(Pokemon User, Pokemon Target)
    {
        if (Form == "Physical")
        {
            return (int)(Target.Defense * Target.DefenseModifier);
        }
        else if (Form == "Special")
        {
            return (int)(Target.SpecialDefense * Target.SpecialDefenseModifier);
        }
        else
        {
            return 0;
        }
    }

    public virtual float CalculateTargets()
    {
        return 1;
    }
    public virtual float CalculateParentalBond()
    {
        return 1;
    }
    public virtual float CalculateWeather()
    {
        return 1;
    }
    public virtual float CalculateCritical()
    {
        return 1;
    }
    public virtual float CalculateStab(Pokemon User)
    {
        if ((User.Type1 != null && User.Type1.Name == ThisType.Name) || (User.Type2 != null && User.Type2.Name == ThisType.Name))
        {
            return (float)1.5;
        }
        else
        {
            return 1;
        }
    }
}
