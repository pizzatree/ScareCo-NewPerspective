using UnityEngine;

namespace SceneChanging
{
    public class SceneChangerDebugLog : ISceneChanger
    {
        public void SwitchTo(Scenes scene)
            => Debug.Log(scene.ToString());
    }
}