using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameResult : MonoBehaviour
{
    public GameObject endScreen;
    public TextMeshProUGUI resultText;

    //area of the text, 5 lines down, 10 characters right across
    [TextArea(5,10)]
    public string[] lines;
    public float textSpeed;
    //track where we are in the convo
    public int index;

    [SerializeField] AudioClip audioClip;
    AudioSource chatSfx;
    [SerializeField] AudioSource winSfx;
    [SerializeField] AudioSource loseSfx;

    void Start()
    {
        endScreen.SetActive(false);
        chatSfx = GetComponent<AudioSource>();
        resultText.text = string.Empty;
    }

    void Update()
    {
        
    }

    public void Winning()
    {
        endScreen.SetActive(true);
        winSfx.Play();
        index = 0;
        StartCoroutine(TypeLine());
        
    }

    public void Losing()
    {
        endScreen.SetActive(true);
        loseSfx.Play();
        index = 1;
        StartCoroutine(TypeLine());
        
    }

    private IEnumerator TypeLine()
    {
        //Takes string and breaks it down to char
        foreach (char c in lines[index].ToCharArray())
        {
            resultText.text += c;
            yield return new WaitForSeconds(textSpeed);
            if (audioClip) chatSfx.PlayOneShot(audioClip, 0.5f);
        }
    }
}
