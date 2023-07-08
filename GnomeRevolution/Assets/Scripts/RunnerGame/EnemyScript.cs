using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    bool ready = false;
    float speed;

    public bool OnScreen;

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
}
