using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallShadow : MonoBehaviour, IPointerDownHandler
{
    public Rigidbody2D Rb;
    
    
    private const float Bottom = -2.45f;
    private const float Top = 2.53f;

    [SerializeField] CircleCollider2D col;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] SpriteRenderer _sprite;

    public Plinko plinko;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnMouseDownTouch();
    }

    public void Throw()
    {
        col.enabled = true;
    }

    private void OnMouseDownTouch()
    {
        Debug.Log("Touch");

        if (plinko != null && plinko.ChoosedBall == null)
        {
            plinko.ChooseBall(gameObject);
            col.enabled = false;
            Rb.angularVelocity = 0;
            Rb.velocity = Vector2.zero;
        }
    }

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
}
