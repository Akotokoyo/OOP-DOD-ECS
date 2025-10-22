using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class EnemyAuthoring : MonoBehaviour
{
    public float speed;
    public float health;

    class Baker : Baker<EnemyAuthoring>
    { //Baker è una classe usata da Unity DOTS(Data Oriented Technology Stack) per convertire il monobehaviour in Entity + Componenti ECS
        public override void Bake(EnemyAuthoring authoring)
        {
            Unity.Entities.Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new LocalTransform
            {
                Position = authoring.transform.position,
                Rotation = authoring.transform.rotation,
                Scale = 1f
            });

            AddComponent(entity, new Speed { Value = authoring.speed });
            AddComponent(entity, new Health { Value = authoring.health });
            AddComponent<EnemyTag>(entity);
        }
    }
}