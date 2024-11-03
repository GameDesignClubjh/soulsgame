using UnityEngine;

public class PlayerManager : CharacterManager
{
    PlayerLocomotionManager playerLocomotionManager;

    protected override void Awake()
    {
        base.Awake();
        // Add your custom logic for player-specific character initialization here

        playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
    }

    protected override void Update()
    {
        base.Update();


        //Handle All Movement
        playerLocomotionManager.HandleAllMovement();
    }
}
