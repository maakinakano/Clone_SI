using UnityEngine;
//Game Settings
public class GS {
	public static readonly float LEFT_LIMIT = -10f;
	public static readonly float RIGHT_LIMIT = 10f;

	public static readonly int RIGHT = 1;
	public static readonly int LEFT = -1;

	//enemy
	public static readonly int CORPSE_WIDTH = 11;
	public static readonly int CORPSE_HEIGHT = 5;
	public static readonly float ENEMY_WIDTH = 1.1f;
	public static readonly float ENEMY_HEIGHT = 0.8f;
	public static readonly Vector3 ENEMY_SPEED = new Vector3(ENEMY_WIDTH/2, 0f, 0f);
	public static readonly Vector3 ENEMY_SPEED_DOWN = new Vector3(0f, -ENEMY_HEIGHT/2, 0f);
}
