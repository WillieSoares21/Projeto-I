using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChamaCena : MonoBehaviour
{
    
    public void TrocaCena(string nome)
    {
        SceneManager.LoadScene(nome);
    }
    public void SairDoJogo()
    {
        Application.Quit();
        Debug.Log("Saiu Do Jogo!");
    }

    
}
