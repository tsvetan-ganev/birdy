namespace Birdy.Data.Services
{
    using System;
    using System.Collections.Generic;
    using Models;
    using ViewModels;

    public sealed class BirdsService
    {
        private static readonly Lazy<BirdsService> LAZY = new Lazy<BirdsService>(
                                                            () => new BirdsService());

        private List<Bird> birds;

        private BirdsService()
        {
            this.birds = new List<Bird>
            {
                new Bird
                {
                    Name = "Pink-footed Goose",
                    Length = 60,
                    Type = BirdType.Wild,
                    Description = "A goose which breeds in eastern Greenland, Iceland and Svalbard.",
                    Picture = "Images/pink-footed-goose.jpg"
                },
                new Bird
                {
                    Name = "Brant Goose",
                    Length = 55,
                    Type = BirdType.Wild,
                    Description = "The brant or brent goose (Branta bernicla) is a species of goose of the genus Branta.",
                    Picture = "Images/brant-goose.jpg",
                },
                new Bird
                {
                    Name = "European Starling",
                    Length = 20,
                    Type = BirdType.Garden,
                    Description = "This bird is resident in southern and western Europe and southwestern Asia, while northeastern populations migrate south and west in winter within the breeding range and also further south to Iberia and North Africa.",
                    Picture = "Images/european-starling.jpg"
                },
                new Bird
                {
                    Name = "Northern Lapwing",
                    Length = 33,
                    Type = BirdType.Wild,
                    Description = "In winter, it forms huge flocks on open land, particularly arable land and mud-flats.",
                    Picture = "Images/northern-lapwing.jpg"
                },
                new Bird
                {
                    Name = "Little Gull",
                    Length = 25,
                    Type = BirdType.Wild,
                    BaseColor = "White",
                    Description = "The little gull (Hydrocoloeus minutus or Larus minutus), is a small gull that breeds in northern Europe and Asia. It also has small colonies in parts of southern Canada.",
                    Picture = "Images/little-gull.jpg"
                },
                new Bird
                {
                    Name = "Common Crane",
                    Length = 130,
                    Type = BirdType.Wild,
                    BaseColor = "Gray",
                    Description = "The common crane (Grus grus), also known as the Eurasian crane, is a bird of the family Gruidae, the cranes.",
                    Picture = "Images/common-crane.jpg"
                },
                new Bird
                {
                    Name = "Redwing",
                    Length = 24,
                    Type = BirdType.Raptor,
                    BaseColor = "Red",
                    Description = "The redwing (Turdus iliacus) is a bird in the thrush family, Turdidae, native to Europe and Asia, slightly smaller than the related song thrush.",
                    Picture = "Images/redwing.jpg"
                },
                new Bird
                {
                    Name = "Eurasian Coot",
                    Length = 42,
                    Type = BirdType.Wild,
                    Description = "The Eurasian coot (Fulica atra), also known as coot, is a member of the rail and crake bird family, the Rallidae. It is found in Europe, Asia, Australia and parts of Africa.",
                    Picture = "Images/eurasian-coot.jpg"
                },
                new Bird
                {
                    Name = "Pigeon",
                    Length = 37,
                    Type = BirdType.Pet,
                    BaseColor = "Gray",
                    Description = "It has been bred into several varieties kept by hobbyists, of which the best known is the homing pigeon or racing homer.",
                    Picture = "Images/pigeon.jpg"
                },
                new Bird
                {
                    Name = "Hawk",
                    Length = 28,
                    Type = BirdType.Raptor,
                    BaseColor = "Brown",
                    Description = "Hawks have always been known to have sharp vision and to be very able hunters. Within the hawk species, the female is generally larger than the male.",
                    Picture = "Images/hawk.jpg"
                },
            };
        }

        public static BirdsService Instance
        {
            get { return LAZY.Value; }
        }

        public IList<Bird> Birds
        {
            get
            {
                return this.birds.AsReadOnly();
            }
        }

        public void AddBird(BirdEntryViewModel bird)
        {
            var birdModel = new Bird()
            {
                Id = bird.Id,
                Name = bird.Name,
                Description = bird.Description,
                Length = bird.Length,
                BaseColor = bird.BaseColor,
                Type = bird.Type,
                Picture = bird.Picture,
                SightingsCount = 0
            };

            this.birds.Add(birdModel);
        }

        public void RemoveBird(Guid id)
        {
            var birdToRemove = this.birds.Find(b => b.Id == id);

            if (birdToRemove != null)
            {
                this.birds.Remove(birdToRemove);
            }
        }

        public void UpdateBirdSightingsCount(BirdSightingViewModel bird)
        {
            var birdToUpdate = this.birds.Find(b => b.Id == bird.Id);

            if (birdToUpdate != null)
            {
                birdToUpdate.SightingsCount = bird.Count;
            }
        }

        public bool UpdateBird(BirdEntryViewModel bird)
        {
            Bird birdToUpdate = this.birds.Find(b => b.Id == bird.Id);

            if (birdToUpdate != null)
            {
                birdToUpdate.Id = bird.Id;
                birdToUpdate.Name = bird.Name;
                birdToUpdate.BaseColor = bird.BaseColor;
                birdToUpdate.Description = bird.Description;
                birdToUpdate.Length = bird.Length;
                birdToUpdate.Type = bird.Type;
                birdToUpdate.Picture = bird.Picture;

                return true;
            }

            return false;
        }
    }
}
