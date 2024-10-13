using System;
using System.Collections.Generic;
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
            user1.AddFriend(user2);
            var tripService = new TripService();

            //ACT
            var result = tripService.GetTripsByUser(user2);

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<List<Trip.Trip>>(result);
        }
    }
}
