﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairScript : MonoBehaviour
{
    #region Singleton

    public static StairScript instance;

    private void Awake()
    {
        instance = new StairScript();
        instance = this;
    }

    #endregion

    //public CharacterExperience exp;

    public GameObject groundStairs;
    public GameObject middleStairs;
    public GameObject gate;

    private void Start()
    {
        hideStairs();
    }

    public void spawnSteps()
    {
        if (PlayerStats.instance.GetComponent<CharacterExperience>().xp >= 15)
        {
            groundStairs.SetActive(true);
        }

        if (PlayerStats.instance.GetComponent<CharacterExperience>().xp >= 30)
        {
            middleStairs.SetActive(true);
            gate.SetActive(true);

        }
    }

    public void hideStairs()
    {
        groundStairs.SetActive(false);
        middleStairs.SetActive(false);
        gate.SetActive(false);
    }
}
