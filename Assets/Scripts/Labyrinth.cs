using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class Labyrinth : MonoBehaviour
{

    [SerializeField] private TilemapRenderer _redLine;
    [SerializeField] private Light2D _labyLight;

    void Update()
    {
        if(AbilitiesManager.instance.IsAbilityActive(EAbilities.RED)) 
            _redLine.gameObject.SetActive(true);
        else
            _redLine.gameObject.SetActive(false);



        if (AbilitiesManager.instance.IsAbilityActive(EAbilities.NIGHT_VISION))
            _labyLight.intensity = 0.2f;
        else
            _labyLight.intensity = 0f;
    }
}
