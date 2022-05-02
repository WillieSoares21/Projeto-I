using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleDeCena : MonoBehaviour
{
    public float transitionTime = 1f;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }
    
    public void LoadNextLevel()
    {
        //StarCourotine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
