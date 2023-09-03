using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {
    [SerializeField] private Image text;
    private bool show = true;

    public void ShowCredits() {
        show = !show;
        text.gameObject.SetActive(show);
    }
}
