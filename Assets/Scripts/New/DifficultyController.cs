using Core;
using Core.Customs;
using Moon.Asyncs;
using System.Collections.Generic;


public class DifficultyController : IInitialization
{
    #region PrivateData
    private readonly DifficultyData _difficultyData;
    private readonly HPManager _hpManager;
    #endregion


    #region Properties
    public DifficultyData Config { get => _difficultyData; }
    #endregion


    #region ClassLifeCycle
    public DifficultyController()
    {
        CustomDebug.Log("Initialize DifficultyController");
        _difficultyData = Data.Instance.DifficultyData;
        _hpManager = _difficultyData.HPManager;
    }
    #endregion


    #region MoonAsycs Methods
    public AsyncState ShowCardsInBeginning(List<Card> cardsPool)
    {
        var asyncChain = Planner.Chain();
        if (!_difficultyData.isShowCardInBeginningRound)
            return asyncChain.AddEmpty();

        foreach (var cardP in cardsPool)
        {
            var card = cardP.GameObject.GetComponent<CardBehaviour>();
            asyncChain
                .JoinTween(card.Rise)
                .JoinTween(card.Rotate)
                ;
        }

        asyncChain.AddAction(CustomDebug.Log, "Show");
        asyncChain.AddTimeout(_difficultyData.showTime);
        asyncChain.AddAction(CustomDebug.Log, "Close");
        foreach (var cardP in cardsPool)
        {
            var card = cardP.GameObject.GetComponent<CardBehaviour>();
            asyncChain
                .JoinTween(card.ReRotate)
                .JoinTween(card.RePut);
        }

        return asyncChain;
    }

    public AsyncState HandleHP()
    {
        var asyncChain = Planner.Chain();
        if (!_difficultyData.isHPHandle)
            return asyncChain.AddEmpty();

        asyncChain.AddFunc(_hpManager.Execute, _difficultyData.hpPrefab, _difficultyData.maxHP);
        return asyncChain;
    }
    #endregion


    #region Methods
    public void Initialization()
    {
        _difficultyData.Initialization();
    }
    #endregion
}