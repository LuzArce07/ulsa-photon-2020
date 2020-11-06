using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoomView : MonoBehaviour
{
    [SerializeField]
    TMP_Text txtRoomName;
    [SerializeField]
    Button btnLeaveRoom;

    void Awake()
    {
        btnLeaveRoom.onClick.AddListener(LeaveCurrentRoom);
        
    }

    public void SetRoomName(string roomName) => txtRoomName.text = roomName;

    void OnEnable()
    {
        SetRoomName(Launcher.instance.CurrentRoomName);
    } 

    void LeaveCurrentRoom()
    {
        SetRoomName(string.Empty);
        Launcher.instance.LeaveCurrentRoom();
    }

}
