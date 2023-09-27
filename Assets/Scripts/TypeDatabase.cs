using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeDatabase : MonoBehaviour
{
    public Type Normal;
    public Type Fire;
    public Type Water;
    public Type Electric;
    public Type Grass;
    public Type Ice;
    public Type Fighting;
    public Type Poison;
    public Type Ground;
    public Type Flying;
    public Type Psychic;
    public Type Bug;
    public Type Rock;
    public Type Ghost;
    public Type Dragon;
    public Type Dark;
    public Type Steel;
    public Type Fairy;

    // Start is called before the first frame update
    void Start()
    {
        Normal = new Type("Normal");
        Fire = new Type("Fire");
        Water = new Type("Water");
        Electric = new Type("Electric");
        Grass = new Type("Grass");
        Ice = new Type("Ice");
        Fighting = new Type("Fighting");
        Poison = new Type("Poison");
        Ground = new Type("Ground");
        Flying = new Type("Flying");
        Psychic = new Type("Psychic");
        Bug = new Type("Bug");
        Rock = new Type("Rock");
        Ghost = new Type("Ghost");
        Dragon = new Type("Dragon");
        Dark = new Type("Dark");
        Steel = new Type("Steel");
        Fairy = new Type("Fairy");
    }
}
