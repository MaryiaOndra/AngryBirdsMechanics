using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    const float MAX_FORCE = 20;

    Rigidbody2D rBody2D;
    Vector2 startPos;
    float timeLimit = 3f;

    public bool IsBirdDragEnd { get; private set; }
    public event Action NextBird;

    private void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        rBody2D.bodyType = RigidbodyType2D.Static;
    }

    public void OnDragBegin(BaseEventData _evData)
    {
        var _poinerEv = _evData as PointerEventData;
        startPos = _poinerEv.position;
    }

    public void OnDragEnd(BaseEventData _evData) 
    {
        IsBirdDragEnd = true;

        var _pointerEv = _evData as PointerEventData;
        var _direction = (_pointerEv.position - startPos).normalized * -1;
        rBody2D.bodyType = RigidbodyType2D.Dynamic;
        rBody2D.AddForce(_direction * MAX_FORCE, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball _))
        {
            Debug.Log("TOUCHDOWN");
        }

        Destroy(gameObject, timeLimit);
    }
}
