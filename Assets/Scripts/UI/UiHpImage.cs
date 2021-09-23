using UnityEngine.UI;
using UnityEngine;
namespace BerserkAdventure
{
    [RequireComponent(typeof(Image))]
    public class UiHpImage : MonoBehaviour
    {
        private Image _imageHp;


        private void Start()
        {
            _imageHp = GetComponent<Image>();
           // SetPositionAndSize();
        }

        public float ImageHp
        {
            set
            {
                if (!_imageHp)
                {
                    Start();
                }
                _imageHp.fillAmount =  value;
            }
        }

        public void SetActive(bool value)
        {
            _imageHp.gameObject.SetActive(value);
        }

        private void SetPositionAndSize()
        {
            gameObject.transform.localScale = new Vector2(1, 1);
            // gameObject.transform.position = new Vector3(Screen.width / 10, Screen.height - Screen.height / 10f);
        }
    }
}