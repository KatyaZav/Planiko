using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounder : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    [SerializeField] AudioSource _sorse;

    private void OnEnable()
    {
        UIManager.ChangedMusic += Mus;
        _sorse.volume = 0.3f;
    }

    void Mus()
    {
        if (UIManager.isMusic == false)
        {
            _sorse.Pause();
            _sorse.mute = true;
        }
        else
        {
            _sorse.Play();
            _sorse.mute = false;
        }
    }

    public void MakeSound()
    {
        if (UIManager.isMusic == false)
            return;

        _sorse.pitch = Random.Range(0.7f, 1);
        _sorse.PlayOneShot(_clip);
    }
}
