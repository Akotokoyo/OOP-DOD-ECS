using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

[BurstCompile]
public partial class DamageSystem : SystemBase
{

    protected override void OnUpdate()
    {
        float damage = 1f;
        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var health in SystemAPI.Query<RefRW<Health>>().WithAll<EnemyTag>())
        {
            health.ValueRW.Value -= (damage * deltaTime);
        }
    }
}