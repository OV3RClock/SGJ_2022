using System;
using System.Collections.Generic;
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
        private PadTileBehaviour[] tiles;
        
        private List<Color> colors = new List<Color>();
        private Dictionary<Color, ETileSymbol> tileSymbols = new Dictionary<Color, ETileSymbol>();

        
        private void Awake()
        {
            colors.Add(Color.green);
            colors.Add(Color.yellow);
            colors.Add(new Color(255, 130, 0));
            colors.Add(Color.red);
            
            foreach (var color in colors)
            {
                ETileSymbol symbol = GetRandomSymbol();
                tileSymbols.Add(color, symbol);
                Debug.Log(color + " " + symbol);
            }
        }

        private void Start()
        {
            tiles = padPuzzleTiles.GetComponentsInChildren<PadTileBehaviour>();
            for (int i = 0; i < colors.Count; ++i)
            {
                tiles[i].color = colors[i];
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
                    Debug.Log(tile.color + "-" + sym + " " + tile.symbol);
                    if (sym != tile.symbol) return false;
                }
            }

            return true;
        }

        public void notify()
        {
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