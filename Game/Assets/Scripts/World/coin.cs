using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //přehrání zvuku
            playSound.Play(2);

            int coin = PlayerPrefs.GetInt("Coin", 0);
            PlayerPrefs.SetInt("Coin", coin+1);
            Debug.Log("Coin sebrán");
            Destroy(gameObject);
        }
    }
}
