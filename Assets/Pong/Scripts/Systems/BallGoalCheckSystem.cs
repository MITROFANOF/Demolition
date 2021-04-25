using Pong.Scripts.Data;
using Pong.Scripts.Helpers;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace Pong.Scripts.Systems
{
    [AlwaysSynchronizeSystem]
    public class BallGoalCheckSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {

            Entities
                .WithAll<BallTag>()
                .WithStructuralChanges()
                .WithoutBurst()
                .ForEach((Entity entity, in Translation translation) =>
                {
                    var pos = translation.Value;
                    var bound = GameManager.Main.xBound;
                    if (pos.x >= bound)
                    {
                        GameManager.Main.PlayerScored(GameManager.PlayerColor.Red);
                        EntityManager.DestroyEntity(entity);
                        
                    }
                    else if (pos.x <= -bound)
                    {
                        GameManager.Main.PlayerScored(GameManager.PlayerColor.Blue);
                        EntityManager.DestroyEntity(entity);
                    }
                }).Run();

            return default;
        }
    }
}