using UnityEngine;
using Zenject;

namespace Code.Player.Actions
{
    public class Projectile : MonoBehaviour
    {
        public class Factory : PrefabFactory<Projectile>
        {
        
        }
    }
}
