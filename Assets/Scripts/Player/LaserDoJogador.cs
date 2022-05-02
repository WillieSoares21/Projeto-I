using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoJogador : MonoBehaviour
{
    public GameObject impactoDoLaserJogador;
    public float velocidadeDoLaser;
    public int danoParaDar;
    public float delayDeTiro;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }
    private void MovimentarLaser()
    {
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.CompareTag("Inimigo"))
        {
            colisor.gameObject.GetComponent<ControleInimigos>().MachucarInimigo(danoParaDar);
            Instantiate(impactoDoLaserJogador, transform.position, transform.rotation);
            EfeitosSonoros.istance.somImpactoDoLaser.Play();
            Destroy(this.gameObject);
        }
    }
}
