using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class UI_Manager : MonoBehaviourPunCallbacks
{
    public GameObject menuPanel;
    public GameObject connectServerPanel;
    public GameObject connectToServerObject;
    public GameObject yesObject;

    public InputField roomNameInputField;

    public Text messageBox;
    public Text messageConnectBox;

    private void Start()
    {
        menuPanel.SetActive(false);
        connectServerPanel.SetActive(true);
    }

    public void onJoinRoom()
    {
        //if room exists || search for room 
        {
            PhotonNetwork.JoinRoom(roomNameInputField.text);
            messageBox.text = "Joining room with name: " + roomNameInputField.text;
        }
        //else
        {
            //messageBox.text = "Room does not exist";
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public void onCreateRoom()
    {
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        //messageBox.text = "Created room with name: " + roomNameInputField.text;
    }

    public void onYandConnectToServer()
    {
        messageConnectBox.text = "Connecting to Server...";
        yesObject.SetActive(false);

        Invoke("connectNow", 2f);
    }

    void connectNow()
    {
        connectServerPanel.SetActive(false);
        menuPanel.SetActive(true);
        connectToServerObject.GetComponent<ConnectToServer>().connectToServer();
        //print("Connection established");
    }
}
