using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    class Baker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Unity.Entities.Entity entity = GetEntity(TransformUsageFlags.Dynamic | TransformUsageFlags.Renderable);

            AddComponent(entity, new LocalTransform
            {
                Position = authoring.transform.position,
                Rotation = authoring.transform.rotation,
                Scale = 1f
            });
            AddComponentObject(entity, authoring.GetComponent<MeshFilter>());
            AddComponentObject(entity, authoring.GetComponent<MeshRenderer>());

            AddComponent<PlayerTag>(entity);

            AddComponent(entity, new PlayerInput
            {
                MoveInput = float2.zero
            });

            AddComponent(entity, new Speed
            {
                Value = 5f
            });

        }

    }
}