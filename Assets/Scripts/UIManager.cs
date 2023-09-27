using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject Button1;
    GameObject Button2;
    GameObject Button3;
    GameObject Button4;
    // Start is called before the first frame update
    void Start()
    {

        Button1 = GameObject.Find("Button1");
        Button2 = GameObject.Find("Button2");
        Button3 = GameObject.Find("Button3");
        Button4 = GameObject.Find("Button4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMoves()
    {

    }

    public void AddListenerTo(int ButtonId, UnityAction function)
    {
        switch (ButtonId)
        {
            case 1:
                Button1.GetComponent<Button>().onClick.AddListener(function);
                break;
            case 2:
                Button2.GetComponent<Button>().onClick.AddListener(function);
                break;
            case 3:
                Button3.GetComponent<Button>().onClick.AddListener(function);
                break;
            case 4:
                Button4.GetComponent<Button>().onClick.AddListener(function);
                break;
        }
    }
    public void RemoveListenerFrom(int ButtonId, UnityAction function)
    {
        switch (ButtonId)
        {
            case 1:
                Button1.GetComponent<Button>().onClick.RemoveListener(function);
                break;
            case 2:
                Button2.GetComponent<Button>().onClick.RemoveListener(function);
                break;
            case 3:
                Button3.GetComponent<Button>().onClick.RemoveListener(function);
                break;
            case 4:
                Button4.GetComponent<Button>().onClick.RemoveListener(function);
                break;
        }
    }

    public void SetTextOnButton(int ButtonId, string text)
    {
        switch (ButtonId)
        {
            case 1:
                Button1.transform.GetChild(0).GetComponent<Text>().text = text;
                break;
            case 2:
                Button2.transform.GetChild(0).GetComponent<Text>().text = text;
                break;
            case 3:
                Button3.transform.GetChild(0).GetComponent<Text>().text = text;
                break;
            case 4:
                Button4.transform.GetChild(0).GetComponent<Text>().text = text;
                break;
        }
    }
}
