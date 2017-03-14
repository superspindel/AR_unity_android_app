using UnityEngine;


/// <summary>
///The class that controls the camera movments. 
/// </summary>
/// <remarks>
/// <para>initialSpeed (float) speed of camera movment</para>
/// <para>increaseSpeed (float) a slite asserlation of speed of camera movment</para>
/// <para>cursorSensiticity (float) the sensetiviti of the mouse movments</para>
/// </remarks>
[RequireComponent(typeof(Camera))]
public class GhostFreeRoamCamera : MonoBehaviour
{
    //speed setings
    public float initialSpeed = 35f;
    public float increaseSpeed = 1.25f;
    public float cursorSensitivity = 0.025f;

    //aktive buttons
    private KeyCode forwardButton = KeyCode.W;
    private KeyCode backwardButton = KeyCode.S;
    private KeyCode rightButton = KeyCode.D;
    private KeyCode leftButton = KeyCode.A;
    private KeyCode alowe = KeyCode.LeftShift;

    

    //control cariabels to control movment
    private bool allowMovement = true;
    private bool allowRotation = true;
    private bool moving = false;
    private bool frees = true;
    private float currentSpeed = 0f;


    
   

    /// <summary>
    /// Mostly borovd from GhostFreeRoamCamera
    /// Seting the camera updats in motion
    /// </summary>
    private void Update()
    {
        //do stufe that makes the movment
        if (allowMovement)
        {
            bool lastMoving = moving;
            Vector3 deltaPosition = Vector3.zero;

            if (moving)
                currentSpeed += increaseSpeed * Time.deltaTime;

            moving = false;

            CheckMove(forwardButton, ref deltaPosition, transform.forward);
            CheckMove(backwardButton, ref deltaPosition, -transform.forward);
            CheckMove(rightButton, ref deltaPosition, transform.right);
            CheckMove(leftButton, ref deltaPosition, -transform.right);

            if (moving)
            {
                if (moving != lastMoving)
                    currentSpeed = initialSpeed;

                transform.position += deltaPosition * currentSpeed * Time.deltaTime;
            }
            else currentSpeed = 0f;
        }

        //do stuf thet make the rotation
        if (allowRotation)
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x += -Input.GetAxis("Mouse Y") * 359f * cursorSensitivity;
            eulerAngles.y += Input.GetAxis("Mouse X") * 359f * cursorSensitivity;
            transform.eulerAngles = eulerAngles;
        }



        //@auther Samuel Karlsson
        //look camera position
        if (Input.GetKey(alowe))
        {
            if (!frees) toggle();
        }
        else frees = false;
      

    }
    /// <summary>
    /// Toggel betven loock camer positon and moving
    /// </summary>
    /// <remarks>@auter Samuel Karlsson</remarks>
    private void toggle()
    {
        frees = true;
        allowMovement = !allowMovement;
        allowRotation = !allowRotation;
        
    }

   
 

    /// <summary>
    /// Borovd from GhostFreeRoamCamera
    /// Make the aktual move of the camera if the movmet key is prest
    /// </summary>
    /// <param name="keyCode" >(KeyCode) The dyraktion keys</param>
    /// <param name="deltaPosition">(Vector3) The curent camera postion</param>
    /// <param name="directionVector">(Vector3) Movment diraktin and distans</param>
    private void CheckMove(KeyCode keyCode, ref Vector3 deltaPosition, Vector3 directionVector)
    {
        if (Input.GetKey(keyCode))
        {
            moving = true;
            deltaPosition += directionVector;
        }
    }
}
