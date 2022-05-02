using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer controleSom;
    public AudioMixer controleEfeitos;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolumeMusica(float volume)
    {
        controleSom.SetFloat("VolumeMusica", volume);
    }
    public void SetVolumeEfeitos(float volumeBmg)
    {
        controleEfeitos.SetFloat("VolumeEfeitos", volumeBmg);
    }
}
