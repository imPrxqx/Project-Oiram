using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float Speed = 1f;
    GameObject Camera;
    LevelGenerator levelGenerator;



    private void Start()
    {
        Camera = GameObject.Find("Main Camera");
        levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
    }

    void LateUpdate()
    {
        if (transform.position.y < levelGenerator.LowestPartY - 8)
        {
            Camera.transform.SetParent(null);
        }


        if (transform.position.y < levelGenerator.LowestPartY  - 6)
        {
            transform.Translate(new Vector3(0, 1,0) * Time.deltaTime * Speed, Space.World);
        }

    }
}
