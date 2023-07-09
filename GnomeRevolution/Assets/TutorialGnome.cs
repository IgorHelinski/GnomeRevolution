using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialGnome : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    [TextArea]
    public string tutorialString1;
    [TextArea]
    public string tutorialString2;

    private void Start()
    {
        textMesh.text = tutorialString1;
    }

    public void OnGameStart(Component sender, object data)
    {
        this.gameObject.SetActive(false);
    }

    public void Continue()
    {
        textMesh.text = tutorialString2;
    }
}
