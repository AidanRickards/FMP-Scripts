using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable2 : MonoBehaviour
{
    public GameObject quest2Hud;
    public bool quest2 = false;
    public bool quest2Complete = false;
    public GameObject quest2Boss;
    public GameObject quest2CompleteHud;
    public void Interact()
    {
        quest2Hud.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void quest2start()
    {
        quest2 = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        quest2Boss.SetActive(true);
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

    public void InteractCompleted()
    {
        quest2CompleteHud.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Thanks()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
