using Pong.Scripts.Helpers;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Pong.Scripts.Systems
{
    [AlwaysSynchronizeSystem]
    public class RocketMovementSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            var yBound = GameManager.Main.yBound;
            Entities.ForEach((ref Translation translation, in RocketMovementData movementData) =>
            {
                translation.Value.y =
                    math.clamp(translation.Value.y + movementData.Direction * movementData.Speed * deltaTime,
                        -yBound, yBound);
            }).Run();

            return default;
        }
    }
}