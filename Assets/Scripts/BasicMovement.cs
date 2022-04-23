using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float Speed = 10.0f;
    public Rigidbody Rb;
    public Vector3 Movement;


    // Use this for initialization
    void Start()
    {
        Rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Quaternion rotTarget = Quaternion.LookRotation(Movement);
        transform.localRotation = rotTarget;
    }


    void FixedUpdate()
    {
        moveCharacter(Movement.normalized);
    }


    void moveCharacter(Vector3 direction)
    {
        Vector3 velocity = direction * Speed;
        if(Rb.velocity.magnitude <= 0.8f*velocity.magnitude)
        {

            Rb.velocity += velocity;
        }
        
    }

}
