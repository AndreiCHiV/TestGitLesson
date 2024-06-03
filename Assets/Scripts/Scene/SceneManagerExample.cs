public sealed class SceneManagerExample : SceneMangerBase
{
    public override void InitScenesMap()
    {
        _sceneConfigMap[SceneConfigExample.SCENE_NAME] = new SceneConfigExample();
    }
}