using UnityEngine.SceneManagement;

namespace SceneChanging
{
    public class SceneChangerSceneLoad : ISceneChanger
    {
        public void SwitchTo(Scenes scene)
            => SceneManager.LoadScene(scene.ToString());
    }
}