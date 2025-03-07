using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{
    //Zona de variables Globales
    [SerializeField]
    private GameObject _player;
    private NavMeshAgent _agent;

    private void Awake()
    {
     
        _player = GameObject.FindGameObjectWithTag("TankPlayer");
        _agent = GetComponent<NavMeshAgent>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_player == null)
        {
            return;

        }

        GetPlayer();

    }


    private void GetPlayer()
    {
        _agent.SetDestination(_player.transform.position);
    }
}
