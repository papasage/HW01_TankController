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
	}

	private void Update()
	{
	}

	//my update function isn't able to call the increaseHealth method, and I am not sure why.
	//If I can get the player to heal every frame while blue and disable powerup visuals I will be done.
}
