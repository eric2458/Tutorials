using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{ 
    [SerializeField]public float moveSpeed = 7f;
  private void Update()
  {
      Vector2 inputVector = new Vector2(0, 0);
        if (Keyboard.current.wKey.isPressed)
        {
            inputVector.y = +1;
            //Debug.Log("Pressed W");
        }
        if (Keyboard.current.sKey.isPressed)
        {
            inputVector.y = -1;
            //Debug.Log("Pressed A");
        }if (Keyboard.current.aKey.isPressed)
        {
            inputVector.x = -1;
            //Debug.Log("Pressed S");
        }if (Keyboard.current.dKey.isPressed)
        {
            inputVector.x = +1;
            //Debug.Log("Pressed D");
        }

        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime; 
        Debug.Log(Time.deltaTime);
  }
}
