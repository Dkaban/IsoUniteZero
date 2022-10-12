using Code.Player.Actions;
using UnityEngine;
using Zenject;

namespace Code.Player
{
    public class Weapon : MonoBehaviour
    {
        private Projectile.Factory _projectileFactory;
        [SerializeField] public GameObject ProjectilePrefab;

        [Inject]
        public void Construct(Projectile.Factory projectileFactory)
        {
            _projectileFactory = projectileFactory;
        }

        public void Fire()
        {
            var projectile = _projectileFactory.Create(ProjectilePrefab);
            projectile.transform.position = transform.position;
        }

        public class Factory : Factory<Weapon>
        {
        
        }
    }
}
