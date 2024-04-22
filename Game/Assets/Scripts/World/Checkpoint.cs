using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    bool isActive = false;  //byl aktivován checkpoint?

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isActive)  
        {
            PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //přehrání zvuku
            playSound.Play(10);

            PlayerHealth player = GameObject.Find("Player").GetComponent<PlayerHealth>();   // najdu si hráče a jeho skript s životy ve, kterém má uložený objekt, na který se má hráč spawnout
            player.SpawnPoint = gameObject; //tady se objekt nastavuje
            isActive = true;    //je aktivován
        }
    }
}
