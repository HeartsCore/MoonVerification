using Core;
using Core.Customs;
using UnityEngine;


[CreateAssetMenu(fileName = "DifficultyData", menuName = "Data/DifficultyData")]
public class DifficultyData : ScriptableObject
{
    #region Fields
    [Header("Game Settigs")]
    public bool isShowCardInBeginningRound = true;
    public float showTime = 1.0f;

    [Header("Error Settigs")]
    public bool isShufflingCards = true;
    public int maxCountErrors = 1;
    public bool isCardWithoutPairs = true;

    [Header("HP Settigs")]
    public HPManager HPManager;
    public bool isHPHandle = true;
    public int maxHP = 3;
    public GameObject hpPrefab;
    #endregion


    #region Methods
    public void Initialization()
    {
        if (HPManager == null)
        {
            var manager = CustomResources.Load<HPManager>
                        (AssetsPathGameObject.GameObjects[GameObjectType.HPManager]);

            HPManager = Instantiate(manager);
        }
        

    }
    #endregion
}

