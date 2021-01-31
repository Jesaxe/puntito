using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speedFactor;
    private Vector2 _pointA, _pointB, _pointC, _pointD;
    private Vector2 _poslastFrame;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _pointA = transform.GetChild(0).position;
        _pointB = transform.GetChild(1).position;
        transform.position = _pointA;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x = _pointA.x + Mathf.PingPong(Time.time * speedFactor, _pointB.x - _pointA.x);
        transform.position = pos;
        if (transform.position.x < _poslastFrame.x)
        {
            _sprite.flipX = true;
        }
        else if (transform.position.x > _poslastFrame.x)
        {
            _sprite.flipX = false;
        }
        _poslastFrame = transform.position;

    }
}
