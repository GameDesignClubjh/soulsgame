using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [Header("Requires an adjacent RigidBody2d")]
    [Space]

    [Header("Physical Properties")]
    public FloatAttribute MovementSpeed = 2.5f;
    public float Friction = 10f;
   

    [Header("Entity Properties")]
    public FloatAttribute MaxHealth = 100f;



    private float health;


    private Vector2 queuedVelocity;
    private Vector2 queuedFriction;
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
        queuedVelocity = velocity * MovementSpeed.Get();
        Debug.Log(queuedVelocity);

        
    }

    // Apply the queued movement every frame.
    void ApplyMovement()
    {
        if (queuedVelocity != Vector2.zero)
        {
            rb.linearVelocity = queuedVelocity;
        }
        else
        { 
              
            Debug.Log("working");
          
        }
           
        
        


        /// Queue movement must be higher than current velocity to apply.
       /* 
        if (math.abs(queuedVelocity.x) >= math.abs(rb.linearVelocity.x))
        {
            rb.linearVelocityX = queuedVelocity.x;
        }

        if (math.abs(queuedVelocity.y) >= math.abs(rb.linearVelocity.y))
        {
            rb.linearVelocityY = queuedVelocity.y;
        }

        queuedVelocity = Vector2.zero;
       */
      
      
        
            
        
       
    }

    // Apply friction forces
    void ApplyFriction(float delta)
    {
        //rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, delta*Friction.Get());
        rb.linearDamping = Friction;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = MaxHealth.Get();
    }

    void FixedUpdate()
    {

       
       // ApplyFriction(Time.fixedDeltaTime);
        ApplyMovement();
        Debug.Log(Time.fixedDeltaTime);
    }
}
