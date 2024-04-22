using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTrack : MonoBehaviour
{
    //Tento Skript je pro:
    //Ovládání životů v UI

    public int health;
    public Text healthText;
    public GameObject DeathUI;
    public GameObject EscapeMenu;

    void Start()            // při startu se vytáhne z player prefs životy a potom se nastaví do textu
    {
        health = PlayerPrefs.GetInt("Health", 0);
        healthText.text = PlayerPrefs.GetInt("Health", 0).ToString();
    }

    private void Update()           //v update se sleduje jestli se životy nezměnily
    {
        if (PlayerPrefs.GetInt("Health") != health)
        {
            SumHealth(PlayerPrefs.GetInt("Health")-health);
        }
    }

    public void SumHealth(int FHealth)      //metoda pro změnu životů
    {
        
        health += FHealth;

        if (health<=0)
        {
            health = 0;
            DeathUI.SetActive(true);
            EscapeMenu.SetActive(false);
        }

        healthText.text = health.ToString();
        PlayerPrefs.SetInt("Health", health);
    }

    public void SaveScore()         // metoda pro uložení životů
    {
        PlayerPrefs.SetInt("Health", health);
    }
}
