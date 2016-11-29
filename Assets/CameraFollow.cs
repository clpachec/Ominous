using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public float dampTime = 0.15f;
    public Transform target;
    public float yMinLimit = -8.82394f;
    public float xMinLimit = -1.805895f;
    public float xMaxLimit = 1.895617f;
    Vector3 velocity = Vector3.zero;

    
    Camera myCamera;
    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target && yMinLimit < target.position.y && xMinLimit < target.position.x && xMaxLimit > target.position.x)
        {
            Vector3 point = myCamera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - myCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}