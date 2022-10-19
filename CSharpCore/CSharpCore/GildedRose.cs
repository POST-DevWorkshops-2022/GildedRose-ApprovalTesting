using System.Collections.Generic;

namespace CSharpCore
{
    public class GildedRose
    {
        private IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                DoUpdateQuality(Items[i]);
            }
        }

        private static void DoUpdateQuality(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                {
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }

                    item.SellIn--;

                    if (item.SellIn < 0)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }

                    break;
                }
                case "Backstage passes to a TAFKAL80ETC concert":
                {
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;

                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < 6 && item.Quality < 50)
                            {
                                item.Quality++;
                            }
                        }
                    }

                    item.SellIn--;

                    if (item.SellIn < 0)
                    {
                        item.Quality -= item.Quality;
                    }

                    break;
                }
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                {
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }

                    item.SellIn--;

                    if (item.SellIn < 0 && item.Quality > 0)
                    {
                        item.Quality--;
                    }

                    break;
                }
            }
        }
    }
}