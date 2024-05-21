using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public GameObject healthHud;
    public GameObject strengthHud;
    public GameObject speedHud;
    public GameObject purseHud;
    public GameObject player;
    public GameObject deathHud;

    public GameObject speedTimerHud;
    public GameObject strengthTimerHud;

    public TMP_Text healthPotText;
    public TMP_Text speedPotText;
    public TMP_Text strengthPotText;
    public TMP_Text coinPurse;
    public TMP_Text speedTimeText;
    public TMP_Text strengthTimeText;

    public float baseSpeed = 6f;

    public bool invulnerable = false;

    public float damageMultiplier;

    public int healthPot = 0;
    public int speedPot = 0;
    public int strengthPot = 0;
    public int coins = 0;
    public bool speedUse = false;

    public float health = 100f;
    public Image healthBar;

    public float speedTimer;
    public float strengthTimer;

    public AttackingScript attackingScript;

    // Update is called once per frame
    void Update()
    {
        if (healthPot > 0)
        {
            healthHud.SetActive(true);
        }
        else
        {
            healthHud.SetActive(false);
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

        speedTimer -= 1 * Time.deltaTime;
        strengthTimer -= 1 * Time.deltaTime;

        if (speedTimer > 0)
        {
            baseSpeed = 12f;
            speedTimeText.text = "Speed Bonus " + ((int)speedTimer).ToString();
            speedTimerHud.SetActive(true);
        }
        if (speedTimer <= 0)
        {
            baseSpeed = 6f;
            speedTimerHud.SetActive(false);
        }

        if (strengthTimer > 0)
        {
            damageMultiplier = 1.5f;
            strengthTimeText.text = "Strength Bonus " + ((int)strengthTimer).ToString();
            strengthTimerHud.SetActive(true);
        }
        if (strengthTimer <= 0)
        {
            damageMultiplier = 1f;
            strengthTimerHud.SetActive(false);
        }

        CoinCount();
    }

    public void TakeDamage(float damage)
    {
        if (invulnerable == false)
        {
            health -= damage;
            healthBar.fillAmount = health / 100f;
        }

        if (health <= 0)
        {
            Destroy(player);
            deathHud.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
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
        speedPot--;
        speedTimer = 30;
    }

    public void Strength()
    {
        strengthPot--;
        strengthTimer = 30;
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

    public void CoinCount()
    {
        coinPurse.text = coins.ToString();
    }
}
