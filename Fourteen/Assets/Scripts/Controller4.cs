using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller4 : MonoBehaviour
{
    [SerializeField] AllAnimation allAnimation;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] GameObject NDialogueBlock;
    [SerializeField] GameObject TDialogueBlock;
    public Text heartNum;
    int heartNumINT = 0;
    int HeartValue = 25;

    private void Start()
    {
        heartNum.text = heartNumINT.ToString();
        StartCoroutine(allAnimation.StartDialogue(3f));
        StartCoroutine(AnimLoop());
    }

    public IEnumerator AnimLoop()
    {
        yield return new WaitForSecondsRealtime(8f);
        dialogueManager.DisplayNextSentences();
        yield return new WaitForSecondsRealtime(4f);
        dialogueManager.DisplayNextSentences();
        yield return new WaitForSecondsRealtime(3f);
        dialogueManager.DisplayNextSentences();
        yield return new WaitForSecondsRealtime(4f);
        allAnimation.ResetAnim();
    }

    public void HeartVal()
    {
        HeartValue -= 1;
        heartNumINT += 1;
        heartNum.text = heartNumINT.ToString();

        if (HeartValue <= 0)
        {
            dialogueManager.DisplayNextSentences();
            NDialogueBlock.SetActive(false);
            TDialogueBlock.SetActive(false);
        }
    }
}
