using UnityEngine;

namespace Arkanoid.Level
{
    public class PlatformModified : PlatformBase
    {
        [SerializeField] private float startYPos;

        protected override void SetPosition(Vector2 position)
        {
            if (isPause == true)
                return;

            float x = Mathf.Clamp(position.x, -clampRange, clampRange);
            transform.position = new Vector2(x, CalculateY(x));
        }

        private float CalculateY(float x) => startYPos + Mathf.Sin(x);
    }
}
