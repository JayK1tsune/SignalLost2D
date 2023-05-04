using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource audioSource;
    void Awake()
    {
        
    }
    void OnDisable()
    {
        
    }
    public void PlayGame(){
        SceneManager.LoadScene(0);
    }
    public void StartGame(){
        SceneManager.LoadScene(0);
    }
    public void MainMenu(){
        SceneManager.LoadScene(2);
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }
}
