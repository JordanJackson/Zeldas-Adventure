using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    Vector2 inputs;

    Animator animator;
    public Transform body;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        switch (GameManager.Instance.currentState)
        {
            case GameManager.GameState.PLAYING:
                RecalculateAttributes();
                GetInput();
                ProcessMovement();
                break;
            default:
                break;
        }

    }

    void RecalculateAttributes()
    {
        IntData[] intDatas = this.GetComponents<IntData>();
        for (int i = 0; i < intDatas.Length; i++)
        {
            switch (intDatas[i].Name)
            {
                default:
                    break;
            }
        }

        FloatData[] floatDatas = this.GetComponents<FloatData>();
        for (int i = 0; i < floatDatas.Length; i++)
        {
            switch (floatDatas[i].Name)
            {
                case "Speed":
                    speed = floatDatas[i].Data();
                    break;
                case "Size":
                    this.transform.localScale = new Vector3(floatDatas[i].Data(), floatDatas[i].Data(), floatDatas[i].Data());
                    break;
                default:
                    break;
            }
        }
    }

    void GetInput()
    {
        inputs = new Vector2(Input.GetAxisRaw("HorizontalLeft"), Input.GetAxisRaw("VerticalLeft"));

        if (Input.GetButtonDown("RB"))
        {
            animator.SetTrigger("slash");
        }
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
