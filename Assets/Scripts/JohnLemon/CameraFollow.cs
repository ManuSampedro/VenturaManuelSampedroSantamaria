using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Zona de Propiedades Globales
    public Transform Target;
    [Header("Vectors")]
    [SerializeField]
    private float _smoothing;
    [SerializeField]
    private Vector3 _offset;


    // Start is called before the first frame update
    void Start()
    {

        _offset = transform.position - Target.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {

        Vector3 desiredPosition = Target.position + _offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);

    }
}
