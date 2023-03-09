using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOrOpenPanel : MonoBehaviour
{
    [SerializeField] GameObject gameobj;
    public void Close()
    {
        gameobj.SetActive(false);
    }
    public void Open()
    {
        gameobj.SetActive(true);
    }
}
