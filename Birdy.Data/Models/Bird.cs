using System;

namespace Birdy.Data.Models
{
    public class Bird
    {
        public Bird()
        {
            this.Id = Guid.NewGuid();
            this.Name = "My new bird";
            this.Length = 0.0m;
            this.Type = BirdType.Garden;
            this.Description = "Information about the bird";
            this.BaseColor = "Black";
            this.Picture = "Images/default.jpg";
            this.SightingsCount = 0;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Length { get; set; }

        public BirdType Type { get; set; }

        public string Description { get; set; }

        public string BaseColor { get; set; }

        public string Picture { get; set; }

        public int SightingsCount { get; set; }
    }
}
