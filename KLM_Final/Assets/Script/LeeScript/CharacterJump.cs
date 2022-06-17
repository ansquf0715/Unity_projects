using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterJump : MonoBehaviour
{
    private Rigidbody rigid;
    private bool isJumping = false;
    public float JumpPower = 5f;
    Animator animator;

    public AudioClip audioJump;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        audioSource = gameObject.GetComponentInParent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        UpdateAnimatior();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                audioSource.clip = audioJump;
                audioSource.Play();

                isJumping = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
            else
            {
                return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("EnemyTag"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdateAnimatior()
    {
        animator.SetBool("isJump", isJumping);
    }
}
