using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    private BoxCollider2D _box;
    private float _gorundWidth;
    void Start()
    {
        _box = GetComponent<BoxCollider2D>();
        _gorundWidth = _box.size.x;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (transform.position.x <= -_gorundWidth)
        {
            transform.position = new Vector2(transform.position.x + _gorundWidth * 2, transform.position.y);
        }
    }
}
