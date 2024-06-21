using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomListing : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private TMP_Text text;

    public void SetRoomInfo(RoomInfo roomInfo){
        text.text = roomInfo.Name;
    }

}
