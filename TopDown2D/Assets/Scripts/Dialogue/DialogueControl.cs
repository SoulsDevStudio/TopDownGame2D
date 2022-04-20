using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{

    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;

    private bool isShowing;
    private int index;
    private string[] sentences;

    public static DialogueControl instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else // quando terminan os textos
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                IsShowing = false;
            }
        }
    }

    //chamar a fala do NPC
    public void Speech(string[] txt)
    {
        if (!IsShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            IsShowing = true;
        }
    }
}
