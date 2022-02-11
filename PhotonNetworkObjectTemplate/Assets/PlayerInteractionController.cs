using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviourPunCallbacks
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform collectibleParent;
    private PhotonView hitObjectPhotonView;
    private GameObject hitObject;
    private void Update()
    {
        Ray mousePosRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitObj = new RaycastHit();
        if (Physics.Raycast(mousePosRay,out hitObj, 100, LayerMask.GetMask("Collectible")))
        {
            Debug.Log("collectible detected");
            if (Input.GetMouseButtonDown(0))
            {
                if (photonView.IsMine)
                {
                    //if we are local player, we need to set local gameObject as hit object but(see line 36)
                    hitObject = hitObj.transform.gameObject;
                    hitObjectPhotonView = hitObj.transform.GetComponent<PhotonView>();
                    hitObjectPhotonView.TransferOwnership(photonView.ViewID);
                    photonView.RPC("EquipCollectible", RpcTarget.All, hitObjectPhotonView.ViewID);
                }
            }
        }
    }

    [PunRPC]
    private void EquipCollectible(int hitObjectViewId)
    {
        //If we have client gameObject we need to set it with its photon id.(this id is the id of interactable gameObject)
        if (!photonView.IsMine)
        {
            hitObject = PhotonView.Find(hitObjectViewId).gameObject;
        }
        
        hitObject.transform.parent = collectibleParent;

        hitObject.transform.position = collectibleParent.position;
    }
}
