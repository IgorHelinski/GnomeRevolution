using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public GameObject player;
    public GameEvent OnGameStart;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void OnDropEvent(Component sender, object data)
    {
        if (data is GameObject)
        {
            GameObject block = (GameObject)data;
            if (block == this.gameObject)
            {
                player.SetActive(true);
                OnGameStart.Raise(this, this);
            }
        }
    }
}
