using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour {

    [SerializeField]
    private GameObject _needleBody;

    private bool _isNeedleFired;
    private bool _circleTouched;

    private float speedY = 5f;

    private Rigidbody2D _needleRigidBody;

    void Awake()
    {
        Initialize();
        FireNeedle();
    }

    void Initialize()
    {
        _needleBody.SetActive(false);
        _needleRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isNeedleFired)
        {
            _needleRigidBody.velocity = new Vector2(0, speedY);
        }
    }

    public void FireNeedle()
    {
        _needleBody.SetActive(true);
        _needleRigidBody.isKinematic = false;
        _isNeedleFired = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (_circleTouched)
            return;

        if(target.tag == "Circle")
        {
            _isNeedleFired = false;
            _circleTouched = true;
            _needleRigidBody.isKinematic = true;
            _needleRigidBody.simulated = false;
            gameObject.transform.SetParent(target.transform);
        }

    }
}
