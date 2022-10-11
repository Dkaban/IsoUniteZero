using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        private SceneContext _sceneContext;

        public override void InstallBindings()
        {
            _sceneContext = GetComponent<SceneContext>();
            SignalBusInstaller.Install(Container); //Install the SignalBus
            Container.BindInterfacesTo<GameInitializer>().AsSingle();

            _sceneContext.PostInstall += InitGame;
        }

        private void InitGame()
        {
            Container.InstantiatePrefab(playerPrefab);

            _sceneContext.PostInstall -= InitGame;
        }
    }
}
