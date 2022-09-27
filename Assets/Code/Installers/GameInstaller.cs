using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameInstaller : MonoInstaller
    {
        private SceneContext _sceneContext;
        
        public override void InstallBindings()
        {
            _sceneContext = GetComponent<SceneContext>();
            _sceneContext.PostInstall += InitGame;
        }

        private void InitGame()
        {
            _sceneContext.PostInstall -= InitGame;
        }
    }
}
