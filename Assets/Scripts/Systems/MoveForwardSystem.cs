using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class MoveForwardSystem : SystemBase
{
    
    
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.
            WithAny<AsteroidTag, ChaserTag>().
            ForEach((ref Translation pos, in MoveData moveData, in Rotation rot) =>
        {
            float3 forwardDirection = math.forward(rot.Value);
            pos.Value += forwardDirection * moveData.speed * deltaTime;
        }).ScheduleParallel();
        
     
    }
}