using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib
{
    public class WoodPelletRepository
    {
        private int _id = 1;
        private readonly List<WoodPellet> woodPellets = new List<WoodPellet>();

        public WoodPelletRepository() 
        {
            woodPellets.Add(new WoodPellet() { Id = _id++, Brand = "First Brand", Price = 100, Quality = 1});
            woodPellets.Add(new WoodPellet() { Id = _id++, Brand = "Second Brand", Price = 200, Quality = 2 });
            woodPellets.Add(new WoodPellet() { Id = _id++, Brand = "Third Brand", Price = 300, Quality = 3 });
            woodPellets.Add(new WoodPellet() { Id = _id++, Brand = "Foruth Brand", Price = 400, Quality = 4 });
            woodPellets.Add(new WoodPellet() { Id = _id++, Brand = "Fifth Brand", Price = 500, Quality = 5 });
        }
        public List<WoodPellet> GetAll()
        {
            return new List<WoodPellet>(woodPellets);
        }
        public WoodPellet? GetById(int id)
        {
            WoodPellet? woodPellet = woodPellets.Where(wp => wp.Id == id).FirstOrDefault();
            if (woodPellet == null)
            { 
                return null;
            }
            return woodPellet;
        }
        public void Add(WoodPellet woodPellet)
        {
            woodPellet.Validate();
            woodPellet.Id = _id++;
            woodPellets.Add(woodPellet);
        }
        public void Update(WoodPellet woodPellet, int id)
        {
            woodPellet.Validate();
            WoodPellet? wp = GetById(id);
            if(wp == null)
            {
                throw new ArgumentOutOfRangeException("Woodpellet is not found");
            }
            wp.Brand = woodPellet.Brand;
            wp.Price = woodPellet.Price;
            wp.Quality = woodPellet.Quality;
        }
    }
}
