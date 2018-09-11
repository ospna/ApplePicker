using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // Get the Camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
	}

    // This method is called whenever another GameObject (The Apples) collides with the basket
    private void OnCollisionEnter(Collision collision)
    {
        // Find out what hit this basket
        GameObject collidedWith = collision.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }
    }
}
