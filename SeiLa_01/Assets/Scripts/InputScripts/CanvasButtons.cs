using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class CanvasButtons : NetworkBehaviour
{
    [SerializeField]
    private TextMeshProUGUI clientesConectados;
    private NetworkVariable<int> playersNum = 
        new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }
    public void StartCliant()
    {
        NetworkManager.Singleton.StartClient();
    }

    private void Update()
    {
        clientesConectados.text = playersNum.Value.ToString();
        if (!IsServer) return;
        playersNum.Value = NetworkManager.Singleton.ConnectedClients.Count;
    }
}
