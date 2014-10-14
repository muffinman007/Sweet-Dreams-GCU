using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDataBase : MonoBehaviour {
	public List<Item> items = new List<Item> ();

	void start()
	{
		items.Add (new Item ("sword",0,"A sword to slash",2,1,Item.ItemType.Weapon));
	}
}
