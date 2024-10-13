using TripServiceKata.Exception;

namespace TripServiceKata.User
{
    public class UserSession
    {
        private static readonly UserSession userSession = new UserSession();

        private UserSession() { }

        public User LoggedInUser { get; set; }

        public static UserSession GetInstance()
        {
            return userSession;
        }

        public bool IsUserLoggedIn(User user)
        {
            //throw new DependendClassCallDuringUnitTestException(
            //    "UserSession.IsUserLoggedIn() should not be called in an unit test");
            return user == LoggedInUser;
        }

        public User GetLoggedUser()
        {
            //throw new DependendClassCallDuringUnitTestException(
            //    "UserSession.GetLoggedUser() should not be called in an unit test");
            return LoggedInUser;
        }
        //Set User for Logged in
        public void SetLoginUser(User user)
        {
            LoggedInUser = user;
        }

    }
}
