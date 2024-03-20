using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallShadow : MonoBehaviour, IPointerDownHandler
{
    public Rigidbody2D Rb;    
    
    private const float Bottom = -2.45f;
    private const float Top = 2.53f;

    //[SerializeField] CircleCollider2D col;
    [SerializeField] Sounder _sounder;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] SpriteRenderer _sprite;

    public Plinko plinko;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //var ball = collision.gameObject.GetComponent<BallShadow>();
        if (collision.gameObject.CompareTag("ball"))
        {
            _sounder.MakeSound();
            ChangeVelocity(Rb);           
        }
    }

    void ChangeVelocity(Rigidbody2D rb)
    {
        var rnd = rb.velocity.x + rb.velocity.y;

        float x = Random.Range(-rnd, rnd) * 1.1f;
        var y = Random.Range(-rnd, rnd)*1.1f;

        rb.velocity = new Vector2(x, y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnMouseDownTouch();
    }

    public void Throw()
    {
        
        //col.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("ball");
        Rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnMouseDownTouch()
    {
        Debug.Log("Touch");

        if (plinko != null && plinko.ChoosedBall == null)
        {
            Rb.bodyType = RigidbodyType2D.Static;
            gameObject.layer = LayerMask.NameToLayer("ball_collected"); 
            plinko.ChooseBall(gameObject);
            //col.enabled = false;
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
