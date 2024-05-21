using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public UIScript ui;

    public NPCInteractable npc1;
    public NPCInteractable2 npc2;
    public NPCInteractable3 npc3;
    public GameObject eInteract;

    private void Update()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    if (npc1.quest1 == false && npc2.quest2 == false && npc1.quest1Complete == false)
                    {
                        npcInteractable.Interact();
                    }
                    if (npc1.quest1 == false && npc1.quest1Complete == true)
                    {
                        npcInteractable.InteractCompleted();
                    }
                    else
                    {

                    }
                }
                if (collider.TryGetComponent(out NPCInteractable2 npcInteractable2))
                {
                    if (npc1.quest1 == false && npc2.quest2 == false && npc2.quest2Complete == false)
                    {
                        npcInteractable2.Interact();
                    }
                    if (npc2.quest2 == false && npc1.quest1 == false && npc2.quest2Complete == true)
                    {
                        npcInteractable2.InteractCompleted();
                    }
                    else
                    {

                    }
                }
            }
            if (collider.TryGetComponent(out NPCInteractable3 npcInteractable3))
            {
                eInteract.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    npcInteractable3.Interact();
                }
            }
            else
            {
                eInteract.SetActive(false);
            }
        }
    }

    public void quest1Start()
    {
        npc1.quest1 = true;
    }
    public void quest2Start()
    {
        npc2.quest2 = true;
    }
}
