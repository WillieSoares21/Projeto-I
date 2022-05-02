using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoInimigo : MonoBehaviour
{
    public GameObject impactoDoLaserInimigo;
    public float velocidadeDoLaser;
    public int danoParaDar;

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
        if(colisor.gameObject.CompareTag("Player"))
        {
            colisor.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoParaDar);
            Instantiate(impactoDoLaserInimigo, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
