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
    }
}
