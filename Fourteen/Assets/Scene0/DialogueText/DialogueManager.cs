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


    [SerializeField] Controller.Controller controller;
    [SerializeField] DialogueFuncs dialogueFuncs;
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
        if (sentences[0].FuncNote != null && sentences[0].FuncNote != "" && sentences[0].FuncNote != " ")
        {
            dialogueFuncs.AllFunctions(sentences[0].FuncNote);
        }
        if (sentences[0].isNurdan)
        {
            N_DialogueText.text = sentence;
            controller.Coroutine("N");
        }
        else
        {
            T_DialogueText.text = sentence;
            controller.Coroutine("T");
        }
        sentences.Remove(sentences[0]);

    }

    void EndDialogue()
    {

        controller.N_DialogueBoxAnim.SetBool("SlideStopAnim", true);
        controller.T_DialogueBoxAnim.SetBool("SlideStopAnim", true);
        controller.ResetAnim();

        controller.N_DialogueBoxAnim.gameObject.SetActive(false);
        controller.T_DialogueBoxAnim.gameObject.SetActive(false);
        Debug.Log("diyalog bitti");
    }
}
