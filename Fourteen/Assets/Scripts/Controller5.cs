using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller.Scene5
{
    public class Controller5 : MonoBehaviour
    {
        [SerializeField] AllAnimation allAnimation;

        private void Start()
        {
            StartCoroutine(allAnimation.StartDialogue(3f));
        }
    }
}