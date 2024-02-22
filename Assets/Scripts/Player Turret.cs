using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerTurret : MonoBehaviour {
    
    [SerializeField] private GameInput gameInput;

    void Update() {
        Vector3 mousePos = gameInput.GetMousePosition();
		mousePos.z = 5.23f;

		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}