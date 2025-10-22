using Unity.Burst;
using Unity.Entities;

[BurstCompile]
public partial class EnemyDeathSystem : SystemBase
{
    protected override void OnUpdate()
    {
        foreach (var (health, entity) in
            SystemAPI.Query<RefRO<Health>>().WithAll<EnemyTag>().WithEntityAccess())
        {
            if (health.ValueRO.Value <= 0f)
            {
                EntityManager.DestroyEntity(entity);
            }
        }
    }
}
