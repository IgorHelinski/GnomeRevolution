using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerScript playerScript;

    private void Awake()
    {
        if(playerScript == null)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        }
    }

    public void OnDropEvent(Component sender, object data)
    {
        if(data is GameObject)
        {
            GameObject block = (GameObject)data;
            if(block == this.gameObject)
            {
                playerScript.GoForJump();
            }
        }
    }
}
