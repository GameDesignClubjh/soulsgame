using UnityEngine;
using Unity.Netcode;
using System.Collections;
using System.Collections.Generic;

public class TitleScreenManager : MonoBehaviour
{
 public void StartNetworkAsHost()
 {
   NetworkManager.Singleton.StartHost();
 }

 
   public void StartNewGame()
  {      
      StartCoroutine(WorldSaveGameManager.instance.LoadNewGame());
  }
}   
