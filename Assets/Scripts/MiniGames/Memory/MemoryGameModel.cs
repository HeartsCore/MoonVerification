using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Serialization;


namespace MiniGames.Memory
{
    [CreateAssetMenu(fileName = "MemoryGameModel", menuName = "MiniGames/Memory/MemoryGameModel")]
    public class MemoryGameModel: ScriptableObject
    {
        
        [SerializeField, FormerlySerializedAs("rounds")] private RoundParams[] _rounds;
        [SerializeField, FormerlySerializedAs("helpCount")] private int _helpCount;
                
        public RoundParams[] GetRounds()
        {
            return _rounds;
        }

        public float GetHelpCount()
        {
            return _helpCount;
        }

        [System.Serializable]
        public class RoundParams
        {
            [SerializeField] private int _numberOfCardPairs;
            [SerializeField] private SpritesType _type = SpritesType.Animals;
            [SerializeField] private SpriteAtlas _spriteAtlas;
        }

    }
}