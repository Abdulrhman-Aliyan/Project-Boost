using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Movement : MonoBehaviour
{
    Rigidbody playerRB;
    Transform playerTrans;
    
    [SerializeField] float thrust = 1000f;
    [SerializeField] float playerRotaion = 500f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            playerRB.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotatePlayer(1);
        }

        if (Input.GetKey(KeyCode.D)) {
            RotatePlayer(-1);
        }
    }

    private void RotatePlayer(int getDirection)
    {
        playerRB.freezeRotation = true; // freeze rotation so we can manually rotate
        playerTrans.Rotate(getDirection * Vector3.forward * playerRotaion * Time.deltaTime);
        playerRB.freezeRotation = false; // unfreezing rotation so the physiccs can take over
    }
}
