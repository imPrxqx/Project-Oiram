using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhichBackground : MonoBehaviour
{
    /// <summary>
    /// V naší hře máme prefab hráče, máme to tak, abychom mohli jednoduše dělat na jeho prefabu změny
    /// 
    ///Problémem je, že máme více prostředí a mi máme na hráče připlí background
    /// 
    /// Tento skript se stará o to, aby se deaktivovali ta pozadí, která nejsou potřeba
    /// 
    /// Máme v PlayerPrefs atribut, který nám říká, jaký je momentálně level. Budeme si ho proto brát a podle toho jaký je číslo, tak ho deaktivujeme
    /// 
    /// </summary>

    public List<int> levels; // vytvářím list, ve kterým vložím číslo každého levelu, pro který bude pozadí platit 


    void Start()
    {
        bool isGood = false;    
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);   //získám current level
        Debug.Log
            (currentLevel);

        foreach (int x in levels)
        {
            if (x+1 == currentLevel)  // je podporovaný level z listu current levelem?
            {
                isGood = true;
            }
        }

        if (isGood) //pokud byl jeden z podporovaných levelů z listu current levelem
        {
            gameObject.SetActive(true);    // Aktivuji pozadí
        }
        else
        {
            gameObject.SetActive(false);    // Deaktivuji pozadí
        }
    }
}
