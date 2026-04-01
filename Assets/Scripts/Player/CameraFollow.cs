using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target == null)
        {
            Debug.LogError("Camera has no target!");
            return;
        }
        
        transform.position = new Vector3(
            target.position.x,
            target.position.y,
            -10f
        );
        
        Debug.Log("Camera pos: " + transform.position + " | Target pos: " + target.position);
    }
}