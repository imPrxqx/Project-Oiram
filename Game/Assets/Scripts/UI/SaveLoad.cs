using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public void Save()  //metoda pro ukládání; ukládám save někde v systému(adresu získávám z Application.persistentDataPath, proto aby se nestalo, že cesta nebude existovat a hráč jen tak nebude vědět, kde se to nachází); ukládá se v bináru(kvůli horší  editaci souboru)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save.oiram";

        FileStream fileStream = new FileStream(path, FileMode.Create);

        Data data = new Data(PlayerPrefs.GetInt("Health", 3), PlayerPrefs.GetInt("Coin", 0), PlayerPrefs.GetInt("Level", 1));

        formatter.Serialize(fileStream, data);

        fileStream.Close();
    }

    public void Load()  //metoda pro load savu
    {
        string path = Application.persistentDataPath + "/save.oiram";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(fileStream) as Data;

            PlayerPrefs.SetInt("Health", data.health);
            PlayerPrefs.SetInt("Coin", data.coin);
            PlayerPrefs.SetInt("Level", data.level);
        }
        else
        {
            Debug.Log("Žádný save");
        }
    }

    public int GetLevelFromLoad()   //metoda, která získá počet levelů ze savu 
    {
        string path = Application.persistentDataPath + "/save.oiram";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(fileStream) as Data;

            return data.level;
        }
        else
        {
            Debug.Log("Žádný save");
            return 1;
        }
    }

    public bool FileExists()    // //metoda, která vrací boolean o tom jestli save existuje 
    {
        string path = Application.persistentDataPath + "/save.oiram";

        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            Debug.Log("Žádný save");
            return false;
        }
    }
}


[System.Serializable]
public class Data   //třída, díky které snadněji pracuji s daty
{
    public int health;
    public int coin;
    public int level;

    public Data(int _health, int _coin, int _level)
    {
        health = _health;
        coin = _coin;
        level = _level;
    }
}