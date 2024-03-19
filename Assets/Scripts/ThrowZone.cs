using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField] Plinko _plinko;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("UpDown");
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        _plinko.TryPullString(eventData.position); 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
        _plinko.TryThrow(eventData.position);
    }
}
