using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    const float MAX_FORCE = 12;

    Rigidbody2D rBody2D;
    BirdController birdController;
    Vector2 startPos;
    float lifeTime = 3f;

    private void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        rBody2D.bodyType = RigidbodyType2D.Static;
        birdController = FindObjectOfType<BirdController>();
    }

    public void OnDragBegin(BaseEventData _evData)
    {
        var _poinerEv = _evData as PointerEventData;
        startPos = _poinerEv.position;
    }

    public void OnDragEnd(BaseEventData _evData) 
    {
        birdController.CreateNextBird();

        var _pointerEv = _evData as PointerEventData;
        var _direction = (_pointerEv.position - startPos).normalized * -1;
        rBody2D.bodyType = RigidbodyType2D.Dynamic;
        rBody2D.AddForce(_direction * MAX_FORCE, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball _))
        {
            birdController.CatchBall();
            Destroy(gameObject);
        }
        else if (!collision.gameObject.TryGetComponent(out Bird _))
        {
            Destroy(gameObject, lifeTime);
        }
    }
}
