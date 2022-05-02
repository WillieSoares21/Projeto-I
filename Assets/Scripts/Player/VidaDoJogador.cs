using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{
    public Slider barraDeVidaDoJogador;
    public Slider barraDeEnergiaDoEscudo;
    public GameObject escudoDoJogador;
    //Vida
    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador;
    //Escudo
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;
    public bool temEscudo;
    public GameObject efeitoDeExplosao;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        
        barraDeEnergiaDoEscudo.maxValue = vidaMaximaDoEscudo;
        barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;
        barraDeEnergiaDoEscudo.gameObject.SetActive(false);
        
        barraDeVidaDoJogador.maxValue = vidaMaximaDoJogador;
        barraDeVidaDoJogador.value = vidaAtualDoJogador;

        escudoDoJogador.SetActive(false);
        temEscudo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AtivarEscudo()
    {
        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;
        barraDeEnergiaDoEscudo.gameObject.SetActive(true);
        escudoDoJogador.SetActive(true);
        temEscudo = true;
    }
    public void GanharVidas(int vidaParaReceber)
    {
        if(vidaAtualDoJogador + vidaParaReceber <= vidaMaximaDoJogador)
        {
            vidaAtualDoJogador += vidaParaReceber;
        }
        else
        {
            vidaAtualDoJogador = vidaMaximaDoJogador;
        }
        barraDeVidaDoJogador.value = vidaAtualDoJogador;
    }
    public void MachucarJogador(int danoParaReceber)
    {
        if(temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;
            barraDeVidaDoJogador.value = vidaAtualDoJogador;

            if(vidaAtualDoJogador <= 0)
            {
                FindObjectOfType<ControleDoJogador>().jogadorEstaVivo = false;
                Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
                EfeitosSonoros.istance.somExplosao.Play();
                GameManager.instance.GameOver();
                Debug.Log("Game Over!");
            }
        }
        else
        {
            vidaAtualDoEscudo -= danoParaReceber;
            barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

            if(vidaAtualDoEscudo <= 0)
            {
                escudoDoJogador.SetActive(false);
                temEscudo = false;
                barraDeEnergiaDoEscudo.gameObject.SetActive(false);
            }
        }
    }

}
