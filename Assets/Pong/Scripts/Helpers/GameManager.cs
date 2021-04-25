using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;
using UnityEngine.UI;

namespace Pong.Scripts.Helpers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Main;

        public float xBound = 10f, yBound = 3.5f;
        public Text redScore, blueScore;
        private int _playerRedScore = 0, _playerBlueScore = 0;
        public float ballSpeed;
        
        public GameObject ballPrefab;
        private Entity _ballEntityPrefab;
        private EntityManager _manager;
        

        private void Awake()
        {
            if (Main != null && Main != this)
            {
                Destroy(gameObject);
                return;
            }

            Main = this;

            _manager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, new BlobAssetStore());
            _ballEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(ballPrefab, settings);
            
            SpawnBall();
        }

        public void PlayerScored(PlayerColor color)
        {
            switch (color)
            {
                case PlayerColor.Red:
                    _playerRedScore++;
                    redScore.text = _playerRedScore.ToString();
                    break;
                case PlayerColor.Blue:
                    _playerBlueScore++;
                    blueScore.text = _playerBlueScore.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
            
            SpawnBall();
        }

        public enum PlayerColor
        {
            Red,
            Blue
        }

        private void SpawnBall()
        {
            var ball = _manager.Instantiate(_ballEntityPrefab);
            var dir = new Vector3(UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1, UnityEngine.Random.Range(-0.5f, 0.5f), 0f).normalized;
            var speed = dir * ballSpeed;

            var velocity = new PhysicsVelocity()
            {
                Linear = speed,
                Angular = float3.zero
            };

            _manager.AddComponentData(ball, velocity);
        }

    }
}