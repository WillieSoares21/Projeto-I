using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitosSonoros : MonoBehaviour
{
    public static EfeitosSonoros istance; 
    public AudioSource somExplosao, somDeColetavel;
    public AudioSource somLaserJogador, somDeDanoJoagdor;
    public AudioSource somLaserInimigo, somDeDanoinimigo;
    public AudioSource somImpactoDoLaser, somDaCaixa;

    void Awake()
    {
        istance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
