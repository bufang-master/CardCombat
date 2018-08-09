using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_09_04 : MonoBehaviour {

    string IP = "192.168.31.136";
    int port = 10000;

    public Text inputMessage;

    public Text receiveMessage;
    private void Start()
    {
        receiveMessage.text = "";
    }
    private void OnGUI()
    {
        switch (Network.peerType)
        {
            case NetworkPeerType.Disconnected:
                StartServer();
                break;
            case NetworkPeerType.Server:
                break;
            case NetworkPeerType.Connecting:
                break;
            case NetworkPeerType.Client:
                break;
        }
    }

    private void StartServer()
    {
        if (GUILayout.Button("连接服务器"))
        {
            NetworkConnectionError error = Network.Connect(IP, port);
            Debug.Log("连接状态：" + error);
            GUILayout.Label("连接状态：" + error);
        }
    }

    public void SendMessage()
    {
        Debug.Log("send" + inputMessage.text + Network.peerType);
        if (Network.peerType == NetworkPeerType.Client)
        {
            Debug.Log("send" + inputMessage.text);
            GetComponent<NetworkView>().RPC("RequestMessage", RPCMode.All, inputMessage.text);
        }
    } 

    [RPC]
    void RequestMessage(string message,NetworkMessageInfo info)
    {
        Debug.Log("receive" + inputMessage.text);
        receiveMessage.text += "\n发送者" + info.sender + ":" + message;
    }
}
