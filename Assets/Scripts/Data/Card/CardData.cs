﻿using Core.Customs;
using Moon.Asyncs;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Data/Card/CardData")]
    public sealed class CardData : ScriptableObject
    {
        #region PrivateData
        [Header("Game Settigs")]
        [SerializeField] private float _cardDisplayTime = 0.2f;
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private int _countFlipCardATime = 2;

        [Header("Controllers dragNdrop Data")]
        [SerializeField] private CardShufflingController _cardShuffl;

        private List<CardBehaviour> _flipedCards = new List<CardBehaviour>();
        #endregion


        #region Fields
        [HideInInspector] public CardBehaviour CardBehaviour;
        #endregion


        #region Methods
        public void Initialization()
        {
            if (_cardShuffl == null)
            {
                var cardShufflingController = CustomResources.Load<CardShufflingController>
                            (AssetsPathGameObject.GameObjects[GameObjectType.CardShufflingController]);

                _cardShuffl = Instantiate(cardShufflingController);
            }
        }
        
        public float GetCardDisplayTime()
        {
            return _cardDisplayTime;
        }

        public GameObject GetСardPrefab()
        {
            return _cardPrefab;
        }

        public int GetСountFlipCardATime()
        {
            return _countFlipCardATime;
        }
        public List<CardBehaviour> GetFlipedCards()
        {
            return _flipedCards;
        }

        public CardShufflingController GetCardShuffl()
        {
            return _cardShuffl;
        }
        #endregion
    }
}