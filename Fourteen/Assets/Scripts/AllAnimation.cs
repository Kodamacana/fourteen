using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllAnimation : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] DialogueTrigger DialogueTrigger;
    [SerializeField] public Animator T_DialogueBoxAnim;
    [SerializeField] public Animator N_DialogueBoxAnim;
    [SerializeField] Animator ClockAnim;
    [SerializeField] Animator PanelShakeAnim;
    [SerializeField] Animator MainCameraAnim;

    public void Coroutine(string Name)
    {
        ResetAnim();
        if (Name.Equals("T")) DialogueTrigger_T();
        else DialogueTrigger_N();

        StartCoroutine(DelayDialogueButton(0.7f));
    }
    public IEnumerator ContiuneAnim()
    {
        ClockAnim.SetTrigger("ContiuneClockAnim");
        PanelShakeAnim.SetTrigger("StartPanelShake");
        MainCameraAnim.SetTrigger("ContiuneCameraShake");

        yield return new WaitForSecondsRealtime(3f);
        ResetAnim();
        StartCoroutine(DelayDialogueButton(11f));

        yield return new WaitForSecondsRealtime(14f);

        dialogueManager.DisplayNextSentences();

    }

    public IEnumerator StartDialogue(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        DialogueTrigger.TriggerDialogue();
    }


    public IEnumerator DelayDialogueButton(float delayTime)
    {
        var bttn = GameObject.FindGameObjectsWithTag("DialogueButton");
        foreach (var item in bttn)
            item.transform.GetComponent<Button>().interactable = false;

        yield return new WaitForSecondsRealtime(delayTime);

        foreach (var item in bttn)
            item.transform.GetComponent<Button>().interactable = true;
    }


    public IEnumerator StartIenum()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        ClockAnim.SetTrigger("StartClockAnim");
        PanelShakeAnim.SetTrigger("StartPanelShakeLOOP");

        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(DelayDialogueButton(3.5f));
    }
    void DialogueTrigger_T()
    {
        N_DialogueBoxAnim.SetBool("SlideStopAnim", true);

        T_DialogueBoxAnim.gameObject.SetActive(true);
        T_DialogueBoxAnim.SetBool("SlideStartAnim", true);
    }

    void DialogueTrigger_N()
    {
        T_DialogueBoxAnim.SetBool("SlideStopAnim", true);

        N_DialogueBoxAnim.gameObject.SetActive(true);
        N_DialogueBoxAnim.SetBool("SlideStartAnim", true);
    }

    public void ResetAnim()
    {
        T_DialogueBoxAnim.SetBool("SlideStartAnim", false);
        N_DialogueBoxAnim.SetBool("SlideStartAnim", false);

        T_DialogueBoxAnim.SetBool("SlideStopAnim", false);
        N_DialogueBoxAnim.SetBool("SlideStopAnim", false);

        N_DialogueBoxAnim.gameObject.SetActive(false);
        T_DialogueBoxAnim.gameObject.SetActive(false);

    }


    public IEnumerator OpeningGift()
    {
        yield return new WaitForSecondsRealtime(1f);
        ResetAnim();
        StartCoroutine(DelayDialogueButton(11f));
        yield return new WaitForSecondsRealtime(2f);

        //gift opening animation start



        yield return new WaitForSecondsRealtime(5f);

        dialogueManager.DisplayNextSentences();
    }

    public IEnumerator flashcameraslide()
    {
        yield return new WaitForSecondsRealtime(2f);
        ResetAnim();
        StartCoroutine(DelayDialogueButton(3f));
        yield return new WaitForSecondsRealtime(3f);

        MainCameraAnim.SetTrigger("ZoomIn");
    }
    
}
