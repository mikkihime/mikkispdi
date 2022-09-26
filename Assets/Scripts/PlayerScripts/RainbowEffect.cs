using UnityEngine;

namespace PlayerScripts
{
    public class RainbowEffect : MonoBehaviour
    {
        [field: SerializeField] private float ColorMultiplier { get; set; }
        [field: SerializeField] private SpriteRenderer SpriteRenderer { get; set; }

        private float hue;

        private float saturation;

        private float value;
    
        public void Rainbow()
        {
            Color.RGBToHSV(SpriteRenderer.material.color, out hue, out saturation, out value);

            if (hue >= 1)
                hue = 0;
            
            hue += ColorMultiplier / 5000;

            saturation = 1;
            value = 1;
            SpriteRenderer.material.color = Color.HSVToRGB(hue, saturation, value);
        }

        public void BackToOriginal()
        {
            SpriteRenderer.material.color = Color.white;
        }
    }
}
