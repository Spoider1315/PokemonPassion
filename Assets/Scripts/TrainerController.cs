using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainerController : MonoBehaviour
{
    GameObject PlayerObject;
    Transform PlayerPosition;
    public GameObject TrainerObject;
    Rigidbody2D TrainerBody;
    Transform TrainerPosition;
    public int BattleRange;
    public string TrainerDirection;
    bool TrainerIsMoving;
    bool Battled;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("Player");
        PlayerPosition = PlayerObject.transform;
        TrainerBody = TrainerObject.GetComponent<Rigidbody2D>();
        TrainerPosition = TrainerObject.transform;
        TrainerIsMoving = false;
        Battled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Battled && !TrainerIsMoving && IsInRange())
        {
            StartCoroutine(InitiateBattle());
        }
    }
    bool IsInRange()
    {
        if (TrainerDirection.Equals("up"))
        {
            return (PlayerPosition.position.y >= TrainerPosition.position.y + BattleRange) && PlayerPosition.position.x == TrainerPosition.position.x;
        }
        if (TrainerDirection.Equals("down"))
        {
            return (PlayerPosition.position.y <= TrainerPosition.position.y - BattleRange) && PlayerPosition.position.x == TrainerPosition.position.x;
        }
        if (TrainerDirection.Equals("left"))
        {
            return (PlayerPosition.position.x >= TrainerPosition.position.x - BattleRange) && PlayerPosition.position.y == TrainerPosition.position.y;
        }
        if (TrainerDirection.Equals("right"))
        {
            return (PlayerPosition.position.x <= TrainerPosition.position.x + BattleRange) && PlayerPosition.position.y == TrainerPosition.position.y;
        }
        return false;
    }

    public IEnumerator InitiateBattle()
    {
        TrainerIsMoving = true;
        PlayerObject.GetComponent<PlayerController>().FreezePlayer();
        PlayerObject.GetComponent<PlayerController>().PlayerCanMove = false;
        if(TrainerDirection.Equals("up"))
        {
            TrainerBody.velocity = new Vector2(0, 2);
            while(Math.Abs(TrainerPosition.position.y - PlayerPosition.position.y) > 1)
            {
                yield return null;
            }
        }
        if (TrainerDirection.Equals("down"))
        {
            TrainerBody.velocity = new Vector2(0, -2);
            while (Math.Abs(TrainerPosition.position.y - PlayerPosition.position.y) > 1)
            {
                yield return null;
            }
        }
        if (TrainerDirection.Equals("left"))
        {
            TrainerBody.velocity = new Vector2(-2, 0);
            while (Math.Abs(TrainerPosition.position.x - PlayerPosition.position.x) > 1)
            {
                yield return null;
            }
        }
        if (TrainerDirection.Equals("right"))
        {
            TrainerBody.velocity = new Vector2(2, 0);
            while (Math.Abs(TrainerPosition.position.x - PlayerPosition.position.x) > 1)
            {
                yield return null;
            }
        }
        TrainerBody.velocity = new Vector2(0, 0);
        TrainerIsMoving = false;
        Battled = true;
        LoadSampleBattle();
    }
    public void LoadSampleBattle()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
