using System;
using Managers;
using UnityEngine;

namespace PadPuzzle
{
    public class PadTileBehaviour : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite circle;
        [SerializeField] private Sprite square;
        
        public static Action onTileChangeEvent;
        
        public PadPuzzleManager.ETileSymbol symbol { get; set; }
        public Color color { get; set; }
        private int symbolID = 0;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            string layerName = LayerMask.LayerToName(collision.gameObject.layer);
            if (layerName == "Player")
            {
                NextSymbol();
                notify();
            }
        }

        private void NextSymbol()
        {
            ++symbolID;

            Type type = typeof(PadPuzzleManager.ETileSymbol);
            Array values = type.GetEnumValues();

            if (symbolID >= values.Length)
            {
                symbolID = 0;
            }

            symbol = (PadPuzzleManager.ETileSymbol) values.GetValue(symbolID);
            onTileChangeEvent();
        }

        public void notify()
        {
            Sprite finalSprite = circle;
            Color finalColor = new Color(255, 255, 255, 0);

            bool redActive = AbilitiesManager.instance.IsAbilityActive(EAbilities.RED);
            bool blurActive = AbilitiesManager.instance.IsAbilityActive(EAbilities.BLUR);
            
            if (blurActive)
            {
                finalColor = Color.green;
                
                switch (symbol)
                {
                    case PadPuzzleManager.ETileSymbol.CIRCLE:
                        finalSprite = circle;
                        break;
                    case PadPuzzleManager.ETileSymbol.SQUARE:
                        finalSprite = square;
                        break;
                }
            }

            if (redActive)
            {
                finalColor = this.color;
            }

            spriteRenderer.color = finalColor;
            spriteRenderer.sprite = finalSprite;
        }
        
        private void OnEnable()
        {
            AbilitiesManager.abilitiesManagerEvent += notify;
        }
        
        private void OnDestroy()
        {
            AbilitiesManager.abilitiesManagerEvent -= notify;
        }

    }
}