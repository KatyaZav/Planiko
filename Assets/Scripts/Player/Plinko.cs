using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plinko : MonoBehaviour
{
    [SerializeField] Sprite[] _sprites;
    [SerializeField] SpriteRenderer _sprite;

    const float _top = -2.11f; 
    const float _bottom = -2.8f;

    /*private void OnMouseExit()
    {
        Throw();
    }*/

    private void OnMouseOver()
    {
        Move();
        PullString();
    }

    void Move()
    {
        var mousePosX = GetMousePos().x;

        var pos = transform.position;
        pos.x = (mousePosX);

        transform.position = pos;
    }

    void PullString()
    {
        var mousePos = GetMousePos();

        var cells = (_top - _bottom) / _sprites.Length;
        var index = (int)((mousePos.y - _bottom) / cells);

        _sprite.sprite = _sprites[index];        
    }
    void Throw()
    {
        _sprite.sprite = _sprites[4];
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        return mousePos;
    }
}
