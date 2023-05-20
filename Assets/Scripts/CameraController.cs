using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public transform farBackground, middleBackground;

    private float lastXPos;

    // Start is called before the first frame update
    void Start()
    {
        lastXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

        float amountToMoveX = transform.position.x = lastXPos;

        farBackground.position = farBackground.position + new Vector3(amountToMoveX, 0f, 0f);
        //middleBackground.position = transform.position;

        lastXPos = transform.position.x;
    }
}
