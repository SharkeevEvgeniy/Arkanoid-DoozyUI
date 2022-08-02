using UnityEngine;

namespace Arkanoid.Level
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        public int LevelIndex;
        public int BallCount;
        public float StartVelocity;
        public float VelocityMuiltplier;
        public AnimationCurve ChangeVelocityCurve;
        public float TimeToFullVelocity;
    }
}
