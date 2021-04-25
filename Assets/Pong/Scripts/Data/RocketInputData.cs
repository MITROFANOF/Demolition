using Unity.Entities;
using UnityEngine;

namespace Pong.Scripts.Data
{
    [GenerateAuthoringComponent]
    public struct RocketInputData : IComponentData
    {
        public KeyCode UpKey, DownKey;
    }
}