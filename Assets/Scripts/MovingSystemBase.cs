using Unity.Entities;

public partial class MovingSystemBase : SystemBase
{
    override protected void OnUpdate()
    {
        RefRW<RandomNumberComponent> rnComponentInstance = SystemAPI.GetSingletonRW<RandomNumberComponent>();
        foreach (MoveToPositionAspect moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>())
        {
            moveToPositionAspect.Move(SystemAPI.Time.DeltaTime, rnComponentInstance);
        }
    }
}
