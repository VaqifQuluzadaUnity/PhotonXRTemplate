using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonComponentHandler : MonoBehaviourPunCallbacks
{
    [SerializeField] private Behaviour[] commonComponents;

    private void Start()
    {
        if (!photonView.IsMine&& PhotonNetwork.IsConnected)
        {
            foreach(Behaviour comp in commonComponents)
            {
                comp.enabled = false;
            }
        }
    }
}
