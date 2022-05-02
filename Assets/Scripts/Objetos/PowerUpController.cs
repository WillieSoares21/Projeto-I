using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public bool itemDeEscudo;
    public bool itemDeLaserDuplo;
    public bool itemDeVida;
    public int vidaParaDar;    
    
    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.CompareTag("Player"))
        {
            if(itemDeEscudo == true)
            {
                colisor.gameObject.GetComponent<VidaDoJogador>().AtivarEscudo();
            }
            if(itemDeLaserDuplo == true)
            {
                colisor.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo = false;
                colisor.gameObject.GetComponent<ControleDoJogador>().tempoAtualDosLasersDuplo = colisor.gameObject.GetComponent<ControleDoJogador>().tempoMaximoDosLasersDuplo;
                colisor.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo = true;
            }
            if(itemDeVida == true)
            {
                colisor.gameObject.GetComponent<VidaDoJogador>().GanharVidas(vidaParaDar);
            }
            EfeitosSonoros.istance.somDeColetavel.Play();
            Destroy(this.gameObject);
        }
    }
}
