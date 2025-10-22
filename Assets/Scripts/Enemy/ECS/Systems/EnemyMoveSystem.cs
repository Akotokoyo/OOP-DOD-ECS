using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

[BurstCompile]
public partial class EnemyMoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float3 playerPos = float3.zero;
        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var transform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<PlayerTag>())
        {
            playerPos = transform.ValueRO.Position;
            break;
        }


        foreach (var (transform, speed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Speed>>().WithAll<EnemyTag>())
        {
            float3 dir = math.normalize(playerPos - transform.ValueRW.Position);
            transform.ValueRW.Position += dir * speed.ValueRO.Value * deltaTime;
        }
    }
}