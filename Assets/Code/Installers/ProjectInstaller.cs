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
            //Can Init API's here, anything that needs to be done at the start of the game
            Container.Bind<WorldManager>().AsSingle();
        }
    }
}