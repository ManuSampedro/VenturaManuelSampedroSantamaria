using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    //Zona de variables Globales
    [SerializeField]
    private GameObject _shellPrefab;
    [SerializeField]
    private Transform _posShell;
    [SerializeField]
    private float _launchForce;
    [SerializeField]
    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        InputPlayer();

    }

    private void InputPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Launch();
        }
    }

    private void Launch()
    {
        
        GameObject cloneShellPrefab = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);

        _audioSource.Play();

        cloneShellPrefab.GetComponent<Rigidbody>().velocity = _posShell.forward * _launchForce;

    }
}
