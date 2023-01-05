using Unity.Entities;

public struct RandomNumberComponent : IComponentData
{
    public Unity.Mathematics.Random random;
}
