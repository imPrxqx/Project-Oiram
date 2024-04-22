using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);   //zničí se health pick up
            int health = PlayerPrefs.GetInt("Health", 1);
            health++;
            PlayerPrefs.SetInt("Health", health);  //přidá se život
            Debug.Log("Health pick up");
            PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
            playSound.Play(6);  //přehrání zvuku
        }
    }
}
