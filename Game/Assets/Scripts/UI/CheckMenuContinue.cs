using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMenuContinue : MonoBehaviour
{
    SaveLoad saveLoad;

    void Start()
    {
        saveLoad = GetComponent<SaveLoad>();        //získávám komponet SaveLoad

        bool isFile = saveLoad.FileExists();       //dívá se jestli save existuje

        Button button = GetComponent<Button>();     //získávám komponet button

        if (isFile)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }

    }
}
