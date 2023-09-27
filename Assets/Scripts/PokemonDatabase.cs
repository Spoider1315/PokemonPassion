using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonDatabase : MonoBehaviour
{
    public Pokemon Bulbasaur;
    // Start is called before the first frame update
    void Start()
    {
        TypeDatabase Types = GameObject.Find("TypeDatabase").GetComponent<TypeDatabase>();
        Bulbasaur = gameObject.AddComponent<Pokemon>();
        Bulbasaur.Name = "Bulbasaur";
        Bulbasaur.Type1 = Types.Grass;
        Bulbasaur.Type2 = null;

        Bulbasaur.BaseHP = 45;
        Bulbasaur.BaseAttack = 49;
        Bulbasaur.BaseDefense = 49;
        Bulbasaur.BaseSpecialAttack = 65;
        Bulbasaur.BaseSpecialDefense = 65;
        Bulbasaur.BaseSpeed = 45;

        Bulbasaur.SetEVS(0,0,0,0,0,0);

        Bulbasaur.SetModifiers(1,1,1,1,1);

        Bulbasaur.PokeFrontSprite = Resources.Load<Sprite>("Sprites/BulbasaurFrontSprite");
    }
}
