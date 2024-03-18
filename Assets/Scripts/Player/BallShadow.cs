using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShadow : MonoBehaviour
{
    public Rigidbody2D Rb;
    
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

        index = index > _sprites.Length - 1 ? _sprites.Length - 1 : index;
        index = index < 0 ? 0 : index;

        _sprite.sprite = _sprites[index];
    }

    private void OnMouseDrag()
    {
        var pos = Mouse.GetMousePos();

        if (pos.x <= -1.45f || pos.x >= 1.45f || pos.y >= -0.45f || pos.y <= -2.45f)
            return;

        transform.position = pos;
        Mouse.Ball = this;
    }
}
