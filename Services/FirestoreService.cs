using Google.Cloud.Firestore;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Wellness.Services
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;

        public FirestoreService(FirebaseService firebaseService)
        {
            _firestoreDb = FirestoreDb.Create("wellness-c3d08"); 
        }

        public async Task<List<Dictionary<string, object>>> GetAppointmentsAsync()
        {
            var appointments = new List<Dictionary<string, object>>();
            Query appointmentQuery = _firestoreDb.Collection("appointments");
            QuerySnapshot appointmentSnapshot = await appointmentQuery.GetSnapshotAsync();

            foreach (DocumentSnapshot document in appointmentSnapshot.Documents)
            {
                appointments.Add(document.ToDictionary());
            }

            return appointments;
        }
    }
}
