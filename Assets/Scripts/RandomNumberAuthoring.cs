using Unity.Entities;
using UnityEngine;

public class RandomNumberAuthoring : MonoBehaviour
{
    
}

public class RandomBaker : Baker<RandomNumberAuthoring>
{
    public override void Bake(RandomNumberAuthoring authoring)
    {
        AddComponent(new RandomNumberComponent { random = new Unity.Mathematics.Random(1) } );
    }
}