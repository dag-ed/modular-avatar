using nadena.dev.ndmf;
using UnityEngine;

namespace nadena.dev.modular_avatar.core.editor
{
    internal class ForceActiveStatePass : Pass<ForceActiveStatePass>
    {
        protected override void Execute(ndmf.BuildContext context)
        {
            Process(context.AvatarRootObject);
        }

        internal static int Process(GameObject avatarRoot)
        {
            if (avatarRoot == null)
            {
                return 0;
            }

            var components = avatarRoot.GetComponentsInChildren<ModularAvatarForceActiveState>(true);

            foreach (var component in components)
            {
                component.gameObject.SetActive(component.Active);
            }

            return components.Length;
        }
    }
}
