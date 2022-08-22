using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Init = 0,
    Gameplay = 1,
    GameOver = 2
}

public class GameplayManager : MonoBehaviour
{
    private static GameplayManager s_instance;
    public static GameplayManager Instance
	{
        get
		{
            return s_instance;
		}
	}

    private GameState m_state = GameState.Init;
    public GameState State
	{
        get
		{
            return m_state;
		}
	}

    [SerializeField]
    private Grid m_grid;
    public Grid Grid
	{
        get
		{
            return m_grid;
		}
	}

    [SerializeField]
    private GameCamera m_camera;
    public GameCamera GameCamera
	{
        get
		{
            return m_camera;
		}
	}

    void Awake()
    {
        if (!s_instance)
        {
            s_instance = this;
        }

        SetState(GameState.Init);
    }

    void Update()
    {
        
    }

    private void SetState(GameState _newState)
	{
        m_state = _newState;

        switch (_newState)
        {
            case GameState.Init:
			{
                OnInit();
                break;
			}

            case GameState.Gameplay:
            {
                OnGameplay();
                break;
            }

            case GameState.GameOver:
            {
                OnGameOver();
                break;
            }
        }
	}

	private void OnInit()
	{
        m_camera = Camera.main.gameObject.GetComponentInChildren<GameCamera>();
	}

    private void OnGameplay()
	{

	}

    private void OnGameOver()
	{

	}
}
