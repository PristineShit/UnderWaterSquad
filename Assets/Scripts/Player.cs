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

    public Transform cam;
	// Use this for initialization
	void Start ()
    {
        m_rigidbody = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        JoystickMovement();
        KeyMovement();
	}

    public void SetForwardVel(Vector3 _forward)
    {
        forward = _forward;
    }

    void JoystickMovement()
    {
        if(Input.GetButtonDown("A_1"))
        {
            m_rigidbody.AddForce(CalcForwardVector() * acceleration);
        }
        if (Input.GetAxis("L_YAxis_1") < 0)
        {
            m_rigidbody.AddForce(CalcForwardVector() * -acceleration);
        }
    }

    void KeyMovement()
    {
        if (Input.GetKeyDown(Foward))
        { 
            m_rigidbody.AddForce(CalcForwardVector() * acceleration);
        }
        if (Input.GetKeyDown(Backward))
        {
            m_rigidbody.AddForce(CalcForwardVector() * -acceleration);
        }
        if (Input.GetKeyDown(Right))
        {
            m_rigidbody.AddForce(CalcLeftVector() * -acceleration);
        }
        if (Input.GetKeyDown(Left))
        {
            m_rigidbody.AddForce(CalcLeftVector() * acceleration);
        }
    }

    Vector3 CalcForwardVector()
    {
        Vector3 _vector = (this.transform.position - cam.position);
        _vector.y = 0;
        return _vector.normalized;
    }

    Vector3 CalcLeftVector()
    {

        Vector3 a = Vector3.up;
               
        Vector3 b = (cam.position - this.transform.position).normalized;
        b.y = 0;
               
        return Vector3.Cross(a,b);
    }
}
