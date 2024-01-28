using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class LightManager : NetworkBehaviour
{
    public NetworkVariable<bool> LightState = new NetworkVariable<bool>();
    public GameObject LightObject;

    public override void OnNetworkSpawn()
    {
        LightState.OnValueChanged += OnStateChanged;
    }

    public override void OnNetworkDespawn()
    {
        LightState.OnValueChanged -= OnStateChanged;
    }

    public void OnStateChanged(bool previous, bool current)
    {
        if (LightState.Value)
        {
            var light = LightObject.GetComponent<Light>();
            light.enabled = true;
        }
        else
        {
            var light = LightObject.GetComponent<Light>();
            light.enabled = false;
        }
    }

    [ServerRpc(RequireOwnership = false)]
    public void ToggleServerRpc()
    {
        LightState.Value = !LightState.Value;
    }
}
