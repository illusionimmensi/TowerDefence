﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver ;

    public GameObject gameOverUI;

    public GameObject CompleteLevelUI;

    void Start()
    {
        GameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame ()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void Winlevel ()
    {
        GameIsOver = true;
        CompleteLevelUI.SetActive(true);
    }
}
