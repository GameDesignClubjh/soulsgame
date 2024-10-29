using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class WorldSaveGameManager : MonoBehaviour
{
  public static WorldSaveGameManager instance;
  [SerializeField] int worldSceneIndex = 1;
  
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }
   public void Start()
   {
     DontDestroyOnLoad(gameObject);
   }

   public IEnumerator LoadNewGame()
   {
     AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);
      
      yield return null;
   }
}