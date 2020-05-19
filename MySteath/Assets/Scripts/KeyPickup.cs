using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour
{
	public AudioClip keyGrab;    // 当角色拿到钥匙卡时播放的音频

	private GameObject player;  //角色对象
	private PlayerInventory playerInventory; // 管理角色钥匙卡状态的PlayerInventory对象

	void Awake()
	{
		player = GameObject.FindWithTag(Tags.Player);
		playerInventory = player.GetComponent<PlayerInventory>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			AudioSource.PlayClipAtPoint(keyGrab, transform.position);
			playerInventory.hasKey = true;

			Destroy(gameObject);
		}
	}
}
