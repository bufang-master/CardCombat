using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_09_03 : MonoBehaviour {

    public Text text;

    int port = 10000;
    string message = "";

    private void Start()
    {
        text.text = "";
    }

    private void OnGUI()
    {
        switch (Network.peerType)
        {
            case NetworkPeerType.Disconnected:
                StartServer();
                break;
            case NetworkPeerType.Server:
                OnServer();
                break;
            case NetworkPeerType.Connecting:
                break;
        }
    }

    private void OnServer()
    {
        GUILayout.Label("服务器创建完毕，等待客户端连接");
        int length = Network.connections.Length;
        for (int i = 0; i < length; i++)
        {
            GUILayout.Label("连接服务器客户端ID" + i);
            GUILayout.Label("连接服务器客户端IP" + Network.connections[i].ipAddress);
            GUILayout.Label("连接服务器客户端端口号" + Network.connections[i].port);
        }
        if (GUILayout.Button("断开服务器"))
        {
            Network.Disconnect();
            text.text = "";
        }
    }

    private void StartServer()
    {
        if (GUILayout.Button("创建本机服务器"))
        {
            NetworkConnectionError error = Network.InitializeServer(10, port, false);
            Debug.Log("连接状态：" + error);
            GUILayout.Label("连接状态：" + error);
        }
    }

    [RPC]
    void RequestMessage(string message,NetworkMessageInfo info)
    {
        text.text += "\n发送者" + info.sender + ":" + message;
    }
}
