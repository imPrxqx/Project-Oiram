using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenu;
    bool opened = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //pomocí ESC se mi zobrazí escape menu
        {
            if (PlayerPrefs.GetInt("Health", 0) != 0 && PlayerPrefs.GetInt("Win", 0) != 1 && !opened)
            {
                escapeMenu.SetActive(true);
                opened = true;
            }
            else
            {
                escapeMenu.SetActive(false);
                opened = false;
            }
        }
    }



    /// 
    /// metody v escape menu
    /// 
    public void BackToMenu()    
    {
        SceneManager.LoadScene("Menu");
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
        playSound.Play(0);  //přehrání zvuku
    }

    public void BackToLevelMap()
    {
        Debug.Log("Levelmap loaded");
        SceneManager.LoadScene(1);
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
        playSound.Play(0);  //přehrání zvuku
    }

    public void Continue()
    {
        escapeMenu.SetActive(false);
        opened = false;
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
        playSound.Play(0);  //přehrání zvuku
    }
}
