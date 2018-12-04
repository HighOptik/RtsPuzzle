using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody playerRB;
    public float Speed;
    public Vector3 forwardMovement;

	void Update () {
        forwardMovement = transform.forward;
        if (Input.GetAxis("Vertical") >= .5f)
        {
            playerRB.AddForce(forwardMovement * Speed * Time.deltaTime);
        }
	}
}
