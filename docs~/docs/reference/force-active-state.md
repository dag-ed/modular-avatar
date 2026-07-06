# Force Active State

This component forces the GameObject it is attached to into a configured active state during avatar build.

## When should I use it?

Use this component when a prefab should always be built with a specific GameObject active state, regardless of the scene state while editing.

For example, a prefab author can keep setup helpers visible while editing, then force them inactive when the avatar is built.

## Setting up Force Active State

Attach a `Force Active State` component to the GameObject whose active state should be controlled.

Set **Build Active State** to the state that should be applied during avatar build.

Inactive GameObjects are also processed, so the component can force an inactive object active at build time.
