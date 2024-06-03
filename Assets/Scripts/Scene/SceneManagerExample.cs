public sealed class SceneManagerExample : SceneManagerBase
{
    public override void InitScenesMap()
    {
        _sceneConfigMap[SceneConfigExample.SCENE_NAME] = new SceneConfigExample();
    }
}