using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderController : MonoBehaviour
{
    [SerializeField] Rigidbody2D Lander;
    [SerializeField] float thrust = 20f;
    [SerializeField] float torque = 5f;
    [SerializeField] float speed;
    [SerializeField] float endspeed;
    [SerializeField] float rotation;
    [SerializeField] float endrotation;
    private bool inputactive = true;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inputactive)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Lander.AddRelativeForce(Vector2.up * thrust);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Lander.AddTorque(torque);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Lander.AddTorque(-torque);
            }
        }
        speed = Lander.velocity.magnitude;

        rotation = Lander.transform.eulerAngles.z;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        endspeed = speed;
        endrotation = rotation;
        if (collision.gameObject.tag == "LandPad" && speed <= 4 && (rotation<=45 || rotation>=315))
        {
            Debug.Log("victory");
            inputactive = false;
        }
        else
        {
            Debug.Log("lose");
            Lander.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
        
    }

}
