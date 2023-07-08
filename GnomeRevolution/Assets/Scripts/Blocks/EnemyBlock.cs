using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    [SerializeField] private EnemyGenerator enemyGenerator;

    private void Awake()
    {
        if (enemyGenerator == null)
        {
            enemyGenerator = GameObject.FindGameObjectWithTag("EnemyGenerator").GetComponent<EnemyGenerator>();
        }
    }

    public void OnDropEvent(Component sender, object data)
    {
        if (data is GameObject)
        {
            GameObject block = (GameObject)data;
            if (block == this.gameObject)
            {
                enemyGenerator.GenerateEnemy();
            }
        }
    }
}
