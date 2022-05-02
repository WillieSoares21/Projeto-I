using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruidorDeInimigos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.CompareTag("Inimigo"))
        {
            Destroy(colisor.gameObject);
        }
    }
}
