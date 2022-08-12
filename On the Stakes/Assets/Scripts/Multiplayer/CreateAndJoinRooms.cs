using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    
    [SerializeField]
    private GameObject createInput;

    private string createServerText;

    void Start(){
        createServerText = createInput.GetComponent<TMP_InputField>().text;
    }

    public void CreateRoom(){
        PhotonNetwork.CreateRoom(createServerText);
    }

    public void JoinRoom(){

    }

    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("MainGame");
    }

}
