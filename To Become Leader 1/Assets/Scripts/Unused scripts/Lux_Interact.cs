using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lux_Interact : MonoBehaviour
{
    public TextMeshPro textComponent;
    //for collections of different sentences
    public string[] lines;
    //text speed
    public float textSpeed;
    //track where we are in the convo
    public int index;
    public GameObject dialogueBox;

    private void Start() {
        textComponent.text = string.Empty;
        dialogueBox.SetActive(false);
    }

    public void LuxInteract()
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StartTypeLine());
    }

    private IEnumerator StartTypeLine()
    {
        //Takes string and breaks it down to char
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        if(textComponent.text == lines[index])
        {
            StartCoroutine(Wait());
        }
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        dialogueBox.SetActive(false);
        textComponent.text = string.Empty;
    }
}
