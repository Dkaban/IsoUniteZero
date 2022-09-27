using Code.Managers;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    [CreateAssetMenu(fileName = "ProjectInstaller", menuName = "Installers/ProjectInstaller")]
    public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IsoWorldManager>().AsSingle();
        }
    }
}