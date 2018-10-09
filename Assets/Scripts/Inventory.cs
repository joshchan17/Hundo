using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private Dictionary<string, List<Item>> items;

	public Inventory() {
		items = new Dictionary<string, List<Item>>();
	}

	public void addItem(Item item) {
		List<Item> itemsWithID;

		if (items.TryGetValue(item.ID, out itemsWithID)) {
			itemsWithID.Add(item);
		} else {
			itemsWithID = new List<Item> { item };
			items.Add(item.ID, itemsWithID);
		}
	}

	public List<Item> getItems(string id) {
		return items[id];
	}

	public Item getFirstItem(string id) {
		return items[id].FirstOrDefault();
	}
}
