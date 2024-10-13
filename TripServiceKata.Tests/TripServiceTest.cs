using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using TripServiceKata.Trip;
using TripServiceKata.User;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceTest
    {
        [Fact]
        public void TestGetFriends()
        {
            //ARRANGE setup
            var user = new User.User();

            //ACT die durchführung der getesteten Methode
            var listFriends = user.GetFriends();

            //ASSERTS abfrage
            Assert.NotNull(listFriends);
            Assert.Empty(listFriends);
            Assert.IsType<List<User.User>>(listFriends);
        }
        [Fact]
        public void TestUserIsNotFriend()
        {
            //ARRANGE
            var user1 = new User.User();
            UserSession.GetInstance().SetLoginUser(user1);
            user1.AddFriend(new User.User());
            var user2 = new User.User();
            var tripService = new TripService();
            
            //ACT
            var result = tripService.GetTripsByUser(user2);

            //ASSERT
            Assert.Null(result);

        }
        [Fact]
        public void TestUserIsFriend()
        {

            //ARRANGE
            var user1 = new User.User();
            UserSession.GetInstance().SetLoginUser(user1);
            var user2 = new User.User();
            user2.AddFriend(user1);
            var tripService = new TripService();

            //ACT
            var result = tripService.GetTripsByUser(user2);

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<List<Trip.Trip>>(result);
        }
        
        [Fact]
        public void TestAddFriend()
        {  
            //ARRANGE
            var user1 = new User.User();

            //ACT
            user1.AddFriend(new User.User());

            //ASSERT
            Assert.Single(user1.GetFriends()); //single = Liste ist 1 lang
        
        }
        [Fact]
        public void TestAddTrip()
        {
            //ARRANGE
            var user1 = new User.User();

            //ACT
            user1.AddTrip(new Trip.Trip());

            //ASSERT
            Assert.Single(user1.Trips()); 

        }

    }

}
