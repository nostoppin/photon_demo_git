using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class hatScript : MonoBehaviour
{
    PhotonView ballView;
   
    void Start()
    {
        ballView = this.GetComponent<PhotonView>();
    }

}
