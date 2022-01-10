using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public void connectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Invoke("OnConnectedToMaster", 1);
        Invoke("OnJoinedLobby", 2);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        //print("lobby join initiated");
    }

    public override void OnJoinedLobby()
    {
        //print("lobby joined");
        //SceneManager.LoadScene(1); //Game_Scene
    }
}
