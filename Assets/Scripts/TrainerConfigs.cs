using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainerConfigs : MonoBehaviour
{
    string CurrentScene;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene().name;
        if (CurrentScene.Equals("SampleOverworld"))
        {
            TrainerController ThisTrainer = GameObject.Find("TestTrainer").GetComponent<TrainerController>();
            ConfigTrainer(ThisTrainer, GameObject.Find("TestTrainer"), 7, "left");
        }
    }
    void ConfigTrainer(TrainerController Trainer, GameObject TrainerObject, int BattleRange, string TrainerDirection)
    {
        Trainer.TrainerObject = TrainerObject;
        Trainer.BattleRange = BattleRange;
        Trainer.TrainerDirection = TrainerDirection;
    }
}
