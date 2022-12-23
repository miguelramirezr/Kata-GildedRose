using GildedRoseClass;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace GildedRoseTest
{
    [TestClass]
    public class GildenRoseTest
    {

        [TestMethod]
        public void WhenGivenProductReturnsUpdatedQualityValue()
        {
            /*Cada dia la calidad disminuye en 1*/
            Product myproduct = new Product("Bred", 35, 40);
            myproduct.UpdateProduct();
            Assert.AreEqual(39, myproduct.Quality);
        }


        [TestMethod]
        public void WhenGivenProductReturnsUpdatedSellInValue()
        {
            /*Cada dia el sellin disminuye en 1*/
            Product myproduct = new Product("Bred", 35, 40);
            myproduct.UpdateProduct();
            Assert.AreEqual(34, myproduct.SellIn);
        }

        [TestMethod]
        public void QualityOfItemCantBeNegative()
        {
            /*La calidad de un artículo nunca es negativa*/
            Product prod = new Product("Gouda Cheese", 16, -2);
            prod.UpdateProduct();
            Assert.AreEqual(0, prod.Quality);

        }
        [TestMethod]
        public void WhenTheRecommendedDateIsPast()
        {
            /*Una vez que ha pasado la fecha recomendada de venta (SellIn = 0 o menos),
              la calidad se degrada al doble de velocidad*/
            Product prod = new Product("X Cheese", 0, 4);
            prod.UpdateProduct();
            Assert.AreEqual(2, prod.Quality);
        }

        [TestMethod]
        public void WhenTheCheeseIsBrie()
        {
            /*El queso Brie incrementa su calidad a medida que se pone viejo*/
            Product prod = new Product("Aged Brie", 12, 4);
            prod.UpdateProduct();
            Assert.AreEqual(5, prod.Quality);

        }

        [TestMethod]
        public void QualityOfAnItemIsNeverMoreThan50()
        {
            /*La calidad de un articulo nunca es mayor a 50*/
            Product prod = new Product("Aged Brie", 12, 60);
            prod.UpdateProduct();
            Assert.AreEqual(50, prod.Quality);
        }

        [TestMethod]
        public void WhenTheItemIsSulfuras()
        {
            /*Sulfuras al ser un item legendario nunca modifica su calidad ni modifica su fecha de venta*/
            Product prod = new Product("Sulfuras", 12, 80);
            prod.UpdateProduct();
            Assert.AreEqual(80, prod.Quality);
        }
        [TestMethod]
        public void WhenTheItemisBackstagePassesAndThereAreTenDaysOrLess()
        {
            /*Una "Backstage passes", como el queso brie, incrementa su calidad a medida 
             que la fecha de venta se aproxima*/
            /*si faltan 10 días o menos la calidad se incrementa en 2 unidades*/
            Product prod = new Product("Backstage passes", 10, 40);
            prod.UpdateProduct();
            Assert.AreEqual(42, prod.Quality);
        }

        [TestMethod]
        public void WhenTheItemisBackstagePassesAndThereAreFiveDaysOrLess()
        {
            /*Una "Backstage passes", como el queso brie, incrementa su calidad a medida 
             que la fecha de venta se aproxima*/
            /*si faltan 5 días o menos la calidad se incrementa en 3 unidades*/
            Product prod = new Product("Backstage passes", 4, 40);
            prod.UpdateProduct();
            Assert.AreEqual(43, prod.Quality);
        }

        [TestMethod]
        public void WhenTheItemIsConjured()
        {
            /*Los artículos Conjured degradan su calidad al doble de velocidad que los normales*/
            Product prod = new Product("Conjured", 25, 40);
            prod.UpdateProduct();
            Assert.AreEqual(38, prod.Quality);
        }


        [TestMethod]
        public void WhenTheItemIsSulfurasAndQualityIsLessThan80()
        {
            /*Sulfuras siendo un artículo legendario posee una calidad inmutable de 80 en calidad*/
            Product prod = new Product("Sulfuras", 12, 70);
            string message = string.Empty;
            try
            {
                prod.UpdateProduct();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid Data", message);
        }
    }
}