using UnityEngine;

namespace nadena.dev.modular_avatar.core
{
    [AddComponentMenu("Modular Avatar/MA Force Active State")]
    [DisallowMultipleComponent]
    [HelpURL("https://modular-avatar.nadena.dev/docs/reference/force-active-state?lang=auto")]
    public class ModularAvatarForceActiveState : AvatarTagComponent
    {
        [SerializeField]
        internal bool m_active = true;

        public bool Active
        {
            get => m_active;
            set => m_active = value;
        }
    }
}
