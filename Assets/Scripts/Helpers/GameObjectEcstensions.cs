using UnityEngine;

namespace Scripts.Helpers
{
    public static class GameObjectEcstensions
    {
        public static bool IsInLayer(this GameObject go, LayerMask layer)
        {
            return layer == (layer | (1 << go.layer));
        }
    }
}