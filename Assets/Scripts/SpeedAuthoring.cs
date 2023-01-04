using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpeedAuthoring : MonoBehaviour
{
    public float value;
}

// Connect IComponentData and MonoBehaviour
public class SpeedBaker : Baker<SpeedAuthoring>
{
    public override void Bake(SpeedAuthoring authoring)
    {
        AddComponent
        (
            new Speed { value = authoring.value }
        );
    }
}