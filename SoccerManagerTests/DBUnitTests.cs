using Microsoft.EntityFrameworkCore;
using System;
using TheDeltaSoccerManager.Controllers;
using TheDeltaSoccerManager.Models;
using Xunit;

namespace SoccerManagerTests
{
    public class UnitTest1
    {
        [Fact]
        public async void AddPlayerSucces()
        {
            var options = new DbContextOptionsBuilder<SoccerManagerContext>().UseInMemoryDatabase("SoccerManager").Options;

            var context = new SoccerManagerContext(options);

            var PlayersController = new PlayersController(context);

            Player new_player = new Player()
            {
                Name = "Duane",
                Surname = "de Villiers",
                Aggression = 99,
                BallControl = 99,
                Defence = 99,
                Height = "1.84",
                ShootingAccuracy = 99,
                Speed = 99
            };

            await PlayersController.PostPlayer(new_player);
            Assert.True(new_player.PlayerId > 0);
        }

        [Fact]
        public async void AddClubSucces()
        {
            var options = new DbContextOptionsBuilder<SoccerManagerContext>().UseInMemoryDatabase("SoccerManager").Options;

            var context = new SoccerManagerContext(options);

            var ClubsController = new ClubsController(context);

            Club new_club = new Club()
            {
                Name = "Arsenal"
            };

            await ClubsController.PostClub(new_club);
            Assert.True(new_club.ClubId > 0);
        }

        [Fact]
        public async void AddStadiumSucces()
        {
            var options = new DbContextOptionsBuilder<SoccerManagerContext>().UseInMemoryDatabase("SoccerManager").Options;

            var context = new SoccerManagerContext(options);

            var StadiumsController = new StadiumsController(context);

            Stadium new_stadium = new Stadium()
            {
                Name = "Emirates Stadium",
                Location = "London Borough of Islington, London, UK"
            };

            await StadiumsController.PostStadium(new_stadium);
            Assert.True(new_stadium.StadiumId > 0);
        }

        [Fact]
        public async void TransferPlayerToClubSuccessAsync()
        {
            var options = new DbContextOptionsBuilder<SoccerManagerContext>().UseInMemoryDatabase("SoccerManager").Options;

            var context = new SoccerManagerContext(options);

            var ClubsController = new ClubsController(context);

            var PlayersController = new PlayersController(context);

            Player new_player = new Player()
            {
                Name = "Duane",
                Surname = "de Villiers",
                Aggression = 99,
                BallControl = 99,
                Defence = 99,
                Height = "1.84",
                ShootingAccuracy = 99,
                Speed = 99
            };

            await PlayersController.PostPlayer(new_player);

            Club new_club = new Club()
            {
                Name = "Arsenal"
            };

            await ClubsController.PostClub(new_club);

            await ClubsController.AddPlayerToClub(new_club.ClubId, new_player.PlayerId);

            Assert.True(new_player.Club.ClubId == new_club.ClubId);
        }

        [Fact]
        public async void AddClubToStadiumSuccess()
        {
            var options = new DbContextOptionsBuilder<SoccerManagerContext>().UseInMemoryDatabase("SoccerManager").Options;

            var context = new SoccerManagerContext(options);

            var ClubsController = new ClubsController(context);

            var StadiumsController = new StadiumsController(context);

            Stadium new_stadium = new Stadium()
            {
                Name = "Emirates Stadium",
                Location = "London Borough of Islington, London, UK"
            };

            await StadiumsController.PostStadium(new_stadium);

            Club new_club = new Club()
            {
                Name = "Arsenal"
            };

            await ClubsController.PostClub(new_club);

            await StadiumsController.AddClubToStadium(new_stadium.StadiumId, new_club.ClubId);

            Assert.True(new_club.Stadium.StadiumId == new_stadium.StadiumId);
        }
    }
}
