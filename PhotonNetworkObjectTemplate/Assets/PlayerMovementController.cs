using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float playerSpeed=5;

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        float forwardInput = Input.GetAxis("Vertical");

        transform.position += new Vector3(0, 0, forwardInput)*Time.deltaTime*playerSpeed;
    }
}
