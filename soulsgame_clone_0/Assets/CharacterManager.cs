using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
