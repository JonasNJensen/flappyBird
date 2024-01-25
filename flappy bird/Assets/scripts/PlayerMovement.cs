using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip jumpSound;
    private AudioSource audioSource;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    

    void Update()
    {
        // Continuous horizontal movement
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
