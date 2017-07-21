using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
	public List<BaseStat> Stats { get; set; } //Items will have their own base stats
	//helps us find the right item, even if the models/prefabs are the same between items
	public string ObjectSlug { get; set; } //name of the prefab?

	//define an objects stats and objectslug
	public Item(List<BaseStat> _Stats, string _ObjectsSlug)
	{
		this.Stats = _Stats;
		this.ObjectSlug = _ObjectsSlug;
	}
}
