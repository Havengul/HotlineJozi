using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public EnemySprite sprite;
	private float targetX, targetY;
	public float speed = 1f;
	public float viewDistance = 5f;
	public bool seen = false;

	private void Raycast (Vector3 direction) {
		Debug.DrawLine (transform.localPosition, direction, Color.red);
		RaycastHit2D hit = Physics2D.Linecast (transform.localPosition, direction, 1 << LayerMask.NameToLayer("Player"));
		if (hit) {
			seen = true;
			targetX = hit.collider.transform.localPosition.x;
			targetY = hit.collider.transform.localPosition.y;
		} else
			seen = false;
	}

	private void LookTowards (float x, float y) {
		Vector3 moveDirection = gameObject.transform.localPosition - new Vector3(x, y); 
		if (moveDirection != Vector3.zero) 
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
		}
	}

	private bool MoveTowards (float x, float y) {
		Vector3 tmp = transform.localPosition;
		float yDir = tmp.y > y ? -1 : 1;
		float xDir = tmp.x > x ? -1 : 1;
		if ((tmp.x < x + 0.5f && tmp.x > x - 0.5f) && (tmp.y < y + 0.5f && tmp.y > y - 0.5f))
			return true;
		if ((tmp.x < x + 0.5f && tmp.x > x - 0.5f) == false)
			tmp.x += Time.deltaTime * speed * xDir;
		if ((tmp.y < y + 0.5f && tmp.y > y - 0.5f) == false)
			tmp.y += Time.deltaTime * speed * yDir;
		transform.localPosition = tmp;
		LookTowards (x, y);
		Raycast (new Vector3(x + viewDistance * xDir, y + viewDistance * yDir));
		return false;
	}

	void Start () {
		targetX = Random.Range (-4, 4);
		targetY = Random.Range (-4, 4);
	}

	void Update () {
		if (MoveTowards (targetX, targetY) == true) {
			targetX = Random.Range (-4, 4);
			targetY = Random.Range (-4, 4);
		}
	}
}
