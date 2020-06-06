using Unity.Entities;
using System;
using UnityEngine;

public class PlayerInputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref MoveData moveData, in InputData inputData) => //in: NOT written to, has to be last
        {
            bool isRightKeyPressed = Input.GetKey(inputData.rightKey);  //true if pressed in frame
            bool isLeftKeyPressed = Input.GetKey(inputData.leftKey);
            bool isUpKeyPressed = Input.GetKey(inputData.upKey);
            bool isDownKeyPressed = Input.GetKey(inputData.downKey);

            //moveData.direction.x = Convert.ToInt32(isRightKeyPressed);  //makes 1 and 0 from booleans
            //moveData.direction.x -= Convert.ToInt32(isLeftKeyPressed);  //NEGATIVE
            //moveData.direction.z = Convert.ToInt32(isUpKeyPressed);
            //moveData.direction.z -= Convert.ToInt32(isDownKeyPressed);


            moveData.direction.x = (isRightKeyPressed) ? 1 : 0;
            moveData.direction.x -= (isLeftKeyPressed) ? 1 : 0;
            moveData.direction.z = (isUpKeyPressed) ? 1 : 0;
            moveData.direction.z -= (isDownKeyPressed) ? 1 : 0;

        }).Run();   //because of Input. has to run on main thread 



    }
}
