using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    bool ready = false;
    float speed;

    public bool OnScreen;
    public GameEvent OnGameOver;

    public void StartMovement(float _speed)
    {
        speed = _speed;
        ready = true;
        OnScreen = true;
    }

    private void Update()
    {
        if (ready)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerScript>(out PlayerScript player))
        {
            OnGameOver.Raise(this, this);
        }
    }
}
