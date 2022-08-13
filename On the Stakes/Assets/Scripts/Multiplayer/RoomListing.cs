using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using TMPro;

public class RoomListing : MonoBehaviour
{

    [SerializeField]
    private TMP_Text text;

    public void SetRoomInfo(RoomInfo roomInfo){
        text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }

}
