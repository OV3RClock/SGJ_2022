using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BLUE_GREEN_CONES : C�nes bleu/vert -> Permet de voir le bleu et le vert
 * RED_CONE : C�ne rouge -> Permet de voir le rouge
 * RODS : B�tonnets -> Permet de voir les choses de faible intensit�/vision nocturne
 * HORIZONTAL_CELL : Cellule horizontale -> Permet d'augmenter la nettet�
 * GANGLION_CELL : Cellule ganglionnaire -> Permet d'augmenter le contraste
 * AMACRINE_CELL : Cellule amacrine -> Permet d'anticiper des mouvements
 */
public enum Behavior {BLUE_GREEN_CONES, RED_CONE, RODS,  HORIZONTAL_CELL, GANGLION_CELL, AMACRINE_CELL}

[CreateAssetMenu(fileName = "Ennemi", menuName = "ScriptableObjects/Ennemi")]
public class EnnemisSO : ScriptableObject
{
    public Behavior[] BehaviorDependant;
}
