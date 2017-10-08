using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
	public Transform PlayerTrans;
	
	public GameObject SmallRound;

	public GameObject BuckShot;
	

	public void FireSmallRound()
	{
		Instantiate (SmallRound, PlayerTrans.position, PlayerTrans.rotation * Quaternion.Euler(0, 0, 270));
	}

	public void FireBuckShot()
	{
		var rng = new System.Random();
		for (var i = 0; i <= 15; i++)
		{
			var randomOffset = rng.Next(-7, 8);
			Instantiate(BuckShot, PlayerTrans.position, PlayerTrans.rotation * Quaternion.Euler(0, 0, 270 + randomOffset));
			randomOffset = rng.Next(15, 25);
			BuckShot.GetComponent<BulletMove>().MovementSpeed = randomOffset;
		}
	}
}
