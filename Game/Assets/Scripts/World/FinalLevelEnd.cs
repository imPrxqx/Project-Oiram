using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FinalLevelEnd : MonoBehaviour
{
    GameObject WinUI;
    GameObject EscapeMenu;

    private void Start()
    {
        //hledám WinUI a potom ho deaktivuji(deaktivuji ho tady, protože metoda find může najít jen aktivní objekty)
        WinUI = GameObject.Find("WinnerUI");
        WinUI.SetActive(false);

        //hledám WinUI a potom ho deaktivuji
        EscapeMenu = GameObject.Find("EscapeMenu");
        EscapeMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            EscapeMenu.SetActive(false); //pokud by bylo otevřené menu, tak se zavře
            Destroy(gameObject);   //zničí se drahokam
            Debug.Log("Dohrál jsi level!");
            WinUI.SetActive(true);
            PlayerPrefs.SetInt("Win", 1);

            int level = PlayerPrefs.GetInt("Level", 1);
            level = 0;
            PlayerPrefs.SetInt("Level", level);

            File.Delete(Application.persistentDataPath + "/save.oiram"); //delete savu

            PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
            playSound.Play(9);  //přehrání zvuku
        }
    }
}
