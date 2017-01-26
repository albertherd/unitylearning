using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 50f;

    private bool _canRotate;
    private float angle;

    void Awake()
    {
        _canRotate = true;
    }

	// Update is called once per frame
	void Update () {
	    if (_canRotate)
	    {
	        RotateCircle();
	    }
	}

    void RotateCircle()
    {
        angle = transform.rotation.eulerAngles.z;
        angle += _rotationSpeed*Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
