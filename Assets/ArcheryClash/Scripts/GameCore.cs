using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Blek Game.
/// </summary>
namespace ArcherGameManager
{

	public enum GameState
	{
		NotStartedState,
		PlayState,
		FingerInState,
		FingerOutState,
		PlayingState,
		CompletedState,
		FailedState


	}

	/// <summary>
	/// Game manager.
	/// </summary>
	public class GameManager
	{
		private static GameManager gmInstance;

		private GameState currentGameState;
		//the current game state

		private int currentLevel;
		//current level of the game


		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static GameManager instance {
			get {
				if (gmInstance == null)
					gmInstance = new GameManager ();
				return gmInstance;
			}
		}

		private GameManager ()
		{
			//initalize
			CurrentGameState = GameState.NotStartedState;
			CurrentLevel = 0;
		}

		/// <summary>
		/// Gets or sets the state of the current game.
		/// </summary>
		/// <value>The state of the current game.</value>
		public GameState CurrentGameState {
			get {
				return currentGameState;
			}
			set {
				currentGameState = value;
			}
		}

		/// <summary>
		/// Gets or sets the current level.
		/// </summary>
		/// <value>The current level.</value>
		public int CurrentLevel {
			get {
				return currentLevel;
			}
			set {
				currentLevel = value;
			}
		}

	}

	/// <summary>
	/// Constants.
	/// </summary>
	public class Constants
	{
		public const string GameControllerTag = "GameController";
		public const string EndTag = "End";
		public const string ColorTag = "Color";
		public const float RestartWaitTime = 0.75f;
		public static Vector3 DefaultPlayerPosition = new Vector3 (100f, 100f, 0f);
		public const float DefaultTrailTime = 0.75f;
		public const float MoveDelay = 0.01f;
		public const string LevelText = "Level ";
	}

}