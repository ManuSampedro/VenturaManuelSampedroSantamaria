using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTank : MonoBehaviour
{

    //Zona de Variables Globales
    [Header("Game Over")]
    [SerializeField]
    private GameObject _panelGameOver;
    [SerializeField]
    private EnemyManager _enemyManager;


    void Start()
    {
        
    }


    void Update()
    {
        
    }    
   public void GameOver()
    {
        _panelGameOver.SetActive(true);
        _enemyManager.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LoadSceneLevel ()
    {
        SceneManager.LoadScene(0);
    }

}
