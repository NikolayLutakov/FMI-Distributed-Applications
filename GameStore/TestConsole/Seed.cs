using GameStore.Services;
using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public static class Seed
    {
        
        public static void CreateUsers()
        {
            var service = new UserService();
            var random = new Random();

            
            for (int i = 0; i < 10; i++)
            {
                var user = new CreateUserDto
                {
                    Username = "Test User" + i,
                    FullName = "Full Name" + i,
                    Age = random.Next(1, 80),
                    Email = "Test@mail.com" + i
                };

                Console.WriteLine(service.CreateUser(user));
            }
        }

        public static void CreateCards()
        {
            var userService = new UserService();
            var service = new CardService();
            var random = new Random();
            var userIds = userService.GetAllUsers().Select(x => x.Id).ToList();

            for (int i = 0; i < 10; i++)
            {
                var card = new CreateCardDto
                {
                    Number = $"{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}",
                    Cvc = $"{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}",
                    TypeId = random.Next(1, 2),
                    UserId = userIds[random.Next(0, userIds.Count() - 1)]
                };

                Console.WriteLine(service.CreateCard(card));
            }
        }

        public static void CreateGenres()
        {
            
            var service = new GenreService();          

            for (int i = 0; i < 5; i++)
            {
                var genre = new CreateGenreDto
                {
                    Name = "Genre" + (i + 1)
                };

                Console.WriteLine(service.CreateGenre(genre));
            }
        }

        public static void CreateDevs()
        {

            var service = new DeveloperService();

            for (int i = 0; i < 5; i++)
            {
                var dev = new CreateDeveloperDto
                {
                    Name = "Developer" + (i + 1)
                };

                Console.WriteLine(service.CreateDeveloper(dev));
            }
        }

        public static void CreateGames()
        {
            var devService = new DeveloperService();
            var genreService = new GenreService();
            var service = new GameService();

            var random = new Random();

            var devIds = devService.GetAllDevelopers().Select(x => x.Id).ToList();
            var genreIds = genreService.GetAllGenres().Select(x => x.Id).ToList();

            for (int i = 0; i < 5; i++)
            {
                var game = new CreateGameDto
                {
                    Name = "Game" + (i + 1),
                    Price = 10.00m + random.Next(1, 100),
                    ReleaseDate = DateTime.UtcNow.AddDays(-random.Next(20, 500)).ToString(),
                    DeveloperId = devIds[random.Next(0, devIds.Count() - 1)],
                    GenreId = genreIds[random.Next(0, devIds.Count() - 1)]
                };

                Console.WriteLine(service.CreateGame(game));
            }
        }

        public static void CreatePurchases()
        {
            var gameService = new GameService();
            var cardService = new CardService();
            var service = new PurchaseService();

            var random = new Random();

            var cardIds = cardService.GetAllCards().Select(x => x.Id).ToList();
            var gameIds = gameService.GetAllGames().Select(x => x.Id).ToList();

            for (int i = 0; i < 20; i++)
            {
                var purchase = new CreatePurchaseDto
                {
                    ProductKey = $"pur{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}",
                    CardId = cardIds[random.Next(0, cardIds.Count() - 1)],
                    GameId = gameIds[random.Next(0, gameIds.Count() - 1)],
                    TypeId = random.Next(1, 2)
                    
                };

                Console.WriteLine(service.CreatePurchase(purchase));
            }
        }

        public static void CreateTags()
        {

            var service = new TagService();

            for (int i = 0; i < 20; i++)
            {
                var tag = new CreateTagDto
                {
                    Name = "Tag" + (i + 1)
                };

                Console.WriteLine(service.CreateTag(tag));
            }
        }

        public static void AddTagsToGame()
        {
            var gameService = new GameService();
            var service = new TagService();

            var tags = service.GetAllTags().Select(x => x.Id).ToList();
            var games = gameService.GetAllGames().Select(x => x.Id).ToList();

            foreach (var game in games)
            {
                var random = new Random();
                for (int i = 0; i < random.Next(1, 5); i++)
                {
                    Console.WriteLine(service.AddTagToGame(tags[random.Next(0, tags.Count() - 1)], game));
                }                
            }
            
        }
    }
}
