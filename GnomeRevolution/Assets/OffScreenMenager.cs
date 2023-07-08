using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenMenager : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemy))
        {
            enemy.OnScreen = false; 
        }
    }
}
