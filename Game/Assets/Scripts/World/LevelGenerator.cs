using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //tenhle skript sestavuje level z předvytvořených částí/prefabů
    //jelikož jsem netušil jak na to, tak téměř celý skript je z tutorialu od CodeMonkey
    //tento skrypt vytváří části na místech, kde se nacházý empty object, který se jmenuje EndPoint
    //částí levelu se dávají dovnitř pomocí editoru -> [SerializeField]

    [SerializeField] private Transform levelPart_Start;        // sem se vkládá začínající platforma(musí mít EndPoint) 
    [SerializeField] private List<Transform> levelPartList;     //sem se vkládá list prefabů, ze kterých se level bude skládat
    [SerializeField] private Transform CheckPointPart;  //sem se vkládá checkpoint platforma
    [SerializeField] private Transform EndLevelPart;        //sem se vkládá finální platforma, na který se nachází drahokam pro ukončení levelu

    private Vector3 lastEndPoint;   //v tomto atributu se ukládá poslední Endpoint, který se využívá pro spawnutí další části levelu

    public double LowestPartY = -10;     //nejnižší bod levelu


    void Awake()
    {
        lastEndPoint = levelPart_Start.Find("EndPoint").position;   //tady se poprvé najde endpoint

        int r = Random.Range(20, 30);   //kolik levelpartů level bude mít?
        int polovina = r / 2;   // v polovině se bude generovat checkpoint

        for (int i = 0; i < r; i++)  //cycle, který poskládá na začátku hry, celý level 
        {
            if (i == polovina)
            {
                SpawnCheckpointLevelPart(); //spawne checkpoint levelpart
            }
            else
            {
                SpawnLevelPart();  //metoda pro spawnutí levelu
            }
        }

        //spawn poslední platfromy s drahokamem
        Instantiate(EndLevelPart, lastEndPoint, Quaternion.identity);
    }

    private void SpawnLevelPart()
    {
        Transform pickedLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];   //vybere se level part z listu
        Transform lastLevelPartTransform = SpawnLevelPart(pickedLevelPart, lastEndPoint);   //volá se stejno jmenná metoda, která spawne level part na scéně a její instanci   
        lastEndPoint = lastLevelPartTransform.Find("EndPoint").position;                    //vrací zpět sem, aby se nalezl poslední endpoint

        if (LowestPartY > lastEndPoint.y)  //pro kameru si zjistím nejnižší bod levelu (abych věděl kde bude hráče umírat kvůli pádu)
        {
            LowestPartY = lastEndPoint.y;
        }
    }

    private void SpawnCheckpointLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(CheckPointPart, lastEndPoint);   //volá se stejno jmenná metoda, která spawne level part na scéně a její instanci   
        lastEndPoint = lastLevelPartTransform.Find("EndPoint").position;                    //vrací zpět sem, aby se nalezl poslední endpoint

        if (LowestPartY > lastEndPoint.y)  //pro kameru si zjistím nejnižší bod levelu (abych věděl kde bude hráče umírat kvůli pádu)
        {
            LowestPartY = lastEndPoint.y;
        }
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);  //vytvoří level part na scéně
        return levelPartTransform;  // vrací instanci teď vytvořeného level partu
    }
}
