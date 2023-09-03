using TMPro;
using UnityEngine;

public class Credits : MonoBehaviour {
    [SerializeField] private TMP_Text text;
    private bool show = true;

    public void ShowCredits() {
        show = !show;
        text.gameObject.SetActive(show);
    }
}
