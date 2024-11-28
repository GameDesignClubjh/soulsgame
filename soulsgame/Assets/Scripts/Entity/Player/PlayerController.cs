using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public EntityController Controller;

    [Header("Player Properties")]
    public FloatAttribute MaxDashCooldown = 0.25f;
    public FloatAttribute MaxDashDuration = 0.2f;
    public FloatAttribute DashSpeedMultiplier = 4.5f;


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
        Controller.Move(dashDirection * DashSpeedMultiplier.Get());
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
        dashTime = MaxDashDuration.Get();
        dashCooldown = MaxDashCooldown.Get();
    }


    void FixedUpdate()
    {
        HandleMovement();
        HandleDashes(Time.fixedDeltaTime);
    }
}
