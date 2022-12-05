using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField]
    private TrapTargetType trapType;

    private Trap trap;

    private void Awake()
    {
        trap = new Trap();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<IPlayer>();
        trap.HandleCharacterEntered(player, trapType);
    }
}

public class Trap
{
    public void HandleCharacterEntered(IPlayer player, TrapTargetType trapTargetType)
    {
        if (player.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Player)
                player.Health--;
        }
        else if (player.IsNPC)
        {
            if (trapTargetType == TrapTargetType.NPC)
                player.Health--;
        }
        else
        {
            if (trapTargetType == TrapTargetType.PowerUp)
                player.Health++;
        }
    }
}

public enum TrapTargetType { Player,NPC, PowerUp }