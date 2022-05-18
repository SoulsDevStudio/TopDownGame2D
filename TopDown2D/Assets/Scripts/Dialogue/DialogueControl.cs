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
    private string[] actorNames;
    private Sprite[] actorProfiles;
    private Player player;

    public static DialogueControl instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<Player>();
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
                profileSprite.sprite = actorProfiles[index];
                actorNameText.text = actorNames[index];
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else // quando terminan os textos
            {
                speechText.text = "";
                actorNameText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                IsShowing = false;
                player.isPaused = false;
            }
        }
    }

    //chamar a fala do NPC
    public void Speech(string[] txt, string[] actorName, Sprite[] actorProfile)
    {
        if (!IsShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            actorNames = actorName;
            actorProfiles = actorProfile;
            profileSprite.sprite = actorProfiles[index];
            actorNameText.text = actorNames[index];
            StartCoroutine(TypeSentence());
            IsShowing = true;
            player.isPaused = true;
        }
    }
}
