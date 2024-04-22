using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerUI : MonoBehaviour
{
    public void ContinueToLevelMap()
    {
        if (PlayerPrefs.GetInt("Level") != 0)
        {
            PlayerPrefs.SetInt("Win", 0);
            SceneManager.LoadScene("LevelMap");   // bude se loadovat na scénu s level mapou
        }
        else
        {
            PlayerPrefs.SetInt("Win", 0);
            SceneManager.LoadScene("Menu");   // bude se loadovat do menu; je to pro finální level
        }

        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
        playSound.Play(0);  //přehrání zvuku
    }
}
