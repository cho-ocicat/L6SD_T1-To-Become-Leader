using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem1 : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    //the pop-up 'E'
    public GameObject dialogueGUI;
    //what sets the whole system as active or not
    public Transform dialogueBoxGUI;

    public float textSpeed;
    //public float letterMultiplier; //try the automatic message from Dialogue1

    //get E key as input
    public KeyCode dialogueInput = KeyCode.E;

    //tied to NPC name in NPC_Interact1
    public string characterName;
    public string[] dialogueLines;
    public int index = 0;

    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    //no dialogue unless the player is in range
    public bool outofRange = true;

    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource chatSfx;
    
    void Start()
    {
        chatSfx = GetComponent<AudioSource>();
        dialogueText.text = "";
    }

    void Update()
    {
        
    }

    public void EnterRangeOfNPC()
    {
        outofRange = false;
        dialogueGUI.SetActive(true);
        if (dialogueActive == true)
        {
            //E will pop up until dialogueActive is true
            dialogueGUI.SetActive(false);
        }
    }

    public void NPCName()
    {
        outofRange = false;
        //pop up the dialogue box
        dialogueBoxGUI.gameObject.SetActive(true);
        nameText.text = characterName;

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!dialogueActive)
            {
                dialogueActive = true;
                StartCoroutine(StartDialogue());
            }
        }

        StartDialogue();
    }

    IEnumerator StartDialogue()
    {
        if(outofRange == false)
        {
            int dialogueLength = dialogueLines.Length;

            while(index < dialogueLength)
            {
                NextDialogue();

                if(index >= dialogueLength)
                {
                    dialogueEnded = true;
                }
               
            }
            yield return 0;

            while (true)
            {
                if(Input.GetKeyDown(dialogueInput) && dialogueEnded == false)
                {
                    break;
                }
                yield return 0;
            }

            dialogueEnded = false;
            dialogueActive = false;
            NextDialogue();
            DropDialogue();
        }
    }

    public void NextDialogue()
    {
        //if the line finished appearing, go to next line. If not, put the whole line instantly
        if(dialogueText.text == dialogueLines[index])
        {
            StartCoroutine(DisplayString(dialogueLines[index++]));
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[index];
        }
    }

    IEnumerator DisplayString(string stringToDisplay)
    {
        if(outofRange == false)
        {
            int stringLength = stringToDisplay.Length;
            index = 0;
            dialogueText.text = "";

            while (index < stringLength)
            {
                dialogueText.text += stringToDisplay[index];
                index++;

                if(index < stringLength)
                {
                    if(Input.GetKey(dialogueInput))
                    {
                        yield return new WaitForSeconds(textSpeed);
                        if (audioClip) chatSfx.PlayOneShot(audioClip, 0.5f);
                    }
                }
                else{
                    dialogueEnded = false;
                    break;
                }
            }

            while (true)
            {
                if(Input.GetKey(dialogueInput))
                {
                    break;
                }
            }
            yield return 0;

            dialogueEnded = false;
            dialogueText.text = "";
        }
    }

    public void DropDialogue()
    {
        dialogueGUI.SetActive(false);
        dialogueBoxGUI.gameObject.SetActive(false);
    }

    public void OutofRange()
    {
        outofRange = true;
        if (outofRange == true) {
            {
                dialogueActive = false;
                StopAllCoroutines();
                dialogueGUI.SetActive(false);
                dialogueBoxGUI.gameObject.SetActive(false);
            }
        }
    }
}
