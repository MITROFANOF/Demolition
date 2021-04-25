using Pong.Scripts.Data;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Pong.Scripts.Systems
{
    [AlwaysSynchronizeSystem]
    public class PlayerInputSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            Entities.ForEach((ref RocketMovementData movementData, in RocketInputData inputData) =>
            {
                movementData.Direction = 0;
                movementData.Direction += Input.GetKey(inputData.UpKey) ? 1 : 0;
                movementData.Direction -= Input.GetKey(inputData.DownKey) ? 1 : 0;
            }).Run();

            return default;
        }
    }
}