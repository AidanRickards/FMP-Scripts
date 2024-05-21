using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public bool quest1 = false;
    public GameObject quest1Hud;
    public GameObject quest1CompleteHud;
    public GameObject quest1Boss;
    public UIScript ui;
    public bool quest1Complete = false;
    public void Interact()
    {
        quest1Hud.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void InteractCompleted()
    {
        quest1CompleteHud.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void quest1start()
    {
        quest1 = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        quest1Boss.SetActive(true);
    }

    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Thanks()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
