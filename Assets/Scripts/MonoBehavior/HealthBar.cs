using UnityEngine;

public class HealthBar : MonoBehaviour {
   private Transform bar;
   private void Start() {
      bar = transform.Find("Bar");
   }

   public void SetSize(float sizeNormalized) {
      bar.localScale = new Vector3(sizeNormalized, 0.5f);
   }
}
