using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public class DanceController : MonoBehaviour
{
    private static readonly int IsDancing = Animator.StringToHash("isDancing");
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(IsDancing, false);
    }

    private void Update()
    {
        bool pressed = false;
#if ENABLE_INPUT_SYSTEM
        pressed = Keyboard.current != null &&
                  Keyboard.current.spaceKey.wasPressedThisFrame;
#endif
#if ENABLE_LEGACY_INPUT_MANAGER
        pressed |= Input.GetKeyDown(KeyCode.Space);
#endif
        if (pressed)
            animator.SetBool(IsDancing, !animator.GetBool(IsDancing));
    }
}
