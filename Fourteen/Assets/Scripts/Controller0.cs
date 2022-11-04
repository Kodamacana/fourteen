using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller.Scene0
{
    public class Controller0 : MonoBehaviour
    {
        [SerializeField] AllAnimation allAnimation;
        [SerializeField] Animator MainCameraAnim;

        private void Start()
        {
            MainCameraAnim.SetTrigger("ScreenFader");
            StartCoroutine(allAnimation.StartDialogue(3f));            
        }       
    }
}