using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    
    [SerializeField]
    GameObject loading;
    [SerializeField]
    GameObject menuView;


    void Start()
    {
        loading.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connection starting");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinLobby(); 
    }

    public override void OnJoinedLobby()
    {
        loading.SetActive(false);
        menuView.SetActive(true);
        Debug.Log("Joined to lobby");
    }

}
