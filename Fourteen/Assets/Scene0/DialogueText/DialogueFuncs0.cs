using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DialogueFuncs0 : MonoBehaviour
{ 
    [SerializeField] Controller.Controller controller;
    [SerializeField] Camera MainCam;

    public void AllFunctions(string ParameterName)
    {
        Type thisType = this.GetType();
        MethodInfo theMethod = thisType.GetMethod(ParameterName);
        theMethod.Invoke(this, null);
    }


    public void startclock()
    {
        StartCoroutine(controller.StartIenum());
    }
    public void contiuneclock()
    {
        //hediye paketi yukarıdan düşsün ve fırın pişirme sesi duyulsun
        StartCoroutine(controller.ContiuneAnim());
    }
    
    public void camN_uzak()
    {

    }
    public void camN_yakin()
    {

    }
    public void ngulme()
    {

    }


    public void camT_uzak()
    {

    }
    public void camT_yakin()
    {

    }
    public void t_utan()
    {
        //animator
    }

    public void flashcameraslide()
    {
        //camera flash belleğe doğru yaklaşır ekran kararır müzik kesilir e sakince sahne 1 başlar 
    }
}
