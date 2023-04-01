using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animationTrans : MonoBehaviour
{
    [SerializeField] Animator N;
    [SerializeField] Animator T;
    [SerializeField] GameObject GiftBox;

    public void FallingGift()
    {
        GiftBox.SetActive(true);
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void TrueRun()
    {
        T.SetBool("Run", true);
        N.SetBool("Run", true);
    }
    public void TrueFall()
    {
        //T.SetBool("Jmp", true);
        N.SetBool("Jmp", true);
    }
    public void TrueLand()
    {
        //T.SetBool("Land", true);
        N.SetBool("Land", true);
    }

    public void FalseAllAnimation()
    {
        N.SetBool("Run", false);
        N.SetBool("Land", false);
        N.SetBool("Jmp", false);

        T.SetBool("Run", false);
        //T.SetBool("Land", false);
        //T.SetBool("Jmp", false);
    }
}
