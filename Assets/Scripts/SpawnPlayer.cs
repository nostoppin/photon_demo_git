using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public float posMinX = 0;
    public float posMaxX = 0;

    public float posMinZ = 0;
    public float posMaxZ = 0;
    
    private float posFixedY = 0;

    public GameObject playerPrefab;

    private void Start()
    {
        posMinX = -22f;
        posMaxX = -8f;

        posMinZ = -29f;
        posMaxZ = -16f;
        posFixedY = 1.7f;
        Vector3 randomPlayerPosition = new Vector3(Random.Range(posMinX, posMaxX),
                                                            posFixedY,
                                                   Random.Range(posMinZ, posMaxZ));

        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-9.83f,3.42f,-16.2f), Quaternion.identity);
        //-9.83,3,42,-16.2
    }
}
