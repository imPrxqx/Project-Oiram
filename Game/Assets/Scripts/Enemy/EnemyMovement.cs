using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;       //rychlost pohybu
    public  float distance;     //délka raycastu
    bool movingRight = true;  //sleduje, jakým směrem se pohybujeme
    
    public Transform groundCheck;  //pomocný objekt, ze kterého půjde reycast, který sleduje, jestli je před postavou zem (pokud ne, tak se otočí a jde druhým směrem)

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);        //postava půjde vždycky do prava


        RaycastHit2D raycastHit2D = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);    //pomocí raycastu se budeme dívat, jestli je dále zem

        if (raycastHit2D.collider == false || raycastHit2D.collider.gameObject.tag == "Enemy")     //pokud zem není
        {
            if (movingRight == true)    //a my pohybujeme doprava
            {
                transform.eulerAngles = new Vector3(0, -180, 0);       //tak se otočíme
                movingRight = false;                   //a změníme hodnotu, se kterou říkáme, že se hýbeme do prava
            }
            else                                    //jinak se udělá úplný opak
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
