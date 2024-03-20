using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinMenu : MonoBehaviour
{
    public static WinMenu Instance;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject winMenu;

    public void Win(string a)
    {
        winMenu.SetActive(true);
        text.text = a;
        Time.timeScale = 0;
    }
    private void Start()
    {
        Instance = this;   
    }
}
