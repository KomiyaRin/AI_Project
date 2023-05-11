using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 2f;
    private float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    private bool isGrounded;
    public GameObject pausePanel;
    public GameObject deadPanel;

    private void Update()
    {
        controller = GetComponent<CharacterController>();
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            controller.slopeLimit = 45.0f;
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (move.magnitude > 1)
        {
            move /= move.magnitude;
        }
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            controller.slopeLimit = 100.0f;
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            controller.Move(move * speed * 2 * Time.deltaTime);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        /*pauseOnClick();*/
    }

    /*public void pauseOnClick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            pausePanel.SetActive(true);
        }
        *//*        else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 1f;
                    pausePanel.SetActive(false);
                }*//* 
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0f;
            deadPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}