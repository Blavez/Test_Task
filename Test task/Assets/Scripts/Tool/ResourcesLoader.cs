using UnityEngine;

namespace Tool
{
    internal static class ResourcesLoader
    {
        public static Sprite LoadSprite(ResourcePath path) =>
            Resources.Load<Sprite>(path.PathResource);

        public static GameObject LoadPrefab(ResourcePath path) =>
            Resources.Load<GameObject>(path.PathResource);

        public static Rigidbody2D LoadObject(ResourcePath path) =>
           Resources.Load<Rigidbody2D>(path.PathResource);
    }
}
