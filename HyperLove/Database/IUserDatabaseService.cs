using HyperLove.Models.User;
using System.Threading.Tasks;

namespace HyperLove.Database
{
    public interface IUserDatabaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Holds all the data about the user</param>
        void CreateUser(UserProfile user);

        void UpdateUser(UserProfile user);

        /// <summary>
        /// This will delete the user from our database forever
        /// </summary>
        /// <param name="userBase">To get the base info about the user</param>
        void DeleteUser(UserBase userBase);

        /// <summary>
        /// This will disable the users account until they decide to enable the account back
        /// It will disable all the features such as editing the profile, viewing profiles etc.
        /// When the app is opened they will be prompted with a button in the middle of the screen to enable the account.
        /// </summary>
        /// <param name="userBase">To get the base info about the user</param>
        void DisableUser(UserBase userBase);

        /// <summary>
        /// Checking if a user exists in the firestore database by using the id storred on the device
        /// </summary>
        /// <param name="user">Storing the user info that we found</param>
        /// <param name="user_id">Passing the user_id</param
        /// <returns>Checking if the user</returns>
        void LookingForUser(string user_id);

        void LikedPerson(string userID, string likedPersonID);

        void LovedPerson(string userID, string lovedPersonID);

        void DislikedPerson(string userID, string dislikedPersonID);

        void MatchedPerson(string userID, string matchedPersonID);
    }
}
