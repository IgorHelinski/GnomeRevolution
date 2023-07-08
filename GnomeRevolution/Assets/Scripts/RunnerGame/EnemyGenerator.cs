using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private void Start()
    {
        //GenerateEnemy();
    }

    public void GenerateEnemy()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, transform.position, transform.rotation);

        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        enemyInstance.GetComponent<EnemyScript>().StartMovement(randomSpeed);
    }
}
