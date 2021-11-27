using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldChanger : MonoBehaviour
{
    private ISceneChanger sceneChanger = new SceneChangerSceneLoad();

    public void ChangeScene(SwitchToSceneButton switchTo)
        => sceneChanger.SwitchTo(switchTo.scene);
}

public class SceneChangerDebugLog : ISceneChanger
{
    public void SwitchTo(Scenes scene)
        => Debug.Log(scene.ToString());
}

public class SceneChangerSceneLoad : ISceneChanger
{
    public void SwitchTo(Scenes scene)
        => SceneManager.LoadScene(scene.ToString());
}

public class SceneChangerAdditive : ISceneChanger
{
    public void SwitchTo(Scenes scene)
        => Debug.LogWarning("Need to implement Additive Loading");
}

public interface ISceneChanger
{
    void SwitchTo(Scenes scene);
}

public enum Scenes
{
    Original,
    MegoPlayset,
    LandOfGiants,
    DancingOnCeiling,
    NoGravity
}