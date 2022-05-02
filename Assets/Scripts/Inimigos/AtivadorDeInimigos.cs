using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorDeInimigos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.CompareTag("Inimigo"))
        {
            colisor.gameObject.GetComponent<ControleInimigos>().AtivarInimigo();
        }
    }
    
    
}
