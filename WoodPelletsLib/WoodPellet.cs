namespace WoodPelletsLib
{
    public class WoodPellet
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public int Price { get; set; }
        public int Quality { get; set; }

        private void ValidateBrand()
        {
            if (Brand == null) 
            {
                throw new ArgumentNullException("Brand is null");
            }
            if (Brand.Length < 2)
            {
                throw new ArgumentException("Brand is less than 2 characters");
            }
        }
        private void ValidatePrice() 
        {
            if(Price < 0) 
            {
                throw new ArgumentException("Price is a negative number");
            }
        }
        private void ValidateQuality()
        {
            if(Quality < 1) 
            {
                throw new ArgumentOutOfRangeException("Quality is less than 1");
            }
            if(Quality > 5) 
            {
                throw new ArgumentOutOfRangeException("Quality is greater than 5");
            }
        }
        public void Validate()
        {
            ValidateBrand();
            ValidatePrice();
            ValidateQuality();
        }
        public override string ToString()
        {
            return "ID: " + Id + " Brand: " + Brand + " Price: " + Price + " Quality: " + Quality;
        }
    }
}