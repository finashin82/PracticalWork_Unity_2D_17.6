using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingBoxAndMine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {            
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
