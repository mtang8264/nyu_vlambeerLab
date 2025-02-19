﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CameraController : MonoBehaviour
{
    public float defaultX, defaultY;
    public float defaultSize;

    public Slider zoomSlider, leftRightSlider, topBotSlider;
    public TextMeshProUGUI zoomText;

    public Slider maxSlider;
    public TextMeshProUGUI maxText;

    void Start()
    {
        maxSlider.value = Pathmaker.max;
    }

    void Update()
    {
        Pathmaker.max = (int)maxSlider.value;
        maxText.text = "" + Pathmaker.max;

        defaultX = (Pathmaker.left + Pathmaker.right) / 2;
        defaultY = (Pathmaker.top + Pathmaker.bot) / 2;

        transform.position = new Vector3(Mathf.Lerp(Pathmaker.left, Pathmaker.right, leftRightSlider.value), 100, Mathf.Lerp(Pathmaker.top, Pathmaker.bot, topBotSlider.value)); ;

        zoomText.text = "" + (Mathf.Round(zoomSlider.value * 100) / 100) + "x";

        defaultSize = (Pathmaker.top - Pathmaker.bot) / 5 * 3;

        GetComponent<Camera>().orthographicSize = defaultSize / zoomSlider.value ;


        if (GetComponent<Camera>().orthographicSize < float.Epsilon)
        {
            GetComponent<Camera>().orthographicSize = 3 / zoomSlider.value;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Pathmaker.top = 0;
            Pathmaker.bot = 0;
            Pathmaker.left = 0;
            Pathmaker.right = 0;
            Pathmaker.totalCounter = 0;
            SceneManager.LoadScene(0);
        }
    }
}
