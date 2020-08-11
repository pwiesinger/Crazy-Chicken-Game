using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeScript : MonoBehaviour
{
    public float slowSpeed;
    public float fastSpeed;
    public float turnSpeed = 2.0f;
    public bool turboMode = false;
    public GameObject master;
    public int turboSeconds;

    int coinsFound = 0;
    Rigidbody rigidbody;
    Animator animator;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -50)
        {
            Dead();
        }

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (v == 0)
        {
            if (turboMode) 
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Run", false);
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Walk", false);
            }
        }
        else
        {
            if (turboMode)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Walk", true);
            }
        }


        if (turboMode)
        {
            if (audioSource.isPlaying == false) audioSource.Play();
        }
        else 
        {
            if (audioSource.isPlaying) audioSource.Stop();
        }

        float speed = turboMode ? fastSpeed : slowSpeed;
        rigidbody.MovePosition(transform.position + transform.forward.normalized * v * Time.deltaTime * speed);

        if (h != 0)
        {
            transform.Rotate(new Vector3(0, h * turnSpeed));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Console.WriteLine("collision detected");
        var collider = collision.gameObject.name;

        if (collider != null)
        {
            if (collider.Contains("german"))
            {
                if (turboMode) 
                {
                    collision.gameObject.SetActive(false);   
                }
                else
                {
                    gameObject.SetActive(false);
                    Dead();
                }
            }
            else if (collider.Contains("coin"))
            {
                collision.gameObject.SetActive(false);
                coinsFound++;
                UpdateCoinTextfield();
            }
            else if (collider.Contains("grenade"))
            {
                collision.gameObject.SetActive(false);
                turboMode = true;
                StartCoroutine(ResetTurboMode());
            }
        }
    }

    IEnumerator ResetTurboMode()
    {
        yield return new WaitForSeconds(turboSeconds);
        turboMode = false;
    }

    public void Dead()
    {
        master.GetComponent<MasterScript>().Dead();
    }

    public void UpdateCoinTextfield()
    {
        master.GetComponent<MasterScript>().SetCoinCount(coinsFound);
    }
}
