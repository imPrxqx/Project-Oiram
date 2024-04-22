using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("Hat", 0) == 0)      //Pokud hráč má čepici, tak se neveme
            {
                PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //přehrání zvuku
                playSound.Play(5);

                Destroy(gameObject);   //zničí se hat pick up
                PlayerPrefs.SetInt("Hat", 1);  //čepka se "nasadí"
                Debug.Log("Čepice pick up");
            }
        }
    }
}
