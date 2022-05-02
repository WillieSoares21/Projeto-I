using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleInimigos : MonoBehaviour
{
    public GameObject laserDoInimigo;
    public Transform localDoDisparo;
    public GameObject itemParaDropar;
    public GameObject efeitoDeExplosao;
    public float velocidadeDoInimigo;
    public float tempoMaximoEntreOsLasers;
    public float tempoAtualDosLasers;
    public bool inimigoAtirador;
    public bool inimigiAtivado;

    // Vida
    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;
    public bool temEscudo;
    // Pontos
    public int pontosParDar;
    public int chanceParaDropar;
    //Dano
    public int danoDaNave;

    
    // Start is called before the first frame update
    void Start()
    {
        inimigiAtivado = false;
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();

        if(inimigoAtirador == true && inimigiAtivado == true)
        {
            AtirarLaser();
        }
        
    }
    public void AtivarInimigo()
    {
        inimigiAtivado = true;
    }
    private void MovimentarInimigo()
    {
        transform.Translate(Vector3.up * velocidadeDoInimigo * Time.deltaTime);
    }
    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;
        
        if(tempoAtualDosLasers <= 0)
        {
            Instantiate(laserDoInimigo, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
    }
    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;

        if(vidaAtualDoInimigo <= 0)
        {
            GameManager.instance.AumentarPontuacao(pontosParDar);
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
            EfeitosSonoros.istance.somExplosao.Play();

            int numeroAleatorio = Random.Range(0, 100);
            if(numeroAleatorio <= chanceParaDropar)
            {
                Instantiate(itemParaDropar, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }

            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D colisorInfo)
    {
        if(colisorInfo.gameObject.CompareTag("Player"))
        {
            colisorInfo.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoDaNave);
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
            EfeitosSonoros.istance.somExplosao.Play();
            Destroy(this.gameObject);
        }
    }
}
