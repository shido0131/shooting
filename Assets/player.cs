﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    float ScoreS;
    float RemainingTimeS;
    public Text RemainingTime;
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        RemainingTimeS = 100;
    }

    // Update is called once per frame
    void Update()
    {
        RemainingTimeS -= Time.deltaTime;
        RemainingTime.text = "RemainingTime." + RemainingTimeS.ToString("f2");
        Score.text = "Score." + ScoreS.ToString("f0");
        if (Input.GetKey(KeyCode.A))
        {
            ScoreS += 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.up * 2;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.up * -2;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * 2;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.right * -2;
        }
        if (Input.GetKey(KeyCode.AltGr))
        {

        }
    }
}