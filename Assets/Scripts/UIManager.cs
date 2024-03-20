using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static Action ChangedMusic;

    [SerializeField] Sounder mus;

    public static bool isMusic => bool.Parse(PlayerPrefs.GetString("music", "true"));
    public void LoadScene(string game)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(game);
    }

    public void ChangeMusic()
    {
        PlayerPrefs.SetString("music", (!isMusic).ToString());
        ChangedMusic?.Invoke();
    }

    private void Start()
    {
        mus.MakeSound();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }
}
