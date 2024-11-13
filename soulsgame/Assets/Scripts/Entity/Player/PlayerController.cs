using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public EntityController Controller;

    [Header("Player Properties")]
    public float MaxDashCooldown = 0.25f;
    public float MaxDashDuration = 0.2f;
    public float DashSpeedMultiplier = 4.5f;

    [HideInInspector]
    public float dashCooldown = 0;


    private float dashTime = 0;
    private Vector2 dashDirection;
    

    // Handles regular player related movement.
    // !!! Will not be executed if the player is dashing.
    void HandleMovement()
    {
        if (dashTime > 0)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        Controller.Move(direction);
    }

    // Called while the player is dashing.
    void WhileDashing(float delta)
    {
        dashTime -= delta;
        Controller.Move(dashDirection * DashSpeedMultiplier);
    }

    // Checks when the player is dashing.
    void HandleDashes(float delta)
    {

        if (dashTime > 0)
        {
            WhileDashing(delta);
            return;
        }
        if (dashCooldown > 0) {
            dashCooldown -= delta;
            return;
        }

        if (Input.GetAxis("Jump") == 0)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        dashDirection = new Vector2(horizontal, vertical).normalized;
        dashTime = MaxDashDuration;
        dashCooldown = MaxDashCooldown;
    }


    void FixedUpdate()
    {
        HandleMovement();
        HandleDashes(Time.fixedDeltaTime);
    }
}
