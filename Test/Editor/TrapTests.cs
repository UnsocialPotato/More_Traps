using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

public class TrapTests
{
    [Test]
    public void PlayerEntering_PlayerTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        IPlayer player = Substitute.For<IPlayer>();
        player.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(player, TrapTargetType.Player);

        Assert.AreEqual(-1, player.Health);
    }

    [Test]
    public void NPCEntering_NPCTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        IPlayer player = Substitute.For<IPlayer>();
        trap.HandleCharacterEntered(player, TrapTargetType.NPC);
        Assert.AreEqual(-1, player.Health);
    }

    [Test]
    public void PlayerEntering_PlayerTargetedTrap_GainsHealthByOne()
    {
        Trap trap = new Trap();
        IPlayer player = Substitute.For<IPlayer>();
        player.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(player, TrapTargetType.PowerUp);

        Assert.AreEqual(+1, player.Health);
    }

    [Test]
    public void NPCEntering_NPCTargetedTrap_GainsHealthByOne()
    {
        Trap trap = new Trap();
        IPlayer player = Substitute.For<IPlayer>();
        trap.HandleCharacterEntered(player, TrapTargetType.NPC);
        Assert.AreEqual(+1, player.Health);
    }
}
