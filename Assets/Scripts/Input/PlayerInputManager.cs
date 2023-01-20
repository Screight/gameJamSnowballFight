using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputManager : Singleton<PlayerInputManager>
{

    PlayerControl m_inputActions;
    Vector2 m_movementInput;

    UnityEvent m_reloadEvent;
    public void AddListenerToReloadEvent(UnityAction p_action)
    {
        m_reloadEvent.AddListener(p_action);
    }
    public void RemoveListenerFromReloadEvent(UnityAction p_action)
    {
        m_reloadEvent.RemoveListener(p_action);
    }

    UnityEvent m_shootEvent;
    public void AddListenerToShootEvent(UnityAction p_action)
    {
        m_shootEvent.AddListener(p_action);
    }
    public void RemoveListenerFromShootEvent(UnityAction p_action)
    {
        m_shootEvent.RemoveListener(p_action);
    }

    UnityEvent m_pauseEvent;
    public void AddListenerToPauseEvent(UnityAction p_action)
    {
        m_pauseEvent.AddListener(p_action);
    }
    public void RemoveListenerFromPauseEvent(UnityAction p_action)
    {
        m_pauseEvent.RemoveListener(p_action);
    }

    protected override void Awake()
    {
        base.Awake();
        m_reloadEvent = new UnityEvent();
        m_shootEvent = new UnityEvent();
        m_pauseEvent = new UnityEvent();
    }

    private void Update() {
        
        InputSystem.Update();
    }

    private void OnEnable()
    {
        if (m_inputActions != null) return;
        m_inputActions = new PlayerControl();

        m_inputActions.Enable();

        m_inputActions.Player.Movement.performed += MovementCallback;
        m_inputActions.Player.Movement.canceled += StopMovementCallback;
        m_inputActions.Player.Reload.performed += ReloadCallback;
        m_inputActions.Player.Shoot.performed += ShootCallback;
        m_inputActions.Player.Pause.performed += PauseCallback;
    }

    private void OnDisable()
    {
        m_inputActions.Disable();
        m_inputActions.Player.Movement.performed -= MovementCallback;
        m_inputActions.Player.Movement.canceled -= StopMovementCallback;
        m_inputActions.Player.Reload.performed -= ReloadCallback;
        m_inputActions.Player.Shoot.performed -= ShootCallback;
        m_inputActions.Player.Pause.performed -= PauseCallback;
    }

    private void MovementCallback(InputAction.CallbackContext p_context)
    {
        m_movementInput = p_context.ReadValue<Vector2>();
    }

    private void StopMovementCallback(InputAction.CallbackContext p_context)
    {
        m_movementInput = Vector2.zero;
    }

    void ReloadCallback(InputAction.CallbackContext p_context)
    {
        m_reloadEvent.Invoke();
    }

    void ShootCallback(InputAction.CallbackContext p_context)
    {
        m_shootEvent.Invoke();
    }

    private void PauseCallback(InputAction.CallbackContext p_context)
    {
        m_pauseEvent.Invoke();
    }

    public Vector2 MovementInput { get { return m_movementInput; } }

}

