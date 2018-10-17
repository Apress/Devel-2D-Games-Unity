using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    public SpawnPoint playerSpawnPoint;

    public static RPGGameManager sharedInstance = null;
    public RPGCameraManager cameraManager;

    void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            // We only ever want one instance to exist, so destroy the other existing object
            Destroy(gameObject);
        }
        else
        {
            // If this is the only instance, then assign the sharedInstance variable to the current object.
            sharedInstance = this;
        }
    }

    void Start()
    {
        SetupScene();
    }

    public void SetupScene()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }
    
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}