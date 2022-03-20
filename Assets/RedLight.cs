using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RedLight : MonoBehaviour
{
    private Animator _animator;
    private Light2D _light;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _light = gameObject.GetComponent<Light2D>();
    }

    void Update()
    {
        if (AbilitiesManager.instance.IsAbilityActive(EAbilities.RED))
        {
            _animator.enabled = true;
        }
        else
        {
            _animator.enabled = false;
            _light.intensity = 0f;
        }
    }
}
