using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Interactable : MonoBehaviour
{
    public TextMeshPro textComponent;
    //for collections of different sentences
    //public TextMeshProUGUI theTimer;
    public UI_Timer1 getResult;
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

    public void Interact () 
    {
        index = 0;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeLine());
        //GameObject.Find("TimerManager").SendMessage("Result");
    }

    private IEnumerator TypeLine()
    {
        //Takes string and breaks it down to char
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        // if(textComponent.text == lines[index])
        // {
        //     StartCoroutine(Wait());
        // }
        
    }
    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            
        }
        else
        {
            dialogueBox.SetActive(false);
            textComponent.text = string.Empty;
        }

        
    }


}
