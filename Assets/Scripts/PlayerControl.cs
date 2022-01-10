using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerControl : MonoBehaviourPunCallbacks
{
    private float playerMoveSpeed = 0f;

    bool hatCollected = false;
    bool otherPlayerTriggered = false;

    public CharacterController playerController;

    private Vector3 moveDirection = Vector3.zero;
    Vector3 otherPlayerPosition;

    public GameObject playerHat;

    PhotonView playerView;
    Collider colliderInfo;

    private void Start()
    {
        playerView = this.GetComponent<PhotonView>();
        playerMoveSpeed = 2f;
    }

    void Update()
    {
        if(playerView.IsMine)
        {
            movePlayer();
        }
        Vector3 currentPlayerPosition = this.transform.position;
        if (hatCollected == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (otherPlayerTriggered && hatCollected)
        {
            
            playerHat.gameObject.transform.position = new Vector3(otherPlayerPosition.x,
                                                                  otherPlayerPosition.y + 1f,
                                                                  otherPlayerPosition.z);
            hatCollected = false;
        }
    }
    private void movePlayer()
    {
        moveDirection = Vector3.zero;

        moveDirection += this.transform.forward * Input.GetAxis("Vertical") * playerMoveSpeed;
        moveDirection += this.transform.right * Input.GetAxis("Horizontal") * playerMoveSpeed;

        playerController.SimpleMove(moveDirection);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.gameObject.name == "Hat")
        {
            print("hat collected");
            hatCollected = true;
            collider.transform.gameObject.SetActive(false);
        }

        /*if(collider.transform.gameObject.tag == "Player")
        {
            if(!playerView.IsMine)
            {
                otherPlayerTriggered = true;
                otherPlayerPosition = new Vector3(collider.transform.position.x,
                                                  collider.transform.position.y,
                                                  collider.transform.position.z);
                print("hat trigger point");
            }
        }*/
    }

    //private void 
}
