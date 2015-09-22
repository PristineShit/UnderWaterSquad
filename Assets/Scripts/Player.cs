using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Vector3 forward;
    //public float maxSpeed = 20f;
    public float acceleration = 100f;

    public float maxVelocity = 15f;

    KeyCode Foward = KeyCode.W;
    KeyCode Backward = KeyCode.S;
    KeyCode Right = KeyCode.D;
    KeyCode Left = KeyCode.A;

    Rigidbody m_rigidbody;

    public Transform forwardTarget;
	// Use this for initialization
	void Start ()
    {
        m_rigidbody = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        KeyMovement();

        VecCheck();
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

    void JumpMovement()
    {


    }

    void KeyMovement()
    {
        if (Input.GetKey(Foward))
        { 
            m_rigidbody.AddForce(CalcForwardVector() * acceleration);
        }
        if (Input.GetKey(Backward))
        {
            m_rigidbody.AddForce(CalcForwardVector() * -acceleration);
        }
        if (Input.GetKey(Right))
        {
            m_rigidbody.AddForce(CalcLeftVector() * -acceleration);
        }
        if (Input.GetKey(Left))
        {
            m_rigidbody.AddForce(CalcLeftVector() * acceleration);
        }

                
    }

    Vector3 CalcForwardVector()
    {
        Vector3 _vector = (forwardTarget.position - this.transform.position);
        _vector.y = 0;
        return _vector.normalized;
    }

    Vector3 CalcLeftVector()
    {

        Vector3 a = Vector3.up;
               
        Vector3 b = (this.transform.position - forwardTarget.position).normalized;
        b.y = 0;
               
        return Vector3.Cross(a,b).normalized;
    }

    void VecCheck()
    {
        Vector3 vel = m_rigidbody.velocity;
        if (vel.x > maxVelocity)
        {
            vel.x = maxVelocity;
        }
        if (vel.z > maxVelocity)
        {
            vel.z = maxVelocity;
        }
        if (vel.x < -maxVelocity)
        {
            vel.x = -maxVelocity;
        }
        if (vel.z < -maxVelocity)
        {
            vel.z = -maxVelocity;
        }
        m_rigidbody.velocity = vel;
        Debug.Log(m_rigidbody.velocity);
    }
}
