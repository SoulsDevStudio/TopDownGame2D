using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rb;

    private float initialSpeed;

    private int handlingObj;

    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;

    private Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool IsCutting { get => _isCutting; set => _isCutting = value; }
    public bool IsDigging { get => _isDigging; set => _isDigging = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObj = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObj = 2;
        }

        OnInput();
        OnRun();
        OnRoll();

        switch (handlingObj)
        {
            case 1:
                OnCutting();
                break;

            case 2:
                OnDig();
                break;
        }
        
    }

    private void FixedUpdate()
    {
        OnMovi();
    }

    #region Movement

    void OnCutting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsCutting = true;
            speed = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsCutting = false;
            speed = initialSpeed;
        }

    }

    void OnDig()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsDigging = true;
            speed = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsDigging = false;
            speed = initialSpeed;
        }

    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMovi()
    {
        rb.MovePosition(rb.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
        }
    }

    #endregion

}
