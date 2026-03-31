using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
   private const string GameScene = "Game";
   
   public void StartGame()
   {
      SceneManager.LoadScene(GameScene);
   }
}
