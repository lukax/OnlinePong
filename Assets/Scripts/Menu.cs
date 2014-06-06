using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public string IP = "127.0.0.1";
    public int Port = 25001;
    
    public string username = "";
    bool LoginUI = false;

    void OnGUI()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            if (GUI.Button(new Rect(100, 100, 100, 25), "Client"))
            {
                Network.Connect(IP, Port);
            }
            if (GUI.Button(new Rect(100, 125, 100, 25), "Server"))
            {
                Network.InitializeServer(10, Port, false);
            }
        }
        else
        {
            if (Network.peerType == NetworkPeerType.Client)
            {
                if (LoginUI == true)
                {
                    username = GUI.TextArea(new Rect(100, 125, 110, 25), username);

                    if (GUI.Button(new Rect(100, 150, 110, 25), "Login"))
                    {
                        networkView.RPC("Login", RPCMode.Server, username);
                    }
                }
                else
                {
                    if (GUI.Button(new Rect(100, 175, 110, 25), "Logout"))
                    {
                        Network.Disconnect(250);
                    }
                }

            }
            if (Network.peerType == NetworkPeerType.Server)
            {
                GUI.Label(new Rect(100, 100, 100, 25), "Server");
                GUI.Label(new Rect(100, 125, 100, 25), "Connections: " + Network.connections.Length);

                if (GUI.Button(new Rect(100, 150, 100, 25), "Logout"))
                {
                    Network.Disconnect(250);
                }
            }
        }
    }

}