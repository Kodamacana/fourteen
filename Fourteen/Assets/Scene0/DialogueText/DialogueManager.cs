using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text DialogueText;

    public Queue<string> sentences;
    public Queue<string> names;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue[] dialogue)
    {
        sentences.Clear();

            
        for (int i = 0; i < dialogue.Length; i++)
        {

            foreach (string sentence in dialogue[i].sentences)
            {
                sentences.Enqueue(sentence);
                names.Enqueue(dialogue[i].name);
            }

        }   

        DisplayNextSentences();
    }

    public void DisplayNextSentences()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        DialogueText.text = sentence;
        nameText.text = name;

    }

    void EndDialogue()
    {
        Debug.Log("diyalog bitti");
    }
}
