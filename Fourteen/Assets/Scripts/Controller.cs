using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] DialogueManager dialogueManager;
        [SerializeField] DialogueTrigger DialogueTrigger;
        [SerializeField] Animator DialogueBoxAnim;
        [SerializeField] Animator ClockAnim;
        [SerializeField] Animator PanelShakeAnim;


        private void Start()
        {
            Coroutine();
        }

        public void Coroutine()
        {
            StartCoroutine(IE_DialogueTrigger());
        }

        IEnumerator IE_DialogueTrigger()
        {
            yield return new WaitForSecondsRealtime(2);

            DialogueBoxAnim.gameObject.SetActive(true);
            DialogueBoxAnim.SetBool("SlideStartAnim", true);
            DialogueTrigger.TriggerDialogue();

            ClockAnim.SetTrigger("StartClockAnim");
            PanelShakeAnim.SetTrigger("StartPanelShake");
        }
    }
}