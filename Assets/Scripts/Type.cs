using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type
{
    public string Name;
    public List<Type> Weak;
    public List<Type> Resist;
    public List<Type> Immune;

    public Type(string type)
    {
        Name = type;
        Weak = new List<Type>();
        Resist = new List<Type>();
        Immune = new List<Type>();
        TypeDatabase Types = GameObject.Find("TypeDatabase").GetComponent<TypeDatabase>();

        if(type == "Normal")
        {
            Weak.AddRange(new List<Type>{Types.Fighting});
            Immune.AddRange(new List<Type>{Types.Ghost});
        }
        else if(type == "Fire")
        {
            Weak.AddRange(new List<Type>{Types.Water, Types.Ground, Types.Rock});
            Resist.AddRange(new List<Type>{Types.Fire, Types.Grass, Types.Ice, Types.Bug, Types.Steel, Types.Fairy});
        }
        else if(type == "Water")
        {
            Weak.AddRange(new List<Type>{Types.Electric, Types.Grass});
            Resist.AddRange(new List<Type>{Types.Fire, Types.Water, Types.Ice, Types.Steel});
        }
        else if(type == "Grass")
        {
            Weak.AddRange(new List<Type>{Types.Fire, Types.Ice, Types.Poison, Types.Flying, Types.Bug});
            Resist.AddRange(new List<Type>{Types.Water, Types.Electric, Types.Grass, Types.Ground});
        }
        else if(type == "Electric")
        {
            Weak.AddRange(new List<Type>{Types.Ground});
            Resist.AddRange(new List<Type>{Types.Electric, Types.Flying, Types.Steel});
        }
        else if(type == "Ice")
        {
            Weak.AddRange(new List<Type>{Types.Fire, Types.Fighting, Types.Rock, Types.Steel});
            Resist.AddRange(new List<Type>{Types.Ice});
        }
        else if(type == "Fighting")
        {
            Weak.AddRange(new List<Type>{Types.Flying, Types.Psychic, Types.Fairy});
            Resist.AddRange(new List<Type>{Types.Bug, Types.Rock, Types.Dark});
        }
        else if(type == "Poison")
        {
            Weak.AddRange(new List<Type>{Types.Ground, Types.Psychic});
            Resist.AddRange(new List<Type>{Types.Grass, Types.Fighting, Types.Poison, Types.Bug, Types.Fairy});
        }
        else if(type == "Ground")
        {
            Weak.AddRange(new List<Type>{Types.Water, Types.Grass, Types.Ice});
            Resist.AddRange(new List<Type>{Types.Poison, Types.Bug});
            Immune.AddRange(new List<Type>{Types.Electric});
        }
        else if(type == "Flying")
        {
            Weak.AddRange(new List<Type>{Types.Electric, Types.Ice, Types.Rock});
            Resist.AddRange(new List<Type>{Types.Grass, Types.Fighting, Types.Bug});
            Immune.AddRange(new List<Type>{Types.Ground});
        }
        else if(type == "Psychic")
        {
            Weak.AddRange(new List<Type>{Types.Bug, Types.Ghost, Types.Dark});
            Resist.AddRange(new List<Type>{Types.Fighting, Types.Psychic});
        }
        else if(type == "Bug")
        {
            Weak.AddRange(new List<Type>{Types.Fire, Types.Flying, Types.Rock});
            Resist.AddRange(new List<Type>{Types.Grass, Types.Fighting, Types.Ground});
        }
        else if(type == "Rock")
        {
            Weak.AddRange(new List<Type>{Types.Water, Types.Grass, Types.Fighting, Types.Ground, Types.Steel});
            Resist.AddRange(new List<Type>{Types.Normal, Types.Fire, Types.Poison, Types.Flying});
        }
        else if(type == "Ghost")
        {
            Weak.AddRange(new List<Type>{Types.Dark, Types.Ghost});
            Resist.AddRange(new List<Type>{Types.Poison, Types.Bug});
            Immune.AddRange(new List<Type>{Types.Normal, Types.Fighting});
        }
        else if(type == "Dragon")
        {
            Weak.AddRange(new List<Type>{Types.Ice, Types.Dragon, Types.Fairy});
            Resist.AddRange(new List<Type>{Types.Fire, Types.Water, Types.Electric, Types.Grass});
        }
        else if(type == "Dark")
        {
            Weak.AddRange(new List<Type>{Types.Fighting, Types.Bug, Types.Fairy});
            Resist.AddRange(new List<Type>{Types.Ghost, Types.Dark});
            Immune.AddRange(new List<Type>{Types.Psychic});
        }
        else if(type == "Steel")
        {
            Weak.AddRange(new List<Type>{Types.Fire, Types.Fighting, Types.Ground});
            Resist.AddRange(new List<Type>{Types.Normal, Types.Grass, Types.Ice, Types.Flying, Types.Psychic, Types.Bug, Types.Rock, Types.Dragon, Types.Steel, Types.Fairy});
            Immune.AddRange(new List<Type>{Types.Poison});
        }
        else if(type == "Fairy")
        {
            Weak.AddRange(new List<Type>{Types.Poison, Types.Steel});
            Resist.AddRange(new List<Type>{Types.Fighting, Types.Bug, Types.Dark});
            Immune.AddRange(new List<Type>{Types.Dragon});
        }
        else
        {
            Debug.Log("ErrorType");
        }
    }

    public double GetEffectivenessAgainst(Pokemon Target)
    {
        double result = 1;
        if(Target.Type1 != null && Target.Type1.Weak.Contains(this))
            result *= 2;
        if(Target.Type2 != null && Target.Type2.Weak.Contains(this))
            result *= 2;
        if(Target.Type1 != null && Target.Type1.Resist.Contains(this))
            result /= 2;
        if(Target.Type2 != null && Target.Type2.Resist.Contains(this))
            result /= 2;
        return result;
    }
}
