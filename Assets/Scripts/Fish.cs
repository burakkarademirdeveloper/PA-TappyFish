using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    private int _angle;
    private int _maxAngle = 20;
    private int _minAngle = -60;
    public Score score;
    private bool _touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    private SpriteRenderer sp;
    private Animator _anim;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, speed);
        }
    }

    private void FixedUpdate()
    {
        if (_rb.velocity.y > 0)
        {
            if (_angle <= _maxAngle)
            {
                _angle = _angle + 4;
            }
        }
        else if (_rb.velocity.y < -2.5f)
        {
            if (_angle > _minAngle )
            {
                _angle = _angle - 2;
            }
        }

        if (_touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, _angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            score.Scored();
        }else if (other.CompareTag("Column"))
        {
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        _touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        _anim.enabled = false;
    }
}
