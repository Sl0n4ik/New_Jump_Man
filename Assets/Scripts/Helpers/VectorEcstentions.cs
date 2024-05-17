using UnityEngine;

namespace Scripts.Helpers
{
    public static class VectorEcstentions
    {
        public static Vector3 InUnits(this Vector3 value)
        {
            var rValue = Vector3.zero;
            rValue.x = value.x.InUnit();
            rValue.y = value.y.InUnit();
            rValue.z = value.z.InUnit();
            return rValue;
        }

        public static void RelativeSimilarity(this ref Vector2 vector, Vector2 relaveVector, SimilarityMode mode = SimilarityMode.Vertical)
        {
            int index = (int)mode;
            var coefficient = vector[index]/relaveVector[index];

            for(int i = 0; i < 2; i++)
            {
                if (i != index) vector[i] = relaveVector[i] * coefficient;
            }
        }

        public static Vector2 ConvertInVector2(this Vector3 vector)
        {
            return vector;
        }

        public static Vector2 InUnits(this Vector2 value)
        {
            var rValue = Vector2.zero;
            rValue.x = value.x.InUnit();
            rValue.y = value.y.InUnit();
            return rValue;
        }
    }

    public enum SimilarityMode
    {
        Horizontal = 0,
        Vertical = 1
    }
}