using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace PadPuzzle
{
    public class PadPuzzleManager : MonoBehaviour
    {
        public enum ETileSymbol
        {
            CIRCLE,
            SQUARE
        }

        [SerializeField] private DoorBehaviour door;
        [SerializeField] private GameObject padPuzzleTiles;
        [SerializeField] private GameObject padSolutionTiles;
        private PadTileBehaviour[] tiles;
        
        private List<Color> colors = new List<Color>();
        private Dictionary<Color, ETileSymbol> tileSymbols = new Dictionary<Color, ETileSymbol>();
        private bool solved;
        
        private void Awake()
        {
            colors.Add(Color.green);
            colors.Add(new Color(255, 0, 255));
            colors.Add(new Color(255, 130, 0));
            colors.Add(Color.blue);
            
            foreach (var color in colors)
            {
                ETileSymbol symbol = GetRandomSymbol();
                tileSymbols.Add(color, symbol);
            }
        }

        private void Start()
        {
            tiles = padPuzzleTiles.GetComponentsInChildren<PadTileBehaviour>();
            for (int i = 0; i < colors.Count; ++i)
            {
                tiles[i].color = colors[i];
            }
            
            PadTileBehaviour[] solutionTiles = padSolutionTiles.GetComponentsInChildren<PadTileBehaviour>();
            for (int i = 0; i < colors.Count; ++i)
            {
                solutionTiles[i].color = colors[i];
                ETileSymbol sym;
                if (tileSymbols.TryGetValue(colors[i], out sym))
                {
                    solutionTiles[i].symbol = sym;
                }
            }
        }

        private ETileSymbol GetRandomSymbol()
        {
            Random random = new Random();

            Type type = typeof(ETileSymbol);
            Array values = type.GetEnumValues();
            int index = random.Next(values.Length);

            return (ETileSymbol) values.GetValue(index);
        }

        private bool isSolved()
        {
            foreach (var tile in tiles)
            {
                ETileSymbol sym;
                if (tileSymbols.TryGetValue(tile.color, out sym))
                {
                    if (sym != tile.symbol) return false;
                }
            }
            AudioManager.Instance.Play("SFXCodeSuccess");
            solved = true;
            return true;
        }

        public void notify()
        {
            if (solved) return;

            bool redUnlocked = AbilitiesManager.instance.IsAbilityUnlocked(EAbilities.RED);
            bool blurUnlocked = AbilitiesManager.instance.IsAbilityUnlocked(EAbilities.BLUR);

            if(redUnlocked && blurUnlocked && door.IsLocked())
                door.SetIsLocked(!isSolved());
        }
    
        private void OnEnable()
        {
            PadTileBehaviour.onTileChangeEvent += notify;
        }
    
        private void OnDestroy()
        {
            PadTileBehaviour.onTileChangeEvent -= notify;
        }

    }
}