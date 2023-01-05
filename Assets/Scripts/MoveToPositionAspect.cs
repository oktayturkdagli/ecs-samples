using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct  MoveToPositionAspect : IAspect
{
    private readonly Entity entity;
    private readonly TransformAspect transformAspect;
    private readonly RefRW<Speed> speed;
    private readonly RefRW<TargetPosition> targetPosition;

    public void Move(float deltaTime, RefRW<RandomNumberComponent> rnComponentInstance)
    {
        float3 direction = math.normalize(targetPosition.ValueRW.value - transformAspect.WorldPosition); // Calculate direction
        transformAspect.WorldPosition += direction * deltaTime * speed.ValueRW.value; // Move

        float reachedTargetDistance = 0.5f;
        if (math.distance(transformAspect.WorldPosition, targetPosition.ValueRW.value) < reachedTargetDistance)
        {
            // Generate new random position
            targetPosition.ValueRW.value = GetRandomPosition(rnComponentInstance); // Singleton class
        }
    }

    private float3 GetRandomPosition(RefRW<RandomNumberComponent> rnComponentInstance)
    {
        return new float3(rnComponentInstance.ValueRW.random.NextFloat(0f, 15f), 0,  rnComponentInstance.ValueRW.random.NextFloat(0f, 15f));
    }
}
