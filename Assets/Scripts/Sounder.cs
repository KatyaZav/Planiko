using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounder : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    [SerializeField] AudioSource _sorse;

    public void MakeSound()
    {
        _sorse.pitch = Random.Range(0.7f, 1);
        _sorse.PlayOneShot(_clip);
    }
}
