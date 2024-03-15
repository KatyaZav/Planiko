using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShadow : MonoBehaviour
{
    private const float Bottom = -2.45f;
    private const float Top = 2.53f;

    [SerializeField] Sprite[] _sprites;
    [SerializeField] SpriteRenderer _sprite;

    private void Update()
    {
        ChangeShadow();
    }

    public void ChangeShadow()
    {
        var cells = (Top - Bottom) / _sprites.Length;
        var index = (int)((transform.position.y - Bottom) / cells);

        Debug.Log(index);
        _sprite.sprite = _sprites[index];
    }
}
