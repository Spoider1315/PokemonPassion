using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BattleManager : MonoBehaviour
{
    Pokemon ActivePokemon;
    UIManager UiManager;
    // Start is called before the first frame update
    void Start()
    {
        ActivePokemon = GameObject.Find("ActivePokemon").GetComponent<Pokemon>();
        UiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        UiManager.AddListenerTo(1, SelectFight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Move ChooseMove(Pokemon Enemy)
    {
        int FilledMoves  = 1;
        if(Enemy.Move1 != null)
            FilledMoves++;
        if(Enemy.Move2 != null)
            FilledMoves++;
        if(Enemy.Move3 != null)
            FilledMoves++;
        if(Enemy.Move4 != null)
            FilledMoves++;
        int MoveToUse = Random.Range(1,FilledMoves);
        if(MoveToUse == 1)
        {
            return Enemy.Move1;
        }
        else if(MoveToUse == 2)
        {
            return Enemy.Move2;
        }
        else if(MoveToUse == 3)
        {
            return Enemy.Move3;
        }
        else
        {
            return Enemy.Move4;
        }
    }

    public void SelectFight()
    {
        Debug.Log("Selecting");
        UiManager.RemoveListenerFrom(1, SelectFight);
        if(ActivePokemon.Move1 != null)
        {
            UiManager.SetTextOnButton(1, ActivePokemon.Move1.Name);
            UiManager.AddListenerTo(1, delegate{SelectMove(ActivePokemon.Move1, ActivePokemon, GameObject.Find("ActiveOpponent").GetComponent<Pokemon>());});
        }
        else
        {
            UiManager.SetTextOnButton(1 ,"");
        }
        if(ActivePokemon.Move2 != null)
        {
            UiManager.SetTextOnButton(2, ActivePokemon.Move2.Name);
            UiManager.AddListenerTo(2, delegate { SelectMove(ActivePokemon.Move2, ActivePokemon, GameObject.Find("ActiveOpponent").GetComponent<Pokemon>()); });
        }
        else
        {
            UiManager.SetTextOnButton(2, "");
        }
        if(ActivePokemon.Move3 != null)
            UiManager.SetTextOnButton(3, ActivePokemon.Move3.Name);
        else
        {
            UiManager.SetTextOnButton(3, "");
        }
        if(ActivePokemon.Move4 != null)
            UiManager.SetTextOnButton(4, ActivePokemon.Move4.Name);
        else
        {
            UiManager.SetTextOnButton(4, "");
        }
    }
    public void SelectMove(Move MoveUsed, Pokemon User, Pokemon Target)
    {
        if(User.Speed > Target.Speed)
        {
            StartCoroutine(MovePlayerFirst(MoveUsed, User, Target));
        }
        else if(User.Speed < Target.Speed)
        {
            StartCoroutine(MovePlayerLast(MoveUsed, User, Target));
        }
        else if(Random.Range(0,2) == 0)
        {
            StartCoroutine(MovePlayerFirst(MoveUsed, User, Target));
        }
        else
        {
            StartCoroutine(MovePlayerLast(MoveUsed, User, Target));
        }
    }

    public IEnumerator MovePlayerFirst(Move MoveUsed, Pokemon User, Pokemon Target)
    {
        MoveUsed.Use(User, Target, "Opponent");
        yield return new WaitForSeconds(1);
        ChooseMove(Target).Use(Target, User, "User");
    }
    public IEnumerator MovePlayerLast(Move MoveUsed, Pokemon User, Pokemon Target)
    {
        ChooseMove(Target).Use(Target, User, "User");
        yield return new WaitForSeconds(1);
        MoveUsed.Use(User, Target, "Opponent");
    }
}
