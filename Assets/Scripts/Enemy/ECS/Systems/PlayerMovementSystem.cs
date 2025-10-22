using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial class PlayerMoveSystem : SystemBase {
    protected override void OnUpdate()
    {
        Debug.Log("HERE");
        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach(var (transform, speed, input) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<Speed>, RefRW<PlayerInput>>().WithAll<PlayerTag>())
        {
            Debug.Log("HERE 1");
            float2 move = input.ValueRW.MoveInput;

            float3 dir = new float3(move.x, 0, move.y);

            if (!dir.Equals(float3.zero)) {
                Debug.Log("HERE 2");
                dir = math.normalize(dir);
            }

            transform.ValueRW.Position += dir * speed.ValueRW.Value * deltaTime;
            Debug.Log("transform.ValueRW.Position " + transform.ValueRW.Position);
        }
    }
}