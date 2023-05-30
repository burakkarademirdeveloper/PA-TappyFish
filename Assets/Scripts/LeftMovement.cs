using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    private BoxCollider2D _box;
    private float _gorundWidth;
    private float _obstacleWidth;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            _box = GetComponent<BoxCollider2D>();
            _gorundWidth = _box.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            _obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -_gorundWidth)
            {
                transform.position = new Vector2(transform.position.x + _gorundWidth * 2, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - _obstacleWidth)
            {
                Destroy(gameObject);
            }
        }
    }
}
