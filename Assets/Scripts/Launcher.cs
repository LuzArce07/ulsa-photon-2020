using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{

    public static Launcher instance;

    [SerializeField]
    GameObject loading;
    [SerializeField]
    GameObject menuView;
    [SerializeField]
    GameObject createRoomView;
     [SerializeField]
    GameObject roomView;


    void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public void CreateRoom()
    {
        menuView.SetActive(false);
        createRoomView.SetActive(true);
    }

    public void CreateNewRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
        createRoomView.SetActive(false);
        loading.SetActive(true);
    }

    public void CancelCreateNewRoom()
    {
        createRoomView.SetActive(false);
        menuView.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        loading.SetActive(false);
        roomView.SetActive(true);
        Debug.Log($"Joined to: {PhotonNetwork.CurrentRoom.Name}");
    }

    public void LeaveCurrentRoom()
    {
        PhotonNetwork.LeaveRoom();
        roomView.SetActive(false);
        loading.SetActive(true);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Exited from room");
    }

    public string CurrentRoomName => PhotonNetwork.CurrentRoom.Name;

}
