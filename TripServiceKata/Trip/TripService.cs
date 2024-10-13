using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            //List<Trip> tripList = new List<Trip>(); -> braucht man nicht mehr
            User.User loggedUser = UserSession.GetInstance().GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                foreach(var friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }
                if (isFriend)
                {
                    //tripList = TripDAO.FindTripsByUser(user); direkt returnen
                    return TripDAO.FindTripsByUser(user);

                }
                //return tripList; auf null setzen, wenn is not friend
                return null;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}
