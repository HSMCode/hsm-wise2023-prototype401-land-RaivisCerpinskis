using UnityEngine;
using UnityEngine.SceneManagement;

public class IgelController : MonoBehaviour
{
    public float jumpForce = 10f;
    public int maxJumps = 2;
    private int remainingJumps;
    private bool isGrounded;

    private Rigidbody rb;
    public GameObject gameover;
    public int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        remainingJumps = maxJumps;
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        if (Input.GetButtonDown("Jump") && remainingJumps > 0 && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        remainingJumps--;

        if (remainingJumps == 0)
        {
            gameover.SetActive(true);
            Debug.Log("Hit");
        }
    }

    public void ResetJumps()
    {
        remainingJumps = maxJumps;
        enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            gameover.SetActive(true);
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}