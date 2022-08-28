using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{

	protected override void PowerUp(Player player)
	{
		player.ActivateInvis();
		Debug.Log("INVIS Power UP");
		StartCoroutine(PowerUpActive(player));
		_bodyRenderer.material = invisPlayerMat;
		_turretRenderer.material = invisPlayerMat;
		
	}

	protected override void PowerDown(Player player)
	{
			player.DeactivateInvis();
			_bodyRenderer.material = normalPlayerMat;
			_turretRenderer.material = normalPlayerMat;
			Debug.Log("INVIS Power DOWN");

		Destroy(gameObject);
	}


	//If I can disable powerup visuals I will be done.
}
