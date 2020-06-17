using Core.Customs;
using UnityEngine;


namespace Core
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Data/Card/CardData")]
    public sealed class CardData : ScriptableObject
    {
        [SerializeField] private float _cardDisplayTime = 0.2f;

        [HideInInspector] public CardBehaviour CardBehaviour;

        //private ITimeService _timeService;

        public void Initialization()
        {
            var cardBehaviour = CustomResources.Load<CardBehaviour>
                (AssetsPathGameObject.GameObjects[GameObjectType.Card]);

            CardBehaviour = Instantiate(cardBehaviour);
            //_timeService = Services.Instance.TimeService;
        }

        public float GetCardDisplayTime()
        {
            return _cardDisplayTime;
        }

    }
}