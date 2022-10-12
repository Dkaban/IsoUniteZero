using Code.Managers;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Inject] private IsoWorldManager _isoWorldManager;
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
            _isoWorldManager.PlayerObject = Container.InstantiatePrefab(playerPrefab);
            
            _sceneContext.PostInstall -= InitGame;
        }
    }
}
