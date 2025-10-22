using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.Default)]
public partial class PlayerInputSystem : SystemBase
{

    protected override void OnUpdate()
    {
        float2 move = float2.zero;

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        foreach(var input in SystemAPI.Query<RefRW<PlayerInput>>().WithAll<PlayerTag>())
        {
            input.ValueRW.MoveInput = move;
        }
    }
}