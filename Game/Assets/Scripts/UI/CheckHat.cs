using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckHat : MonoBehaviour
{
    Image component;

    private void Start()
    {
        component = GetComponent<Image>();      //získávám obrázek čepice
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
