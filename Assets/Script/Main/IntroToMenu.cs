using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroToMenu : MonoBehaviour
{
    public GameObject canvas_1;
    public GameObject canvas_2;

    void OnEnable()
    {
        canvas_1.SetActive(false);
        canvas_2.SetActive(true);
    }
}
