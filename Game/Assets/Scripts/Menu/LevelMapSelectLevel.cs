using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMapSelectLevel : MonoBehaviour
{
    public int LevelNumber;     //číslo levelu, na který button odkazuje

    public void SelectLevel()       // metoda, která načte ten level
    {
        Debug.Log("Loading level: " + LevelNumber) ;
        SceneManager.LoadScene(LevelNumber);
        PlayerPrefs.SetInt("CurrentLevel", LevelNumber);
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //přehrání zvuku
        playSound.Play(0);
    }

    public void LevelMapBackToMenu()   //metoda, co pošle do menu
    {
        SceneManager.LoadScene("Menu");
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //přehrání zvuku
        playSound.Play(0);
    }
}
