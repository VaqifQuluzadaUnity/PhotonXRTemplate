using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ObjectInstantiateController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject collectiblePrefab;


    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for(int x = 0; x < 5; x++)
            {
                for(int z = 0; z < 5; z++)
                {
                    GameObject sceneObject=PhotonNetwork.InstantiateRoomObject(collectiblePrefab.name, new Vector3(x, 1, z), Quaternion.identity);
                }
            }
        }
    }

}
