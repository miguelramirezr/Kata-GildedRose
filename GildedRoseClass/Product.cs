namespace GildedRoseClass
{
    public class Product
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public Product(string name, int sellin, int quality)
        {
            Name = name;
            SellIn = sellin;
            Quality = quality;
        }

        public void UpdateProduct()
        {
            SellIn--;

            // Si el item es "Sulfuras", no hacemos nada
            if (Name == "Sulfuras")
            {
                if(Quality < 80)
                {
                    throw new Exception("Invalid Data");
                }
                else
                {
                    return;
                }
            }

            // Si el item es "Aged Brie", aumentamos su calidad
            else if (Name == "Aged Brie")
            {
                Quality++;
            }
            // Si el item es "Aged Brie", aumentamos su calidad

            else if (Name == "Backstage passes")
            {
                // Incrementar la calidad en 2 unidades si faltan 10 días o menos
                if (SellIn <= 10 && SellIn >= 6)
                {
                    Quality += 2;
                }
                // Incrementar la calidad en 3 unidades si faltan 5 días o menos
                else if (SellIn <= 5)
                {
                    Quality += 3;
                }
                // Si ha pasado la fecha de vencimiento, poner la calidad en 0
                else if (SellIn < 0)
                {
                    Quality = 0;
                }
            }
            else if (Name == "Conjured")
            {
                Quality -= 2;
            }
            else
            {
                // Decrementamos la calidad del artículo
                Quality--;

                // Si la fecha de venta ha pasado, decrementamos su calidad doblemente
                if (SellIn <= 0)
                {
                    Quality--;
                }
            }

            //// Asegurarse de que la calidad del producto no sea negativa ni mayor a 50
            Quality = Math.Max(Quality, 0);
            Quality = Math.Min(Quality, 50);
        }
    }
}