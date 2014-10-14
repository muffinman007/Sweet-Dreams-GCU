using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item> ();
	private bool showInventory;
	private ItemDataBase database;
	private bool showToolTip;
	private string tooltip;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < (slotsX * slotsY); i++) 
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}

		database = GameObject.FindGameObjectWithTag ("itemDataBase").GetComponent<ItemDataBase> ();
		AddItem (0);
		//inventory[0] = database.items[0];;
	}

	void Update()
	{
		if (Input.GetButtonDown("chest")) 
		{
			showInventory = !showInventory;
		}
	}

	void OnGUI()
	{
		tooltip = "";
		GUI.skin = skin;
		if (showInventory)
		{
			DrawInventory();
		}
		if (showToolTip) 
		{
			GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 200, 200), tooltip, skin.GetStyle("Tooltip"));
		}
	}

	void DrawInventory()
	{
		int i = 0;

		for (int y = 0; y < slotsY; y++)
		{
			for (int x = 0; x < slotsX; x++)
			{
				Rect slotRect = new Rect(x * 80, y * 80, 70, 70);
				GUI.Box(slotRect, "", skin.GetStyle("slot"));
				slots[i] = inventory[i];

				if(slots[i].itemName != null)
				{
					GUI.DrawTexture(slotRect, slots[i].itemIcon);
					if(slotRect.Contains(Event.current.mousePosition))
					{
						CreateToolTip(slots[i]);
						showToolTip = true;
					}
				}
				if(tooltip == "")
				{
					showToolTip = false;
				}

				i++;
			}
		}
	}

	string CreateToolTip(Item item)
	{
		tooltip = "<color=#ffffff>" + item.itemName + "</color>\n\n" + item.itemDesc;
		return tooltip;
	}

	void RemoveItem(int id)
	{
		for (int i=0; i<inventory.Count; i++) 
		{
			if (inventory[i].itemID == id)
			{
				inventory[i] = new Item();
				break;
			}
		}
	}

	void AddItem(int id)
	{
		for (int i = 0; i < database.items.Count; i++) 
		{
			if (inventory[i].itemName == null)
			{
				for (int j = 0; j < database.items.Count; j++)
				{
					if (database.items[j].itemID == id)
					{
						inventory[i] = database.items[j];
					}
					break;
				}
			}
			break;
		}
	}

	bool InventoryContains(int id)
	{
		bool result = false;

		for (int i=0; i < inventory.Count; i++)
		{
			result = inventory[i].itemID == id;
			if (result)
			{
				break;
			}
		}
		return result;
	}
}
