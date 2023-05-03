using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> items)
    {
        Items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        if (item.Name.StartsWith("Conjured"))
                        {
                            item.Quality -= 2;
                        }
                        else
                        {
                            item.Quality -= 1;
                        }
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn -= 1;
            }

            if (item.SellIn >= 0) continue;
            if (item.Name != "Aged Brie")
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality <= 0) continue;
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality -= 1;
                    }
                }
                else
                {
                    item.Quality -= item.Quality;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }
    }
}