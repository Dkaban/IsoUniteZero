using Code.Managers;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    [CreateAssetMenu(fileName = "WorldInstaller", menuName = "Installers/WorldInstaller")]
    public class WorldInstaller : ScriptableObjectInstaller<WorldInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IsoWorldManager>().AsSingle();
        }
    }
}