using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public Text text;
    int coin;


    void Awake()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        text.text = coin.ToString();
    }

    void LateUpdate()
    {
        int PlayerPrefsCoin = PlayerPrefs.GetInt("Coin", 0);

        if (PlayerPrefsCoin > coin)
        {
            coin += (PlayerPrefsCoin - coin);

            if (coin >= 100)
            {
                coin -= 100;
                int health = PlayerPrefs.GetInt("Health", 0);
                health++;
                PlayerPrefs.SetInt("Health", health);
            }

            PlayerPrefs.SetInt("Coin", coin);

            text.text = coin.ToString();
        }
    }
}
