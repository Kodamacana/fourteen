using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller2 : MonoBehaviour
{
    [SerializeField] AllAnimation allAnimation;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] GameObject NDialogueBlock;
    [SerializeField] GameObject TDialogueBlock;

    public int HeartValue = 25;

    private void Start()
    {
        StartCoroutine(allAnimation.StartDialogue(2f));
        StartCoroutine(AnimLoop());
    }

    public IEnumerator AnimLoop()
    {
        yield return new WaitForSecondsRealtime(5f);
        dialogueManager.DisplayNextSentences();
        yield return new WaitForSecondsRealtime(4f);
        dialogueManager.DisplayNextSentences();
        yield return new WaitForSecondsRealtime(2f);
        dialogueManager.DisplayNextSentences();
        yield return new WaitForSecondsRealtime(4f);
        dialogueManager.DisplayNextSentences();
        yield return new WaitForSecondsRealtime(3f);
        allAnimation.ResetAnim();
    }

    public void HeartVal()
    {
        HeartValue -= 1;
        if (HeartValue <= 0)
        {
            dialogueManager.DisplayNextSentences();
            NDialogueBlock.SetActive(false);
            TDialogueBlock.SetActive(false);
        }
    }
}
