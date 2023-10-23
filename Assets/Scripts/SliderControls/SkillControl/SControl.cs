using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SControl : MonoBehaviour
{
    [SerializeField] private float maxTime = 15f;
    [SerializeField] private float currentETime = 0;
    [SerializeField] private float currentQTime = 0;

    public SkillSliderControl skillBar;
    private PlayerControl _player;
    private Health _playerHealth;

    private bool isEpressed;
    private bool isQpressed;
    private void Start()
    {
        skillBar.SetPowerMaxTime(maxTime);
        skillBar.SetQMaxTime(maxTime);
        _player = GetComponent<PlayerControl>();
        _playerHealth = GetComponent<Health>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentETime = 0;
            isEpressed = true;
            _player.moveSpeed = 10f;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentQTime = 0;
            isQpressed = true;
            _playerHealth.playerMaxHealth = 3;
        }

        if (isEpressed)
        {
            currentETime += 1 * Time.deltaTime;
            skillBar.SetPowerTime(currentETime);
            
            if (currentETime >= maxTime)
            {
                skillBar.SetPowerTime(0);
                currentETime = 0;
                isEpressed = false;
                _player.moveSpeed = 5f;
                
            }
        }
        if (isQpressed)
        {
            currentQTime += 1 * Time.deltaTime;
            skillBar.SetQTime(currentQTime);
            
            if (currentQTime >= maxTime)
            {
                skillBar.SetQTime(0);
                currentQTime = 0;
                isQpressed = false;
                _playerHealth.playerMaxHealth = 2;
            }
        }

    }
}
