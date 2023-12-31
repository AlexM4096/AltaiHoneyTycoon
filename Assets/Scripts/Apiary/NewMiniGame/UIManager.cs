using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    public TextMeshProUGUI TextCountLiveBees;
    public TextMeshProUGUI TextCountHoneyInHive;
    private int CountLiveBees;
    private int CountHoneyInHive;
    void Start()
    {
        CountLiveBees = SpawnBeeMiniGame.CountLiveBees;
        CountHoneyInHive = SpawnBeeMiniGame.CountHoneyInHive;
        UpdateTimerDisplay();
    }

    void FixedUpdate()
    {
        UpdateTimerDisplay();
        if (CountLiveBees == 0)
        {
            SceneLoader.LoadMenuScene();
        }

    }
    void UpdateTimerDisplay()
    {
        CountLiveBees = SpawnBeeMiniGame.CountLiveBees;
        CountHoneyInHive = SpawnBeeMiniGame.CountHoneyInHive;
        TextCountLiveBees.text = CountLiveBees.ToString();
        TextCountHoneyInHive.text = CountHoneyInHive.ToString();
    }
}
