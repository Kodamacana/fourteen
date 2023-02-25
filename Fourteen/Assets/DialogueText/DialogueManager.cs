using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    struct DialogueStruct
    {
        public string DialogueText;
        public bool isNurdan;
        public string FuncNote;
    }
    List<DialogueStruct> sentences;


    [SerializeField] AllAnimation allAnimation;
    [SerializeField] DialogueFuncs0 dialogueFuncs;
    [SerializeField]
     Text T_DialogueText;
    [SerializeField]
     Text N_DialogueText;    
    

    void Start()
    {
        sentences = new List<DialogueStruct>();
    }

    public void StartDialogue(Dialogue[] dialogue)
    {
        sentences.Clear();

            
        for (int i = 0; i < dialogue.Length; i++)
        {

            foreach (string sentence in dialogue[i].sentences)
            {
                var snt = new DialogueStruct();
                snt.DialogueText = sentence;
                snt.isNurdan = dialogue[i].isNurdan;
                snt.FuncNote = dialogue[i].FuncNote;
                sentences.Add(snt);
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

        string sentence = sentences[0].DialogueText;
        dialogueFuncs.MainCamFunc(); //Cam Pos Reset
        if (sentences[0].FuncNote != null && sentences[0].FuncNote != "" && sentences[0].FuncNote != " ")
        {
            dialogueFuncs.AllFunctions(sentences[0].FuncNote);
        }
        if (sentences[0].isNurdan)
        {
            N_DialogueText.text = sentence;
            allAnimation.Coroutine("N");
        }
        else
        {
            T_DialogueText.text = sentence;
            allAnimation.Coroutine("T");
        }
        sentences.Remove(sentences[0]);

    }

    void EndDialogue()
    {

        allAnimation.N_DialogueBoxAnim.SetBool("SlideStopAnim", true);
        allAnimation.T_DialogueBoxAnim.SetBool("SlideStopAnim", true);
        allAnimation.ResetAnim();

        
        Debug.Log("diyalog bitti");
    }
}
