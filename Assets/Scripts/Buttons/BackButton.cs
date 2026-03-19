using UnityEngine;
using UnityEngine.InputSystem;

public class BackButton : MonoBehaviour
{
   private void Update()
   {
      if(Keyboard.current != null && (Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.backspaceKey.wasPressedThisFrame))
         Application.Quit();
   }
}
