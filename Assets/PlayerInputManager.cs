using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class PlayerInputManager : NetworkBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 1f;

    [SerializeField] Camera playerCamera;
    [SerializeField] Rigidbody playerRigidbody;

    Vector2 _look , _move;

    public void onLook(InputValue value)
    {
        _look = value.Get<Vector2>();
    }   
    public void onMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndLookServerRpc(_look , _move);
        LookY();
    }
    public void LookY()
    {
        playerCamera.transform.Rotate(Vector3.right , - _look.y * mouseSensitivity * Time.deltaTime);
    }

    [ServerRpc]
    public void MoveAndLookServerRpc(Vector2 look , Vector2 move)
    {
        MoveAndLook(look , move);
    }


    public void MoveAndLook(Vector2 look , Vector2 move)
    {
        // Look
        transform.Rotate(Vector3.up , look.x * mouseSensitivity * Time.deltaTime );
        playerCamera.transform.Rotate(Vector3.right , - look.y * mouseSensitivity * Time.deltaTime);

        // Move
        Vector3 direction = Quaternion.Euler(0f , transform.eulerAngles.y , 0f) * new Vector3(move.x , 0f , move.y);
        playerRigidbody.MovePosition(transform.position + ( speed * Time.deltaTime * direction));
    }

  

    


}
