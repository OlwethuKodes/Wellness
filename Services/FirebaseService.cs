using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System.IO;

namespace Wellness.Services
{
    public class FirebaseService
    {
        public FirebaseService()
        {
            InitializeFirebase();
        }

        private void InitializeFirebase()
        {
            string path = "wellness-c3d08-firebase-adminsdk-x7j9t-877be8bc12.json"; 

            if (File.Exists(path))
            {
                GoogleCredential credential = GoogleCredential.FromFile(path);
                FirestoreDb.Create("wellness-c3d08");
            }
            else
            {
                throw new FileNotFoundException("Firebase credentials file not found.");
            }
        }

    }
}
