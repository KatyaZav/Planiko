using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinMenu : MonoBehaviour
{
    public static WinMenu Instance;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject gameUI;

    [SerializeField] GameObject timePopup;
    [SerializeField] TextMeshProUGUI timeText;

    [SerializeField] Sprite[] sprites;
    [SerializeField] Image imageSprites;

    [SerializeField] Plinko top, bottom;

    public void Win(string a)
    {
        winMenu.SetActive(true);
        gameUI.SetActive(false);
        text.text = bottom.GetListCounts + ":" + top.GetListCounts;
        Time.timeScale = 0;

        var time = Timer.Instance.a;
        timeText.text = time.ToString() + (time == 1 ? " second " : " seconds ") + "left";
    }

    public void Lose()
    {
        winMenu.SetActive(true);
        gameUI.SetActive(false);

        text.text = bottom.GetListCounts + ":" + top.GetListCounts;
        imageSprites.sprite = sprites[1];
        timePopup.SetActive(false);

    }

    private void Start()
    {
        Instance = this;   
    }
}
