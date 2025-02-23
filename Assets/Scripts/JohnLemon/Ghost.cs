using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Ghost : MonoBehaviour
{

    //Zona de variables Globales

    [SerializeField]
    private Transform[] _positionsArray;

    [SerializeField]
    private float _speed;

    private Vector3 _posToGo;

    private int _i;
    private Ray _ray;
    private RaycastHit _hit;

    public GameManager GameManagerScript;

    // Start is called before the first frame update
    void Start()
    {

        _i = 0;
        _posToGo = _positionsArray[_i].position;
        


    }

    // Update is called once per frame
    void Update()
    {

        Move();
        ChangePosition();
        Rotate();



    }


    private void DetectionJohnLemon()
    {
        _ray.origin = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        _ray.direction = transform.forward;

        if (Physics.Raycast(_ray, out _hit))
        {

            if (_hit.collider.CompareTag("JohnLemon"))
            {
                Debug.Log("El Fantasmas te ha pillado");
                GameManagerScript.IsPlayerCaught = true;
            }
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _posToGo, _speed * Time.deltaTime);

        if (transform.position == _posToGo)
        {

            _i++;

            if (_i == _positionsArray.Length)
            {

                _i = 0;

            }

            _posToGo = _positionsArray[_i].position;

        }
    }

    private void ChangePosition()
    {

        if(Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon)
        {
            
            if (_i == _positionsArray.Length - 1)
            {
                _i = 0;
            }
            else
            {
                _i++;
            }
            _posToGo = _positionsArray[_i].position;
        }

    }

    private void Rotate()
    {

        transform.LookAt(_posToGo);

    }

}
