using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 150.0f; // Speed of rotation
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component added to this game object
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input from keyboard for movement
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector that is in the direction the player is facing
        Vector3 movement = transform.forward * moveVertical;

        // Apply the movement vector to the Rigidbody as velocity, scaled by the speed
        rb.velocity = movement * speed;

        // Get horizontal mouse movement to rotate the player
        float rotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;

        // Calculate new rotation around the y-axis
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, rotation, 0));

        // Apply rotation to the Rigidbody
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
