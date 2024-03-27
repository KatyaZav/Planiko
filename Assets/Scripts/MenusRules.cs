using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusRules : MonoBehaviour
{
    public GameObject gameUI;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        gameUI.SetActive(true);
    }
}
