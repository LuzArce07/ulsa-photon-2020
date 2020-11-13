using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomView : MonoBehaviour
{
    
    [SerializeField]
    TMP_Text txtRoomName;
    [SerializeField]
    Button btnLeaveRoom;
    [SerializeField]
    RectTransform playerListContainer;
    [SerializeField]
    Object srcPlayerNickNameItem;

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

    void ClearPlayerListContainer()
    {
        foreach(GameObject go in playerListContainer)
        {
            Destroy(go);
        }
    }

    public void AddPlayerToListContainer(Player player)
    {
        GameObject go = (GameObject) Instantiate(srcPlayerNickNameItem, playerListContainer);
        TMP_Text playerNickNameItem = go.GetComponent<TMP_Text>();
        playerNickNameItem.text = player.NickName;
    }

    public void RemovePlayerInListContainer(Player player)
    {
        foreach(GameObject go in playerListContainer)
        {

            TMP_Text playerNickNameItem = go.GetComponent<TMP_Text>();
            
            if(playerNickNameItem.text == player.NickName)
            {
                Destroy(go);
                break;
            }
        
        }
    }

    public void FillPlayerListContainer(Player[] playerList)
    {

        ClearPlayerListContainer();

        foreach(Player p in playerList)
        {
            GameObject go = (GameObject) Instantiate(srcPlayerNickNameItem, playerListContainer);
            TMP_Text playerNickNameItem = go.GetComponent<TMP_Text>();
            playerNickNameItem.text = p.NickName;
        }


    }


}
