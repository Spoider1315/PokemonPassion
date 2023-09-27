using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject PlayerObject;
    Rigidbody2D PlayerBody;
    Transform PlayerPosition;
    public bool PlayerCanMove;
    Vector3 StartingPosition;
    string MovementDirection;
    bool PlayerIsFrozen;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("Player");
        PlayerBody = PlayerObject.GetComponent<Rigidbody2D>();
        PlayerPosition = PlayerObject.transform;
        PlayerCanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerCanMove)
        {
            if(PlayerShouldStop())
            {
                StopPlayer();
            }
        }
        if(PlayerCanMove && Input.GetKey(KeyCode.W))
        {
            MovementDirection = "up";
            PlayerCanMove = false;
            StartingPosition = PlayerPosition.position;
            PlayerBody.velocity = new Vector2(0, 2);
        }
        if (PlayerCanMove && Input.GetKey(KeyCode.S))
        {
            MovementDirection = "down";
            PlayerCanMove = false;
            StartingPosition = PlayerPosition.position;
            PlayerBody.velocity = new Vector2(0, -2);
        }
        if (PlayerCanMove && Input.GetKey(KeyCode.A))
        {
            MovementDirection = "left";
            PlayerCanMove = false;
            StartingPosition = PlayerPosition.position;
            PlayerBody.velocity = new Vector2(-2, 0);
        }
        if (PlayerCanMove && Input.GetKey(KeyCode.D))
        {
            MovementDirection = "right";
            PlayerCanMove = false;
            StartingPosition = PlayerPosition.position;
            PlayerBody.velocity = new Vector2(2, 0);
        }
    }

    bool PlayerShouldStop()
    {
        if(MovementDirection.Equals("up"))
        {
            return PlayerPosition.position.y > StartingPosition.y + 1;
        }
        if (MovementDirection.Equals("down"))
        {
            return PlayerPosition.position.y < StartingPosition.y - 1;
        }
        if (MovementDirection.Equals("left"))
        {
            return PlayerPosition.position.x < StartingPosition.x - 1;
        }
        if (MovementDirection.Equals("right"))
        {
            return PlayerPosition.position.x > StartingPosition.x + 1;
        }
        return true;
    }

    public void StopPlayer()
    {
        PlayerBody.velocity = Vector3.zero;
        if (MovementDirection.Equals("up"))
        {
            PlayerPosition.position = new Vector3(StartingPosition.x, StartingPosition.y + 1, StartingPosition.z);
        }
        if (MovementDirection.Equals("down"))
        {
            PlayerPosition.position = new Vector3(StartingPosition.x, StartingPosition.y - 1, StartingPosition.z);
        }
        if (MovementDirection.Equals("left"))
        {
            PlayerPosition.position = new Vector3(StartingPosition.x - 1, StartingPosition.y, StartingPosition.z);
        }
        if (MovementDirection.Equals("right"))
        {
            PlayerPosition.position = new Vector3(StartingPosition.x + 1, StartingPosition.y, StartingPosition.z);
        }
        if(!PlayerIsFrozen)
        {
            PlayerCanMove = true;
        }
        MovementDirection = "none";
        return;
    }
    public void FreezePlayer()
    {
        PlayerBody.velocity = Vector3.zero;
        PlayerIsFrozen = true;
        PlayerCanMove = false;
        MovementDirection = "none";
        return;
    }
    public void UnfreezePlayer()
    {
        PlayerIsFrozen = false;
    }
}
