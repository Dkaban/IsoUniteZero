using UnityEngine;

namespace Code.Player
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "PlayerData", menuName = "UniteZero/Player/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [Header("Movement")] public float movementSpeed = 5;
        public float turnSpeed = 360;
    }
}
