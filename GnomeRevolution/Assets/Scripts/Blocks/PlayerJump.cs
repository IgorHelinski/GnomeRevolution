using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public bool alreadyUsed = false;

    [SerializeField] private PlayerScript playerScript;

    private void Awake()
    {
        if(playerScript == null)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            alreadyUsed = false;
        }
    }

    public void OnDropEvent(Component sender, object data)
    {
        if(data is GameObject)
        {
            GameObject block = (GameObject)data;
            if(block == this.gameObject && alreadyUsed == false)
            {
                playerScript.GoForJump();
                alreadyUsed = true;
            }
        }
    }
}
