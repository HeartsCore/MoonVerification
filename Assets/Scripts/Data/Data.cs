using Core.Customs;
using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Core
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        #region Fields
        
        [SerializeField] private string _cardDataPath;
        
        private static CardData _cardData;
        private static readonly Lazy<Data> _instance = new Lazy<Data>(() => Load<Data>("Data/" + typeof(Data).Name));
        
        #endregion
        

        #region Properties

        public static Data Instance => _instance.Value;
                
        public CardData Card
        {
            get
            {
                if (_cardData == null)
                {
                    _cardData = Load<CardData>("Data/" + Instance._cardDataPath);
                }

                return _cardData;
            }
        }     

        #endregion


        #region Methods

        private static T Load<T>(string resourcesPath) where T : Object =>
            CustomResources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    
        #endregion
    }
}
