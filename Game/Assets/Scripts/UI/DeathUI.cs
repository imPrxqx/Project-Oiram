using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    public void ContinueToMenu()
    {
        SceneManager.LoadScene("Menu");
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
        playSound.Play(0);  //přehrání zvuku
    }
}
