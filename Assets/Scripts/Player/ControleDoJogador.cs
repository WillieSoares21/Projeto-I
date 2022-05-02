using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{
    public Rigidbody2D rig;
    // Delay de Tiro
    public float delayTiro;
    public GameObject laserDoJogador;
    public Transform localDoDisparoUnico;
    //Tiro Laser
    public Transform localDoDisparoDaEsquerda;
    public Transform localDoDisparoDaDireita;
    public float tempoMaximoDosLasersDuplo;
    public float tempoAtualDosLasersDuplo;
    public bool temLaserDuplo;
    public bool jogadorEstaVivo;
    //Movimento
    public float velocidadeMovimento;
    
    private Vector2 teclasApertadas;

    // Start is called before the first frame update
    void Start()
    {
        temLaserDuplo = false;
        tempoAtualDosLasersDuplo = tempoMaximoDosLasersDuplo;
        jogadorEstaVivo = true;       
    }

    // Update is called once per frame
    void Update()
    {
      MovimentarJogador();
      
      if(jogadorEstaVivo == true)
      {
        AtirarLaser();
      }
      
      if(temLaserDuplo == true)
      {
        tempoAtualDosLasersDuplo -= Time.deltaTime;

        if(tempoAtualDosLasersDuplo <= 0)
        {
          DesativarLaserDuplo();
        }
      }
    }
    private void MovimentarJogador()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rig.velocity = teclasApertadas.normalized * velocidadeMovimento;
    }
    private void AtirarLaser()
    {
      if(Input.GetButtonDown("Fire1"))
      {
          
          if(temLaserDuplo == false)
          {
            Instantiate(laserDoJogador, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
            EfeitosSonoros.istance.somLaserJogador.Play();
          }
          else
          {
            Instantiate(laserDoJogador, localDoDisparoDaEsquerda.position, localDoDisparoDaEsquerda.rotation);
            Instantiate(laserDoJogador, localDoDisparoDaDireita.position, localDoDisparoDaDireita.rotation);
            EfeitosSonoros.istance.somLaserInimigo.Play();
          }

      }
    }
    private void DesativarLaserDuplo()
    {
      temLaserDuplo = false;
      tempoAtualDosLasersDuplo = tempoMaximoDosLasersDuplo;
    }
    
}
