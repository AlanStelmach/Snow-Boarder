using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 8.0f;
    [SerializeField] float boostSpeed = 30.0f;
    [SerializeField] float normalSpeed = 20.0f;
    SurfaceEffector2D effector;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        effector = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControles()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector.speed = boostSpeed;
        }
        else
        {
            effector.speed = normalSpeed;
        }
    }
}
