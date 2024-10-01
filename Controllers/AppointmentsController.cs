using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Wellness.Services;

namespace Wellness.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly FirestoreDb _firestoreDb;

        public AppointmentsController()
        {
            // Initialize Firestore
            _firestoreDb = FirestoreDb.Create("wellness-c3d08");
        }

        public async Task<IActionResult> Index()
        {
            var appointments = new List<Dictionary<string, object>>();

            // Fetch appointments from Firestore
            Query appointmentQuery = _firestoreDb.Collection("appointments");
            QuerySnapshot appointmentSnapshot = await appointmentQuery.GetSnapshotAsync();

            foreach (DocumentSnapshot document in appointmentSnapshot.Documents)
            {
                if (document.Exists)
                {
                    Dictionary<string, object> appointment = document.ToDictionary();
                    appointments.Add(appointment);
                }
            }

            // Pass the list of appointments to the view
            return View(appointments);
        }
    }
}
