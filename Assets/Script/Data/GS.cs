using UnityEngine;
//Game Settings
public class GS {
	//game layout
	public static readonly float LEFT_LIMIT = -4.5f;
	public static readonly float RIGHT_LIMIT = 4.5f;
	public static readonly float TOP_LIMIT = 5f;

	public static readonly int RIGHT = 1;
	public static readonly int LEFT = -1;

	//enemy
	public static readonly int CORPSE_WIDTH = 11;
	public static readonly int CORPSE_HEIGHT = 5;
	public static readonly float ENEMY_WIDTH = 0.7f;
	public static readonly float ENEMY_HEIGHT = 0.63f;
	public static readonly Vector3 ENEMY_SPEED = new Vector3(ENEMY_WIDTH/5, 0f, 0f);
	public static readonly Vector3 ENEMY_SPEED_DOWN = new Vector3(0f, -ENEMY_HEIGHT/2, 0f);
	public static readonly float ENEMY_HEIGHT_OFFSET = 5*ENEMY_HEIGHT/2;
	public static readonly float MOVE_COOL_TIME = 0.8f;
	public static readonly float ATTACK_COOL_TIME = 0.5f;
	public static readonly float ENEMY_BULLET_SPEED = 6f;
	public static readonly Vector3 ENEMY_MAZZLE_OFFSET = new Vector3(0f, -0.4f, 0f);

	//redCube
	public static readonly float RED_QUBE_SIZE = 0.05f;
}
