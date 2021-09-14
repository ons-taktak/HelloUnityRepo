using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody body;
    MeshRenderer meshRenderer;

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randDir = Random.onUnitSphere;
        body.AddForce(new Vector3(randDir.x, 0, randDir.z) * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacleee"))
        {
            ObstacleData data = collision.gameObject.GetComponent<ObstacleData>();
            if (data != null)
            {
                meshRenderer.material.color = data.color;
            }
            Debug.Log("Collision start: " + collision.gameObject.name);
        }
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("Collision stay: " + collision.gameObject.name);
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("Collision exit: " + collision.gameObject.name);
    //}
}
