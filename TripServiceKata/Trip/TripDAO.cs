﻿using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
    public class TripDAO
    {
        public static List<Trip> FindTripsByUser(User.User user)
        {
            return user.Trips();
            //throw new DependendClassCallDuringUnitTestException(
            //            "TripDAO should not be invoked on an unit test.");
        }
    }
}
