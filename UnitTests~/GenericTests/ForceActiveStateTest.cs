using nadena.dev.modular_avatar.core;
using nadena.dev.modular_avatar.core.editor;
using nadena.dev.ndmf.platform;
using NUnit.Framework;
using BuildContext = nadena.dev.ndmf.BuildContext;

namespace modular_avatar_tests
{
    public class ForceActiveStateTest : TestBase
    {
        private class DummyPlatformProvider : INDMFPlatformProvider
        {
            public string QualifiedName => "TestPlatform";
            public string DisplayName => QualifiedName;
        }

        [Test]
        public void ForcesActiveObjectInactive()
        {
            var root = CreateRoot("root");
            var child = CreateChild(root, "child");
            child.SetActive(true);
            child.AddComponent<ModularAvatarForceActiveState>().Active = false;

            var appliedCount = ForceActiveStatePass.Process(root);

            Assert.AreEqual(1, appliedCount);
            Assert.IsFalse(child.activeSelf);
        }

        [Test]
        public void ForcesInactiveObjectActive()
        {
            var root = CreateRoot("root");
            var child = CreateChild(root, "child");
            child.SetActive(false);
            child.AddComponent<ModularAvatarForceActiveState>().Active = true;

            var appliedCount = ForceActiveStatePass.Process(root);

            Assert.AreEqual(1, appliedCount);
            Assert.IsTrue(child.activeSelf);
        }

        [Test]
        public void AppliesMultipleComponents()
        {
            var root = CreateRoot("root");
            var first = CreateChild(root, "first");
            var second = CreateChild(root, "second");

            first.SetActive(true);
            second.SetActive(false);
            first.AddComponent<ModularAvatarForceActiveState>().Active = false;
            second.AddComponent<ModularAvatarForceActiveState>().Active = true;

            var appliedCount = ForceActiveStatePass.Process(root);

            Assert.AreEqual(2, appliedCount);
            Assert.IsFalse(first.activeSelf);
            Assert.IsTrue(second.activeSelf);
        }

        [Test]
        public void BuildContextPassForcesState()
        {
            var root = CreateRoot("root");
            var child = CreateChild(root, "child");
            child.SetActive(false);
            child.AddComponent<ModularAvatarForceActiveState>().Active = true;
            var context = new BuildContext(root, null, new DummyPlatformProvider());

            new ForceActiveStatePass().Process(context);

            Assert.IsTrue(child.activeSelf);
        }
    }
}
