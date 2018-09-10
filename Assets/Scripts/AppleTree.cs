using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Set in Inspector")]

    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which Apples will be instantiatied
    public float secondsBetweenAppleDrops = 1f;

    // Use this for initialization
    // Dropping apples every second
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);       // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);       // Move left
        }
    }

    // Update is called 50 times per second
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            // Randomly Changing Directions is now time-based
            speed *= -1;        // Change direction
        }
    }
}
