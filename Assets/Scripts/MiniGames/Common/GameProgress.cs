using Core;
using Core.Customs;
using Moon.Asyncs;
using UnityEngine;


namespace MiniGames.Common
{
    public class GameProgress : MonoBehaviour
    {
        #region PrivateData
        private ProgressBar _progressBar;
        #endregion


        #region Properties
        public float NumberOfRounds { private get; set; }
        #endregion


        #region Unity Methods
        private void Awake()
        {
            var progressBarBehaviour = CustomResources.Load<ProgressBar>
                            (AssetsPathGameObject.GameObjects[GameObjectType.ProgressBar]);

            _progressBar = Instantiate(progressBarBehaviour);
            
        }
        #endregion


        #region MoonAsync Methods
        public AsyncState IncrementProgress()
        {
            return Planner.Chain()
                    // TODO: run progress animation, await finish
                    .AddTween(_progressBar.SetCurrentValue, 1f / NumberOfRounds)
                    .AddTimeout(1f)
                ;
        }

        public AsyncState ShowProgressBar()
        {
            return Planner.Chain()
                    .AddFunc(_progressBar.Show)
                ;
        }

        public AsyncState CloseProgressBar()
        {
            return Planner.Chain()
                        .AddFunc(_progressBar.Close)
                    ;
        }
        #endregion


        #region  Methods
        public void ResetProgress(int count)
        {
            // TODO: reset progress to zero. Set progress max
        }
        #endregion
    }
}