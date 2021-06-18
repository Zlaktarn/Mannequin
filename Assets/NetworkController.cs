using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("We are connetect " + PhotonNetwork.CloudRegion + " Server");
    }

    void Update()
    {
        
    }

}
