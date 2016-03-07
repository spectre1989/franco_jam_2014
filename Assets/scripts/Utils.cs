using UnityEngine;

namespace HideAndSeek
{
    public static class Utils
    {
        public static Vector3 multiply(this Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static void normalise_angle(ref float angle)
        {
            while (angle < -180f)
            {
                angle += 360f;
            }
            while (angle >= 180f)
            {
                angle -= 360f;
            }
        }

        public static void normalise_angle(ref Vector3 angle)
        {
            normalise_angle(ref angle.x);
            normalise_angle(ref angle.y);
            normalise_angle(ref angle.z);
        }
    }
}