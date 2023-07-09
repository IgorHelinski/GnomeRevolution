using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public Transform slotsTransform;
    public float minBuffer;
    public float maxBuffer;

    public float time;
    
    public void OnGameStart(Component sender, object data)
    {
        Debug.Log("Start");
        StartCoroutine(GameCycle());
    }

    private IEnumerator GameCycle()
    {
        while (true)
        {
            float randomBuffer = Random.Range(minBuffer, maxBuffer);
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            Instantiate(blockPrefabs[randomIndex], slotsTransform);
            Debug.Log("Spawning");
            time = randomBuffer;
            yield return new WaitForSeconds(randomBuffer);
        }
    }

    public void GameOver(Component sender, object data)
    {
        StopCoroutine(GameCycle());
        Debug.Log("Gaaame overrr");
        SceneManager.LoadScene(2);
    }
}
