using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SideLevelEnd : MonoBehaviour
{
    GameObject WinUI;
    GameObject EscapeMenu;

    SaveLoad saveLoad;

    private void Start()
    {
        saveLoad = GetComponent<SaveLoad>();    //získávám komponet SaveLoad

        //hledám WinUI a potom ho deaktivuji(deaktivuji ho tady, protože metoda find může najít jen aktivní objekty)
        WinUI = GameObject.Find("WinnerUI"); 
        WinUI.SetActive(false);

        //hledám WinUI a potom ho deaktivuji
        EscapeMenu = GameObject.Find("EscapeMenu"); 
        EscapeMenu.SetActive(false);
    }

    //pokud se hráč dotkne diamantu, tak se ukončí level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EscapeMenu.SetActive(false); //pokud by bylo otevřené menu, tak se zavře
            Destroy(gameObject);   //zničí se drahokam
            Debug.Log("Dohrál jsi level!");
            WinUI.SetActive(true);
            PlayerPrefs.SetInt("Win", 1);

            int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 2);
            int level = PlayerPrefs.GetInt("Level", 1);
            if (currentLevel-1 == level)        //currentLevel-1 kvůli tomu, jak jsou očíslované scény v unity
            {
                level = level + 1;
                PlayerPrefs.SetInt("Level", level);
            }

            saveLoad.Save();  //uložím hru

            PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
            playSound.Play(9);  //přehrání zvuku
        }
    }
}