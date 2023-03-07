public class PlayerInputManager : Manager
{
    public PlayerInput playerInput;

    public override void OnStart()
    {
        playerInput = new();
        playerInput.Enable();
    }

    public override void OnUpdate()
    {
    }
}
