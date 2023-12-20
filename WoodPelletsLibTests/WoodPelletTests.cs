using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoodPelletsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib.Tests
{
    [TestClass()]
    public class WoodPelletTests
    {
        private static WoodPelletRepository _repository;

        [ClassInitialize]
        public static void Setup(TestContext context) 
        {
            _repository = new WoodPelletRepository();
        }

        [TestMethod()]
        public void ValidateBrandNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new WoodPellet() { Brand = null, Price = 100, Quality = 1 }.Validate());
        }

        [TestMethod()]
        public void ValidateBrandOneCharacter()
        {
            Assert.ThrowsException<ArgumentException>(() => new WoodPellet() { Brand = "a", Price = 100, Quality = 1 }.Validate());
        }
        [TestMethod()]
        public void ValidateBrandTwoCharacters()
        {
            WoodPellet woodPellet = new WoodPellet() { Brand = "ab", Price = 100, Quality = 1 };
            woodPellet.Validate();
            Assert.AreEqual("ab",woodPellet.Brand);
        }

        [TestMethod()]
        public void ValidateQualityBelowOne()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new WoodPellet() { Brand = "Brand", Price = 100, Quality = 0 }.Validate());
        }

        [TestMethod()]
        public void ValidateQualityAboveFive()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new WoodPellet() { Brand = "Brand", Price = 100, Quality = 6 }.Validate());
        }
        [TestMethod()]
        public void ValidateQualityFifthQuality()
        {
            WoodPellet woodPellet = new WoodPellet() { Brand = "Brand", Price = 100, Quality = 5 };
            woodPellet.Validate();
            Assert.AreEqual(5, woodPellet.Quality);
        }
        [TestMethod()]
        public void ValidateQualityThirdQuality()
        {
            WoodPellet woodPellet = new WoodPellet() { Brand = "Brand", Price = 100, Quality = 1 };
            woodPellet.Validate();
            Assert.AreEqual(1, woodPellet.Quality);
        }
    }
}