using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static MoveDatabase;

public class PokemonManager : MonoBehaviour
{
    TypeDatabase Types;
    MoveDatabase Moves;
    PokemonDatabase AllPokemon;
    // Start is called before the first frame update
    void Start()
    {
        Pokemon ActivePokemon = GameObject.Find("ActivePokemon").GetComponent<Pokemon>();
        Types = GameObject.Find("TypeDatabase").GetComponent<TypeDatabase>();
        AllPokemon = GameObject.Find("PokemonDatabase").GetComponent<PokemonDatabase>();

        FillFromDatabase(ActivePokemon, AllPokemon.Bulbasaur);
        ActivePokemon.GenerateIVs();
        ActivePokemon.Move1 = new Tackle();
        ActivePokemon.Move2 = new Sludge();
        ActivePokemon.Level = 5;
        ActivePokemon.UpdateStats();
        ActivePokemon.CurrentHP = ActivePokemon.MaxHP;

        Pokemon ActiveOpponent = GameObject.Find("ActiveOpponent").GetComponent<Pokemon>();
        FillFromDatabase(ActiveOpponent, AllPokemon.Bulbasaur);
        ActiveOpponent.GenerateIVs();
        ActiveOpponent.Move1 = new Tackle();
        ActiveOpponent.Level = 5;
        ActiveOpponent.UpdateStats();
        ActiveOpponent.CurrentHP = ActiveOpponent.MaxHP;
    }

    public void FillFromDatabase(Pokemon Destination, Pokemon Source)
    {
         Destination.Name = Source.Name;
         Destination.Type1 = Source.Type1;
         Destination.Type2 = Source.Type2;
         Destination.BaseHP = Source.BaseHP;
         Destination.BaseAttack = Source.BaseAttack;
         Destination.BaseDefense = Source.BaseDefense;
         Destination.BaseSpecialAttack = Source.BaseSpecialAttack;
         Destination.BaseSpecialDefense = Source.BaseSpecialDefense;
         Destination.BaseSpeed = Source.BaseSpeed;
         Destination.HPEVS = Source.HPEVS;
         Destination.AttackEVS = Source.AttackEVS;
         Destination.DefenseEVS = Source.DefenseEVS;
         Destination.SpecialAttackEVS = Source.SpecialAttackEVS;
         Destination.SpecialDefenseEVS = Source.SpecialDefenseEVS;
         Destination.SpeedEVS = Source.SpeedEVS;
         Destination.MaxHP = Source.MaxHP;
         Destination.CurrentHP = Source.CurrentHP;
         Destination.AttackModifier = Source.AttackModifier;
         Destination.DefenseModifier = Source.DefenseModifier;
         Destination.SpecialAttackModifier = Source.SpecialAttackModifier;
         Destination.SpecialDefenseModifier = Source.SpecialDefenseModifier;
         Destination.SpeedModifier = Source.SpeedModifier;
         Destination.PokeFrontSprite = Source.PokeFrontSprite;
    }
}
