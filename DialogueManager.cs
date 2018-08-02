using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Queue<string> sentences;
    bool isTalking;
    public Text nameText;
    public Text dialogueText;
    public Image textBox;
    Color textBoxColorClear = new Color(0f, 0f, 0f, 0f);
    Color textBoxColor = new Color(0f, 0f, 0f, 1f);
    Color dialogueColorClear = new Color(1f, 1f, 1f, 0f);
    Color dialogueColor = new Color(1f, 1f, 1f, 1f);
    Color nameColorClear = new Color(0.5f, 1f, 0f, 0f);
    Color nameColor = new Color(0.5f, 1f, 0f, 1f);

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isTalking && Input.GetKeyDown(KeyCode.RightShift))
        {
            DisplayNextSentence();
        }

    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting convo with " + dialogue.name);
        sentences.Clear();

        textBox.color = textBoxColor;

        nameText.text = dialogue.name;
        nameText.color = nameColor;
        dialogueText.color = dialogueColor;

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        isTalking = true;

        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    
    void EndDialogue()
    {
        Debug.Log("End of convo");
        isTalking = false;
        textBox.color = textBoxColorClear;
        nameText.color = nameColorClear;
        dialogueText.color = dialogueColorClear;
    }

    public bool Talking()
    {
        return isTalking;
    }
}
