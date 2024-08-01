using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Components
    Rigidbody2D rb2d;

    //Movement and Rotation 
    float horizontal;
    float vertical;
    Vector2 movementVector;
    public float movementSpeed = 5.0f;

    public float rotationSpeed = 5f;

    #region Singleton
    public static PlayerController _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }
    #endregion //!Singleton

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Movement Vector
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Rotate player towards Mouse Position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        movementVector = new Vector2(horizontal, vertical).normalized;
        rb2d.velocity = movementVector * movementSpeed;
        Debug.Log(rb2d.velocity.magnitude);
    }
}
