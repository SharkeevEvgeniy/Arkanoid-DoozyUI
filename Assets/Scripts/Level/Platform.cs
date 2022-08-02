using UnityEngine;

namespace Arkanoid.Level
{
    public class Platform : PlatformBase
    {
        [SerializeField] private float startYPos;

        protected override void SetPosition(Vector2 position)
        {
            if (isPause == true)
                return;

            float normalizedPosition = position.x / (float)Screen.width;
            float x = ((clampRange * 2f) * normalizedPosition) - clampRange;
            x = Mathf.Clamp(x, -clampRange, clampRange);
            transform.position = new Vector2(x, startYPos);
        }
    }
}
