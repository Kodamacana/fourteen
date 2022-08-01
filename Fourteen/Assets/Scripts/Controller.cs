using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] DialogueManager dialogueManager;
        [SerializeField] DialogueTrigger DialogueTrigger;
        [SerializeField] public Animator T_DialogueBoxAnim;
        [SerializeField] public Animator N_DialogueBoxAnim;
        [SerializeField] Animator ClockAnim;
        [SerializeField] Animator PanelShakeAnim;
        [SerializeField] Animator MainCameraAnim;


        private void Start()
        {
            MainCameraAnim.SetTrigger("ScreenFader");
            StartCoroutine(StartDialogue());            
        }

        public IEnumerator StartDialogue()
        {
            yield return new WaitForSecondsRealtime(3);
            DialogueTrigger.TriggerDialogue();
        }


        IEnumerator DelayDialogueButton(float delayTime)
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

            StartCoroutine(DelayDialogueButton(4.5f));            
        }

        public IEnumerator ContiuneAnim()
        {
            ClockAnim.SetTrigger("ContiuneClockAnim");
            PanelShakeAnim.SetTrigger("StartPanelShake");
            MainCameraAnim.SetTrigger("ContiuneCameraShake");

            StartCoroutine(DelayDialogueButton(14f));

            yield return new WaitForSecondsRealtime(14f);

            dialogueManager.DisplayNextSentences();            
            
        }

        public void Coroutine(string Name)
        {
            ResetAnim();
            if (Name.Equals("T")) DialogueTrigger_T();
            else DialogueTrigger_N();
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
    }
}