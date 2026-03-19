using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
   private const string Forest1Scene = "Forest1";
   
   public void StartGame()
   {
      SceneManager.LoadScene(Forest1Scene);
   }
}
