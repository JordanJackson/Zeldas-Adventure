using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 2.0f;

    Vector2 inputs;

    Animator animator;
    public Transform body;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        GetInput();
        ProcessMovement();
    }

    void GetInput()
    {
        inputs = new Vector2(Input.GetAxisRaw("HorizontalLeft"), Input.GetAxisRaw("VerticalLeft"));
    }

    void ProcessMovement()
    {
        Vector3 movement = Vector3.Normalize((Vector3.right * inputs.x) + (Vector3.forward * -inputs.y));

        this.transform.Translate(movement * speed * Time.deltaTime, Space.World);
        this.transform.LookAt(this.transform.position + (movement * speed));

        animator.SetFloat("moveSpeed", movement.magnitude * speed);
        body.localPosition = Vector3.zero;
        body.localRotation = Quaternion.identity;
    }

	public void Jump()
    {
        Debug.Log("Jump Message Received!");
    }
}
