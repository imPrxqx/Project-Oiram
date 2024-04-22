using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMapLevels : MonoBehaviour
{
    SaveLoad saveLoad;

    public List<Button> buttonList;

    void Start()
    {
        saveLoad = GetComponent<SaveLoad>();        //získávám komponet SaveLoad

        bool isFile = saveLoad.FileExists();       //dívá se jestli save existuje, pokud není tak si leveli berou z PlayerPrefs


        for (int i = 0; i < 12; i++)    //povypínám všechny levely
        {
            buttonList[i].interactable = false;
        }


        if (isFile)     
        {
            int b = saveLoad.GetLevelFromLoad();    //získávám počet levelů ze savu

            for (int i = 0; i < b; i++)
            {
                buttonList[i].interactable = true;
            }
        }
        else
        {
            for (int i = 0; i < PlayerPrefs.GetInt("Level", 1); i++)
            {
                buttonList[i].interactable = true;
            }
        }
    }
}
