using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorRegressivo : MonoBehaviour
{
    public float _tempoInicial = 3;
    public Text _contadorRegressivo;
    public GameObject contador;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        if(_tempoInicial == 0)
            {
                contador.SetActive(false);
                Time.timeScale = 1f;
            }
        _contadorRegressivo.text = _tempoInicial.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(_tempoInicial >= 0)
        {
            _tempoInicial = _tempoInicial - Time.deltaTime;
            _contadorRegressivo.text = Mathf.Round(_tempoInicial).ToString();
            
        }
    }
}
