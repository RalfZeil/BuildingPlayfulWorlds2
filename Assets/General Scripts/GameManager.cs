using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static AudioManager AudioManager { get; private set; }
    public static PlayerInputManager PlayerInputManager { get; private set; }

    private Manager[] activeManagers;
    

    private void Awake()
    {
        Instance = this;
        StartManagers();
    }

    private void StartManagers()
    {
        AudioManager = new();
        PlayerInputManager = new();

        activeManagers = new Manager[]{
            AudioManager,
            PlayerInputManager,
        };

        foreach (Manager manager in activeManagers)
        {
            manager.OnStart();
        }
    }

    private void Update()
    {
        foreach(Manager manager in activeManagers)
        {
            manager.OnUpdate();
        }
    }
}
