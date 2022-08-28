using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
	protected abstract void PowerUp(Player player);
	protected abstract void PowerDown(Player player);

	protected Player player = null;
	protected bool powerupActive = false;
	Rigidbody _rb;

	// Characteristics
	[SerializeField] float powerupDuration = 5;
	[SerializeField] float _movementSpeed = 1;
	[SerializeField] MeshRenderer _powerupVisuals;
	[SerializeField] Collider _powerupCollider;

	// FEEDBACK
	[SerializeField] ParticleSystem _collectParticles;
	[SerializeField] AudioClip _collectSound;

	// MAKE BACKING FIELDS FOR THESE 4
	//PLAYER VISUAL EFFECT
	[SerializeField] protected Material normalPlayerMat = null;
	[SerializeField] protected Material invisPlayerMat = null;
	[SerializeField] protected MeshRenderer _bodyRenderer;
	[SerializeField] protected MeshRenderer _turretRenderer;



	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		_powerupCollider = GetComponent<Collider>();
		_powerupVisuals = GetComponent<MeshRenderer>();
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
			
			//gameObject.SetActive(false);
		}

	}

	protected IEnumerator PowerUpActive(Player player)
	{
		Debug.Log("IEnumerator started");
		powerupActive = true;
		_powerupCollider.enabled = !_powerupCollider.enabled;
		_powerupVisuals.enabled = !_powerupVisuals.enabled;
		yield return new WaitForSeconds(powerupDuration);
		powerupActive = false;
		PowerDown(player);

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