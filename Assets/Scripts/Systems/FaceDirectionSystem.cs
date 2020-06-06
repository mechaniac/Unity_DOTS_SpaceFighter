using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class FaceDirectionSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotation rot, in Translation pos, in MoveData moveData) =>
        {
            if (!moveData.direction.Equals(float3.zero))
            {
                quaternion targetRotation = quaternion.LookRotationSafe(moveData.direction, math.up());     //calculates rotation from 0.0 to first param, 2nd defaults to world up
                rot.Value = math.slerp(rot.Value, targetRotation, moveData.turnSpeed);  //turnSpeed is 0 to 1 scale of lerping
            }
        }).Schedule();

    }
}
