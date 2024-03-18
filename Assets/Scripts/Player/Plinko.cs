using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plinko : MonoBehaviour
{
    [SerializeField] float _force;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] SpriteRenderer _sprite;

    const float _top = -1.9f; 
    const float _bottom = -2.6f;

    /*private void OnMouseExit()
    {
        Throw();
    }*/

    /*private void OnMouseOver()
    {
        Move();
        PullString();
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        Move();
    }

    void Move()
    {
        if (Mouse.Ball == null)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("throw");
            Mouse.Ball.Rb.AddForce(Vector2.up * (GetIndex()+0.2f)*_force, ForceMode2D.Impulse);
            Mouse.Ball = null;
            Throw();
            return;
        }

        var mousePosX = Mouse.GetMousePos().x;

        var pos = transform.position;
        pos.x = (mousePosX);

        if (pos.x > 0.4f || pos.x < -0.3f)
        {
            Throw();
            return;
        }

        PullString();        
        transform.position = pos;
    }

    void PullString()
    {
        var index = GetIndex();

        index = index > _sprites.Length-1 ? _sprites.Length-1 : index;
        index = index < 0 ? 0 : index;

        _sprite.sprite = _sprites[index];        
    }

    int GetIndex() {
        var mousePos = Mouse.GetMousePos();

        var cells = (_top - _bottom) / _sprites.Length;
        return (int)((mousePos.y - _bottom) / cells);
    }

    void Throw()
    {
        _sprite.sprite = _sprites[4];
    }    
}
