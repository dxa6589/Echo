using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 activePlayerPos;
    private float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cameraSpeed = 1.0f;
        activePlayerPos = GameManager.instance.GetActivePlayer().transform.position;
    }
    void CameraTrackPlayer()
    {
        activePlayerPos = GameManager.instance.GetActivePlayer().transform.position;

        transform.position = Vector3.Lerp(transform.position, new Vector3(activePlayerPos.x, activePlayerPos.y,-10), Time.deltaTime*cameraSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        CameraTrackPlayer();
    }
}
