using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]   //schová spawnpoint v inspektoru, protože není potřeba ho tam mít
    public GameObject SpawnPoint;      //spawnpoint
    GameObject Camera;         //kamera
    GameObject Player;
    LevelGenerator levelGenerator;  //pro získání nejnižšího bodu
    bool ifFell = false;


    private void Start()
    {
        SpawnPoint = GameObject.Find("spawnPoint");         //najdete spawn point na scéně(měl by být pouze jeden a to na začátku levelu)
        Camera = GameObject.Find("Main Camera");    //najdeme kameru
        Player = GameObject.Find("Player");        //najedme hráče
        levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
    }

    private void Update()
    {
        if (Input.GetKey("l"))                              //při stiknutí klávesy "l" se nastaví životy na 3  (Developer testování)
        {
            PlayerPrefs.SetInt("Health", 3);
            Debug.Log("Životy nastaveny");
        }

        if (Input.GetKey("k"))                          //při stiknutí klávesy "k" se nastaví čepice na true  (Developer testování)
        {
            PlayerPrefs.SetInt("Hat", 1);
            Debug.Log("Čepice nastavena");
        }

        if (Input.GetKey("t"))                         
        {
            transform.position = SpawnPoint.transform.position;
        }

        if (Input.GetKey("r"))
        {
            Camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -1);
            //Camera.transform.Translate(Vector3.down * Time.deltaTime * 5, Space.World);
            //Camera.transform.position = new Vector3(0, 0, -2);
        }

    }

    private void LateUpdate()
    {
        if (transform.position.y < levelGenerator.LowestPartY - 12)
        {
            playerFell();
        }
    }

    public void HealthDown()                   //metoda pro snižování životů; pokud je čepice true tak se čepice ztratí; pokud čepice true není tak se sníží životy 
    {                                          //a hráč se vrátí na začátek levelu
        int health = PlayerPrefs.GetInt("Health", 0);
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků

        if (PlayerPrefs.GetInt("Hat", 0) == 0)
        {
            if (health == 0)
            {
                Debug.Log("jsi dead");
                File.Delete(Application.persistentDataPath + "/save.oiram"); //delete savu

                playSound.Play(3);  //přehrání zvuku
                ifFell = true;
            }
            else
            {
                health--;

                if (health != 0)        //nechci aby se hráč vrátil na zpátek levelu, když ztratí poslední život
                {
                    transform.position = SpawnPoint.transform.position;


                    Camera.transform.SetParent(Player.transform, true);
                    Camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -1);

                    playSound.Play(7);  //přehrání zvuku
                }

                PlayerPrefs.SetInt("Health", health);   //uložení životů
            }
        }
        else 
        {
            PlayerPrefs.SetInt("Hat", 0);
            Debug.Log("Čepice zničena");
            playSound.Play(7);  //přehrání zvuku
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HealthDown();
            Debug.Log("hit");
        }
    }

    //metoda, která se vyvolá pokud hráč spadne dostatečně hluboko
    //vrátí se na začátek levelu se sníženým životem
    private void playerFell()
    {
        PlayerPrefs.SetInt("Hat", 0);

        if (!ifFell)    //podmínka, aby se při pádu zvuk neopakoval
        {
            HealthDown();
        }

        Debug.Log("Padáš");
    }
}
