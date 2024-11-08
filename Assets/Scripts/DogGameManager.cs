using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DogGameManager : MonoBehaviour
{
    public List<string> words;
    public TextMeshProUGUI instructionText;
    public Button[] wordButtons;
    public GameObject background2; 

    private List<string> selectedWords=new List<string>();
    private Animator background2Animator;
    private string correctSentence = "Play with Dog"; 

    void Start()
    {
        words=new List<string> {"Play","Eat","Dog","with","Sleep"};
        SetupButtons();
        if (background2 != null)
        {
            background2Animator = background2.GetComponent<Animator>();
            background2.SetActive(false);
        }
    }

    void SetupButtons(){
        for(int i=0;i<wordButtons.Length;i++){

             if (wordButtons[i] == null)
        {
            Debug.Log("Button at index " + i + " is null!");
            continue;
        }
            int index=i;
            wordButtons[i].GetComponentInChildren<TextMeshProUGUI>().text=words[i];
            wordButtons[i].onClick.AddListener(()=>SelectWord(words[index]));
        }
    }

    void SelectWord(string word){
        if (selectedWords.Count >= 3){
            instructionText.text = "You can only select up to 3 words!";
            return;
        }


        if(!selectedWords.Contains(word)){
            selectedWords.Add(word);
            instructionText.text = "Selected Word: " + string.Join(", ", selectedWords);

            if (selectedWords.Count == correctSentence.Split(' ').Length)
            {
                CheckSentence();
            }

        }
    }

    public void CheckSentence(){
        List<string> validSentences= new List<string> {"Play with Dog"};

        string formedSentence = string.Join(" ",selectedWords);
        if(validSentences.Contains(formedSentence)){
            instructionText.text= "Correct!";
           if (background2 != null && background2Animator != null)
            {
                background2.SetActive(true); 
                background2Animator.Play("Background2Animation"); 
            }
            FindObjectOfType<BackgroundSwitcher>().SwitchBackground();
        }
        else {
            instructionText.text= "Try Again!";
            selectedWords.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
