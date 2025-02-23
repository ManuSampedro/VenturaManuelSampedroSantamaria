using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTank : MonoBehaviour
{

    public Transform Target;
    [Header("Vectors")]
    [SerializeField]
    private float _smoothing;
    [SerializeField]
    private Vector3 _offset;


    void Start()
    {

        _offset = transform.position - Target.position;

    }

    private void LateUpdate()
    {


        Vector3 desiredPosition = Target.position + _offset;


        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);

    }


}