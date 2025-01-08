using System;
using Unity.Mathematics;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [Header("Physical Properties")]
    public float MovementSpeed;
    public float Friction;

    [Header("Entity Properties")]
    public float MaxHealth;

    [NonSerialized]
    private float health;


    private Vector2 queuedVelocity;
    private Rigidbody2D rb;
    

    /// <summary>
    /// Heals the entity by a designated amount.
    /// </summary>
    /// <param name="healthPoints">The amount to heal</param>
    public void Heal(float healthPoints)
    {
        if (healthPoints == 0)
            return;
        
        if (healthPoints < 0) 
        {
            Damage(-healthPoints);
            return; 
        }
        
        health += healthPoints;
    }

    /// <summary>
    /// Damages the entity by a designated amount.
    /// </summary>
    /// <param name="damagePoints">The amount to damage</param>
    public void Damage(float damagePoints)
    {
        if (damagePoints == 0)
            return;

        if (damagePoints < 0)
        {
            Heal(-damagePoints);
            return;
        }

        health -= damagePoints;
    }

    /// <summary>
    /// Attempts to assign the velocity of the entity. If the entity is already moving faster than the target velocity, it will ignore this operation.
    /// </summary>
    /// <param name="velocity">The target velocity</param>
    public void Move(Vector2 velocity)
    {
        queuedVelocity += velocity * MovementSpeed;
    }

    // Apply the queued movement every frame.
    void ApplyMovement()
    {
        if (queuedVelocity == Vector2.zero) {
            return;
        }

        // Queue movement must be higher than current velocity to apply.
        if (math.abs(queuedVelocity.x) >= math.abs(rb.linearVelocity.x))
        {
            rb.linearVelocityX = queuedVelocity.x;
        }

        if (math.abs(queuedVelocity.y) >= math.abs(rb.linearVelocity.y))
        {
            rb.linearVelocityY = queuedVelocity.y;
        }

        queuedVelocity = Vector2.zero;
    }

    // Apply friction forces.
    void ApplyFriction(float delta)
    {
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, delta * Friction);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = MaxHealth;
    }

    void FixedUpdate()
    {
        ApplyFriction(Time.fixedDeltaTime);
        ApplyMovement();
    }
}
