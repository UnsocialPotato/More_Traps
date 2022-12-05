using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private CharacterController characterController;

    [SerializeField]
    private bool isPlayer;

    [SerializeField]
    private bool isNPC;

    public bool IsPlayer => isPlayer;
    public bool IsNPC => IsNPC;

    public int Health { get; set; }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        characterController.Move(new Vector3(horizontal, 0, vertical));
    }
}