using UnityEngine;

namespace Code.Managers
{
    public class IsoWorldManager
    {
        private Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        public Vector3 ToIso(Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
        public GameObject PlayerObject;
    }
}
