using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRotate2 : MonoBehaviour
{
    private bool rotateCW;
    [SerializeField] private float rotationSpeed, CWPoint, CCWPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rotateCharacter();
            if (rotateCW)
            {
                transform.Rotate(new Vector3(0, 0, -rotationSpeed) * Time.deltaTime);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
            }
        }


        

    }

    private void rotateCharacter()
    {

        Debug.Log(transform.localEulerAngles.z);

        if (transform.localEulerAngles.z >= 0 && transform.localEulerAngles.z <= 5)
        {
            rotateCW = true;
        }
        else if (transform.localEulerAngles.z > 5)
        {
            rotateCW = true;
        }
        else if (transform.localEulerAngles.z < -5)
        {
            rotateCW = false;
        }




    }

}
