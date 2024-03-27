using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    public UnityEvent eventEnd;
    public TextMeshProUGUI timerText;

    public static Timer Instance;

    public int a = 30;

    void OnEnable()
    {
        Instance = this;
        StartCoroutine(TimerCor());
    }


    IEnumerator TimerCor()
    {
        while (a >= 0)
        {
            timerText.text = a.ToString();
            yield return new WaitForSeconds(1);
            a--;
        }

        eventEnd?.Invoke();
    }
}
