using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
	protected abstract void PowerUp(Player player);

	[SerializeField] float powerupDuration = 1;
	[SerializeField] float _movementSpeed = 1;

	[SerializeField] ParticleSystem _collectParticles;
	[SerializeField] AudioClip _collectSound;

	Rigidbody _rb;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Movement(_rb);
	}

	private void OnTriggerEnter(Collider other)
	{
		Player player = other.gameObject.GetComponent<Player>();

		if (player != null)
		{
			PowerUp(player);
			//spawn particles & sfx because we need to disable object
			Feedback();

			gameObject.SetActive(false);
		}

	}



	private void Movement(Rigidbody rb)
	{
		//calculate rotation
		Quaternion turnOffset = Quaternion.Euler(_movementSpeed, _movementSpeed, _movementSpeed);
		rb.MoveRotation(rb.rotation * turnOffset);

	}

	private void Feedback()
	{
		//particles
		if (_collectParticles != null)
		{
			_collectParticles = Instantiate(_collectParticles, transform.position, Quaternion.identity);
		}

		//audio. TODO - consider Object Pooling for performance
		if (_collectSound != null)
		{
			AudioHelper.PlayClip2D(_collectSound, 1f);
		}
	}
}