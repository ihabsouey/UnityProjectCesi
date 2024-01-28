using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class NetworkPlayer : NetworkBehaviour
{   
    public Camera camera;
    [SerializeField] PlayerInputManager  playerInputManager;
    [SerializeField] PlayerInput playerInput;

    public override void OnNetworkSpawn()
    {
        if(IsOwner)
        {
            camera.gameObject.SetActive(true);
            playerInput.enabled = true;
            playerInputManager.enabled = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
