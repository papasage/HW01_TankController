using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _storeMaxHealth;
    int _currentHealth;
    int _currentTreasure;

    TankController _tankController;
    [SerializeField] Text _uiTresureText;
    [SerializeField] Text _uiHealthText;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _currentTreasure = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _uiTresureText.text = "Treasures: " + _currentTreasure;
        _uiHealthText.text = "Health: " + _currentHealth;
    }

    public void IncreaseTreasure(int amount)
    {
        _currentTreasure += amount;
        Debug.Log("Treasure: " + _currentTreasure);

    }
    
    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's Health: " + _currentHealth);

    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player's Health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill() 
    {
        gameObject.SetActive(false);
        //play particles
        //play sounds
    }

    public void ActivateInvis()
    {
        _storeMaxHealth = _maxHealth;
        _maxHealth = 9999;
        _currentHealth = _maxHealth;
    }

    public void DeactivateInvis()
    {
        _maxHealth = _storeMaxHealth;
        _currentHealth = _maxHealth;
    }

}
