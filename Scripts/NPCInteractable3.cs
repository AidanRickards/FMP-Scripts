using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable3 : MonoBehaviour
{
    public GameObject quest3Hud;
    public GameObject eInteract;
    public bool interactMenu = true;

    public UIScript ui;


    public void Interact()
    {
        quest3Hud.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        eInteract.SetActive(false);

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

    public void HealthPotBuy()
    {
        if (ui.coins >= 5)
        {
            ui.coins -= 5;
            ui.healthPot += 1;
        }
    }
    public void SpeedPotBuy()
    {
        if (ui.coins >= 10)
        {
            ui.coins -= 10;
            ui.speedPot += 1;
        }
    }
    public void StrengthPotBuy()
    {
        if (ui.coins >= 10)
        {
            ui.coins = ui.coins - 10;
            ui.strengthPot += 1;
        }
    }

    public void QuitButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        quest3Hud.SetActive(false);
    }
}
