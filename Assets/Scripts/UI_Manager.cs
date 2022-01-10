using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class UI_Manager : MonoBehaviourPunCallbacks
{
    public GameObject menuPanel;
    public GameObject connectServerPanel;
    public GameObject connectToServerObject;
    public GameObject SelectionPanel;
    public GameObject yesObject;

    public InputField roomNameInputField;
    public InputField usernameInputField;

    public Text messageBox;
    public Text messageConnectBox;
    public Text roomNameMessagebox;

    public Button startGameButton;


    private void Start()
    {
        startGameButton.interactable = false;
        SelectionPanel.SetActive(false);
        menuPanel.SetActive(false);
        connectServerPanel.SetActive(true);
    }

    private void Update()
    {
        userNameLengthCheck();
    }

    public void onJoinRoom()
    {
        if (roomNameInputField.text == "")
        {
            messageBox.text = "Room name cannot be blank.";
        }
        else
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 5;
            PhotonNetwork.JoinOrCreateRoom(roomNameInputField.text, roomOptions, TypedLobby.Default);
            //PhotonNetwork.JoinRoom(roomNameInputField.text);
            messageBox.text = "Joining room with name: " + roomNameInputField.text;
        }
    }

    public override void OnJoinedRoom()
    {
        //PhotonNetwork.LoadLevel(1);
        menuPanel.SetActive(false);
        SelectionPanel.SetActive(true);
        roomNameMessagebox.text = "Connection to room: " + roomNameInputField.text;
    }

    public void onCreateRoom()
    {
        //print(roomNameInputField.text);
        if (roomNameInputField.text == "")
        {
            messageBox.text = "Room name cannot be blank.";
        }
        else
        {
            PhotonNetwork.CreateRoom(roomNameInputField.text, new RoomOptions() { MaxPlayers = 5 }, null );
            messageBox.text = "Joining room with name: " + roomNameInputField.text;
        }
    }

    public override void OnCreatedRoom()
    {
        roomNameMessagebox.text = "Connection to room: " + roomNameInputField.text;
        menuPanel.SetActive(false);
        SelectionPanel.SetActive(true);
    }
    //<-------------------------------Username Screen--------------------------->

    public void userNameLengthCheck()
    {
        if(usernameInputField.text != "")
        {
            startGameButton.interactable = true;
        }
        else
        {
            startGameButton.interactable = false;
        }
    }

    public void setPlayerUsername()
    {
        PhotonNetwork.NickName = usernameInputField.text; 
    }

    public void onStartGame()
    {
        SelectionPanel.SetActive(false);
        PhotonNetwork.LoadLevel(1);
    }


    //<-------------------------------t=0 Start screen------------------------------>
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
