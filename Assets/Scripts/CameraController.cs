using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject CameraObject;
    Transform CameraPosition;
    GameObject PlayerObject;
    Transform PlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        CameraObject = GameObject.Find("Main Camera");
        CameraPosition = CameraObject.transform;
        PlayerObject = GameObject.Find("Player");
        PlayerPosition = PlayerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosition.position = new Vector3(PlayerPosition.position.x, PlayerPosition.position.y, -10);
    }
}
