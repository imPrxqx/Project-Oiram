using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //přehrání zvuku
        playSound.Play(0);
    }

    public void Continue()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //přehrání zvuku
        playSound.Play(0);
        SceneManager.LoadScene("LevelMap");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
        PlayerPrefs.SetInt("Health", 3);
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("CurrentLevel", 2);
        File.Delete(Application.persistentDataPath + "/save.oiram"); //delete savu
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //přehrání zvuku
        playSound.Play(0);
    }
}
