using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_GustMovement : MonoBehaviour
{

    private float resetTimer = 0f;
    public float resetTime = 10f;
    private Vector3 startPos = Vector3.zero;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        ParticleSystem pSys = GetComponent<ParticleSystem>();

        resetTimer += Time.deltaTime;

        if (resetTimer > resetTime)
        {
            pSys.Stop();
            transform.position = startPos;
            resetTimer = 0f;
            pSys.Play();
        }

        rb.velocity = transform.forward * moveSpeed;



    }
}
