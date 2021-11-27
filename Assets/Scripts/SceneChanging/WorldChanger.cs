using UnityEngine;

namespace SceneChanging
{
    public class WorldChanger : MonoBehaviour
    {
        private ISceneChanger sceneChanger = new SceneChangerSceneLoad();

        public void ChangeScene(SwitchToSceneButton switchTo)
            => sceneChanger.SwitchTo(switchTo.scene);
    }
}