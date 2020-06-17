using System.Collections.Generic;


namespace Core
{
    public sealed class AssetsPathGameObject
    {
        #region Fields

        public static readonly Dictionary<GameObjectType, string> GameObjects = new Dictionary<GameObjectType, string>
        {
            {
                GameObjectType.Canvas, "GUI/GUI_Canvas"
            },
            {                
                GameObjectType.Card, "Prefabs/Card/Prefabs_Card"
            }

        };

        #endregion
    }
}
