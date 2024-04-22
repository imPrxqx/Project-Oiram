using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 dir = collision.transform.position - transform.position;    //zjistím si z jakého směru hráč přichází
        Vector2 vector2 = NormalizeVector2(dir);                           //ale špatně se sním pracuje a tak jsem vytvořil metodu, která to udělá jednoduší vector vždy bude (1, 0), (-1, 0), (0, -1), (0, 1)

        if (collision.gameObject.tag == "Player" && vector2.y == 1)
        {
            Vector2 vector = new Vector2(0, 10);    // využití námi nastavené hodnoty(jak moc má skočit)
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(vector, ForceMode2D.Impulse);  //skok v impulsu
            Destroy(gameObject);
            int coins = PlayerPrefs.GetInt("Coin", 0);  //po skočení na hlavu, hráč získává 5 coinů     
            coins += 5;
            PlayerPrefs.SetInt("Coin", coins);
            PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
            playSound.Play(4);  //přehrání zvuku
        }
    }

    private Vector2 NormalizeVector2(Vector2 vector)
    {
        if (vector.x > 0.5)
        {
            vector.x = 1;
        }
        else if(vector.x < -0.5)
        {
            vector.x = -1;
        }
        else
        {
            vector.x = 0;
        }

        if (vector.y > 0.5)
        {
            vector.y = 1;
        }
        else if (vector.y < -0.5)
        {
            vector.y = -1;
        }
        else
        {
            vector.y = 0;
        }

        return vector;
    }
}
