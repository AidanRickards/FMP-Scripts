using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject healthHud;
    public GameObject strengthHud;
    public GameObject speedHud;

    public TMP_Text healthPotText;
    public TMP_Text speedPotText;
    public TMP_Text strengthPotText;

    public float health = 100f;
    public Image healthBar;

    public int healthPot = 0;
    public int speedPot = 0;
    public int strengthPot = 0;
    public bool speedUse = false;

    public bool quest1 = false;
    public bool quest2 = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("dont destroy");
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            print("do destroy");
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (healthPot > 0)
        {
            healthHud.SetActive (true);
        }
        else
        {
            healthHud.SetActive (false);
        }

        if (speedPot > 0)
        {
            speedHud.SetActive(true);
        }
        else
        {
            speedHud.SetActive(false);
        }

        if (strengthPot > 0)
        {
            strengthHud.SetActive(true);
        }
        else
        {
            strengthHud.SetActive(false);
        }

        healthPotText.text = " " + healthPot.ToString();
        speedPotText.text = " " + speedPot.ToString();
        strengthPotText.text = " " + strengthPot.ToString();

        if (health <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Heal(1);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100f;
    }

    public void Heal(float healingAmount)
    {
        if (healthPot > 0)
        {
            health += healingAmount;
            healthPot--;
            IncreaseHealthPot();

            healthBar.fillAmount = health / 100;
        }
    }
    
    public void Speed()
    {
        if (speedPot > 0)
        {
            speedUse = true;
            speedPot--;
        }
    }

    public void IncreaseHealthPot()
    {
        healthPot++;
        healthPotText.text = " " + healthPot.ToString();
    }

    public void IncreaseSpeedPot()
    {
        speedPot++;
        speedPotText.text = " " + speedPot.ToString();
    }

    public void IncreaseStrengthPot()
    {
        strengthPot++;
        strengthPotText.text = " " + strengthPot.ToString();
    }

    public void quest1Start()
    {
        quest1 = true;
    }
    public void quest2Start()
    {
        quest1 = true;
    }
}
