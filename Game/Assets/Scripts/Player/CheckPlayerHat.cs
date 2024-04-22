using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerHat : MonoBehaviour
{
    SpriteRenderer component;

    private void Start()
    {
        component = GetComponent<SpriteRenderer>();      //získávám obrázek čepice
    }

    void LateUpdate()
    {
        if (PlayerPrefs.GetInt("Hat", 0) == 1)  //dívám se jestli mám čepici, pokud ano, tak se ukáže čepice na ikoně u životů
        {
            component.enabled = true;
        }
        else
        {
            component.enabled = false;
        }
    }
}
