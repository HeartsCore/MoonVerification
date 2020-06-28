using Core;
using Moon.Asyncs;
using UnityEngine;
using UnityEngine.UI;


namespace MiniGames.Memory
{
    public class MemoryGameController : MonoBehaviour
    {
        #region PrivateData
        private readonly IInitialization[] _allControllers;
        private Controllers _controllers;

        private CardDealerController _cardDealerController;
        #endregion


        #region Fields
        [HideInInspector] public CameraAnimationController CameraAnimationController;

        public DifficultyController _difficultyController;
        public Button helpButton;
        #endregion


        #region Unity Methods
        private void Awake()
        {
            _controllers = new Controllers();
            Initialization();
            _cardDealerController = (CardDealerController)_controllers._initializations[0];
            _difficultyController = (DifficultyController)_controllers._initializations[1];
            CameraAnimationController = GetComponentInChildren<CameraAnimationController>();
        }
        #endregion


        #region MoonAsync Methods
        public AsyncState RunGame(MemoryGameModel gameModel)
        {
            // game login entry point
            return Planner.Chain()
                    .AddAction(_cardDealerController.SetImages, gameModel.images)
                    .AddAction(_cardDealerController.SetDifficultyController, _difficultyController)

                    .AddFunc(_cardDealerController.CardDealing, gameModel.numberOfCardPairs)
                    .AddAction(() =>
                    {
                        if (gameModel.HelpCount != 0)
                        {
                            helpButton.gameObject.SetActive(true);
                            _cardDealerController.MaxHelpCount = gameModel.HelpCount;
                            _cardDealerController.HelpButton = helpButton;
                        }
                    })
                    .AddAwait(AwaitFunc)
                ;
        }

        private void AwaitFunc(AsyncStateInfo state)
        {
            // todo: game complete condition;
            state.IsComplete = CardDealerController.IsFinishGameRound;
        }
        
        public AsyncState GetDifficultyController()
        {
            return Planner.Chain()
                .AddAction(() => DifficultyControllerForAsync());

        }
        #endregion


        #region  Methods
        public void Initialization()
        {
            _controllers.Initialization();
        }
        private DifficultyController DifficultyControllerForAsync()
        {
            return _difficultyController;
        }
        #endregion
    }
}
