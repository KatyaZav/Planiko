using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicIcon : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image ren;

    private void OnEnable()
    {
        ChangeIcon();
        UIManager.ChangedMusic += ChangeIcon;
    }

    private void OnDisable()
    {
        UIManager.ChangedMusic -= ChangeIcon;        
    }

    void ChangeIcon()
    {
        if (UIManager.isMusic)
            ren.sprite = sprites[0];
        else
            ren.sprite = sprites[1];
    }
}
