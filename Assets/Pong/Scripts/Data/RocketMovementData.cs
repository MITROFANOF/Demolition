using Unity.Entities;

namespace Pong.Scripts
{
    [GenerateAuthoringComponent]
    public struct RocketMovementData : IComponentData
    {
        public int Direction;
        public float Speed;
    }
}