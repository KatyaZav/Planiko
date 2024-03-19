using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plinko : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] GameObject[] _colliders;
    [SerializeField] GameObject currentCollider;

    [SerializeField] float _force;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] SpriteRenderer _sprite;

    [SerializeField] Transform[] _ballZones;

    [SerializeField] Transform _top;
    [SerializeField] Transform _bottom;
    [SerializeField] Transform _ballZone;

    [SerializeField] BoxCollider2D col;

    private List<BallShadow> balls = new List<BallShadow>();

    public BallShadow ChoosedBall;

    public void ChooseBall(GameObject obj)
    {
        col.enabled = true;

        obj.transform.SetParent(_ballZone);        
        obj.transform.position = _ballZone.position;

        ChoosedBall = obj.GetComponent<BallShadow>();

        AddBall(ChoosedBall);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.gameObject.GetComponent<BallShadow>();
        AddBall(ball);

        if (balls.Count==4)
        {
            Debug.Log("Win!");
        }
    }

    void AddBall(BallShadow ball)
    {
        ball.plinko = this;
        balls.Add(ball);

        tmp.text = balls.Count.ToString();
    }
    void RemoveBall(BallShadow ball)
    {
        balls.Remove(ball);
        tmp.text = balls.Count.ToString();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var ball = collision.gameObject.GetComponent<BallShadow>();
        //ball.plinko = null;
        RemoveBall(ball);
    }

  
    public void TryPullString(Vector2 vec)
    {
        if (ChoosedBall == null)
            return;

        PullString(vec);
    }

    public void TryThrow(Vector2 mouse)
    {
        if (ChoosedBall == null)
            return;

        Throw(mouse);
    }

    public void PullString(Vector2 vec)
    {
        int index = GetIndex(vec);

        _sprite.sprite = _sprites[index];
        _ballZone.transform.position = _ballZones[index].position;
        ChangeCollider(index);
    }

    int GetIndex() {
        var mousePos = Mouse.Ball;

        var cells = (_top.position.y - _bottom.position.y) / _sprites.Length;
        return (int)((Mouse.Ball.transform.position.y - _bottom.position.y) / cells);
    }

    int GetIndex(Vector2 mouse)
    {
        var mousePos = GetMouseWorldPosition(mouse);

        var cells = (_top.position.y - _bottom.position.y) / _sprites.Length;
        var index = (int)((mousePos.y - _bottom.position.y) / cells);

        index = index > _sprites.Length - 1 ? _sprites.Length - 1 : index;
        index = index < 0 ? 0 : index;

        return index;
    }

    Vector3 GetMouseWorldPosition(Vector2 mouse)
    {
        var mousePos = Camera.main.ScreenToWorldPoint(mouse);
        mousePos.z = 0;

        return mousePos;
    }

    void Throw(Vector2 mouse)
    {
        col.enabled = false;

        ChoosedBall.Throw();
        RemoveBall(ChoosedBall);
        ChoosedBall.transform.parent = (null);
        ChoosedBall.Rb.AddForce(transform.up * (4-GetIndex(mouse)) * _force * 1.5f, ForceMode2D.Impulse);
        //ChoosedBall.Rb.AddForce(Vector2.up * GetIndex(mouse) * _force, ForceMode2D.Impulse);

        ChoosedBall = null;

        int x = GetIndex(mouse);

        //_sprite.sprite = _sprites[4];
        //_ballZone.transform.position = _ballZones[4].position;
        //ChangeCollider(4);

        StartCoroutine(ChangeStateThrow(x));
    }    

    IEnumerator ChangeStateThrow(int x)
    {
        while (x <= 4)
        {
            ChangeState(x);
            yield return new WaitForSeconds(0.02f);
            x++;
        }
    }

    void ChangeCollider(int a)
    {
        currentCollider.SetActive(false);
        currentCollider = _colliders[a];
        currentCollider.SetActive(true);
    }

    void ChangeState(int index)
    {
        //Debug.Log(index);
        _sprite.sprite = _sprites[index];
        _ballZone.transform.position = _ballZones[index].position;
        ChangeCollider(index);
    }
}
