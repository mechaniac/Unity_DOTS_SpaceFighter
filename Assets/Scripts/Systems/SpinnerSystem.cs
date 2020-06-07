using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class SpinnerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.
            WithAll<SpinnerTag>().
            ForEach((ref Rotation rot, in MoveData moveData) =>
        {
            quaternion normalizedRot = math.normalize(rot.Value);
            quaternion angleToRotate = quaternion.AxisAngle(math.up(), moveData.turnSpeed * deltaTime);

            rot.Value = math.mul(normalizedRot, angleToRotate);
        }).ScheduleParallel();
    }
}
