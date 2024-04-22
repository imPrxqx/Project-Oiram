using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    bool IsOpened = false;
    bool CanBeOpened = false;
    public Animator animator;
    public bool boolChest = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsOpened == false && CanBeOpened)      //pokud se zmačkne šipka nahoru, není otevřena a je u ní hráč, tak se otevře
        {
            Debug.Log("otevřeno");
            IsOpened = true;
            int coin = PlayerPrefs.GetInt("Coin", 0);
            coin += Random.Range(10, 20);
            PlayerPrefs.SetInt("Coin", coin);
            PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
            playSound.Play(1);  //přehrání zvuku
            animator.SetBool("Open", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanBeOpened = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanBeOpened = false;
        }
    }
}
