using UnityEngine;
using Unity.Netcode;

public class PlayerUImanager : MonoBehaviour
{
    public static PlayerUImanager instance;

    [Header("NETWORK JOIN")]
    [SerializeField] bool startGameAsClient;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if(startGameAsClient)
        {
            startGameAsClient = false;
            NetworkManager.Singleton.Shutdown();
            NetworkManager.Singleton.StartClient();
        }

    }

}
