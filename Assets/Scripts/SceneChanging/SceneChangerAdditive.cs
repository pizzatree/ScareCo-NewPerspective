using UnityEngine;

namespace SceneChanging
{
    public class SceneChangerAdditive : ISceneChanger
    {
        public void SwitchTo(Scenes scene)
            => Debug.LogWarning("Need to implement Additive Loading");
    }
}