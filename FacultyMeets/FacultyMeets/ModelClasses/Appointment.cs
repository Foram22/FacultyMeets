using System;
namespace FacultyMeets.ModelClasses
{
	public class Appointment
	{
        public string FacultyId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string StudentId { get; set; }
    }
}

