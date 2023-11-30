using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDoubleItemScript : MonoBehaviour
{
    public GameObject DoubleItem;
    public GameObject Ball;


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "/*패들 태그*/")
        { 
            GetDoubleItem();
        }
        

    }
    public void GetDoubleItem()
    {
        float x = Ball.transform.position.x;
        float y = Ball.transform.position.y;
        Instantiate(Ball,new Vector3(x,y), Quaternion.identity);
    }
}
