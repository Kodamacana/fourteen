using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueFuncs0 : MonoBehaviour
{ 
    [SerializeField] AllAnimation allAnimation;
    [SerializeField] Camera MainCam;
    [SerializeField] Camera TCam;
    [SerializeField] Camera NCam;

    public void AllFunctions(string ParameterName)
    {
        Type thisType = this.GetType();

        string[] parameters = ParameterName.Split('+');

        for (int i = 0; i < parameters.Length; i++)
        {
            MethodInfo theMethod = thisType.GetMethod(parameters[i]);
            theMethod.Invoke(this, null);
        }
    }

    public void MainCamFunc()
    {
        MainCam.gameObject.SetActive(true);
        NCam.gameObject.SetActive(false);
        TCam.gameObject.SetActive(false);
    }

    public void stagemiddle()
    {

    }

    public void waitfood()
    {

    }

    public void startclock()
    {
        StartCoroutine(allAnimation.StartIenum());
    }
    public void contiuneclock()
    {
        //hediye paketi yukarıdan düşsün ve fırın pişirme sesi duyulsun
        StartCoroutine(allAnimation.ContiuneAnim());
    }
    public void ngulme()
    {

    }
    public void N_Cam()
    {
        MainCam.gameObject.SetActive(false);
        NCam.gameObject.SetActive(true);
    }
    public void T_Cam()
    {
        MainCam.gameObject.SetActive(false);
        TCam.gameObject.SetActive(true);
    }
    public void t_utan()
    {
        //animator
    }
    public void n_utan()
    {
        //animator
    }
    public void flashcameraslide()
    {
        //camera flash belleğe doğru yaklaşır ekran kararır müzik kesilir e sakince sahne 1 başlar
        SceneManager.LoadScene("Scene1");
    }
    public void outSide()
    {

    }
}
