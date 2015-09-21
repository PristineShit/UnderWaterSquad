using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Vector3 forward;
    float maxSpeed = 20f;
    float acceleration = 100f;

    KeyCode Foward = KeyCode.W;
    KeyCode Backward = KeyCode.S;
    KeyCode Right = KeyCode.D;
    KeyCode Left = KeyCode.A;

    Rigidbody m_rigidbody;
	// Use this for initialization
	void Start ()
    {
        m_rigidbody = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
	}

    public void SetForwardVel(Vector3 _forward)
    {
        forward = _forward;
    }

    void Movement()
    {
        if (Input.GetKeyDown(Foward))
        { 
            m_rigidbody.AddForce(new Vector3(1, 0, 0) * acceleration);
        }
        if (Input.GetKeyDown(Backward))
        {
            m_rigidbody.AddForce(new Vector3(-1, 0, 0) * acceleration);
        }
        if (Input.GetKeyDown(Right))
        {
            m_rigidbody.AddForce(new Vector3(0, 0, 1) * acceleration);
        }
        if (Input.GetKeyDown(Left))
        {
            m_rigidbody.AddForce(new Vector3(0, 0, -1) * acceleration);
        }
    }
}
