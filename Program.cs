using Hospital_Managment_System.Controler;

Dictionary<int,string> options =  new Dictionary<int,string>();
options.Add(1, "Patient Dashboard");
options.Add(2, "Doctor Dashboard");
options.Add(3, "Appointment Dashboard");
options.Add(4, "Room Dashboard");


Console.WriteLine("Welcome to Our Hospital Management System, Choose Various options");

foreach (var option in options)
{
    Console.WriteLine($"{option.Key}:{option.Value}");   
}

int userOpt = int.Parse(Console.ReadLine());
if(userOpt == 1)
{
    PatientControler patientControler = new PatientControler();
    patientControler.patientDashboard();
}else if (userOpt == 2)
{
    DoctorControler doctorControler = new DoctorControler();
    doctorControler.doctorDashboard();
}else if (userOpt == 3)
{
    AppointmentControler appointmentControler = new AppointmentControler();
    appointmentControler.AppointmentDashboard();
}else if (userOpt == 4)
{
    RoomControler roomControler = new RoomControler();
    roomControler.roomDashboard();
}