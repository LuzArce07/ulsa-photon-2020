using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindRoomView : MonoBehaviour
{
    
    [SerializeField]
    ScrollRect sRectRoomList;
    [SerializeField]
    Button btnLeaveFindRoom;

    void Awake()
    {
        btnLeaveFindRoom.onClick.AddListener(Launcher.instance.LeaveFindRoomViewClick);
    }

}
