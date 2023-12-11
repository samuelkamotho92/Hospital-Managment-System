using Hospital_Managment_System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Services
{
    public class RoomService : IRoom
    {
        HospitalDBContext hospitalDBContext = new HospitalDBContext();
        public async Task<Room> AddRoom()
        {
            Console.WriteLine("CREATE ROOM");

            Console.WriteLine("Enter Room Number");
            string roomNum = Console.ReadLine();
            Console.WriteLine("Enter Room Type");
            string roomType = Console.ReadLine();

            Room room = new Room() {
            RoomNumber = roomNum,
            RoomType = roomType
            };

            hospitalDBContext.Rooms.Add(room);
            hospitalDBContext.SaveChanges();
            Console.WriteLine("Successfully created room");
            return room;
        }

        public async Task DeleteRoom()
        {
            try
            {
                Console.WriteLine("Enter room you want to delete");
                int roomId = int.Parse(Console.ReadLine());
                Console.WriteLine(roomId);
                var room = (Room)hospitalDBContext.Rooms.Where(x => x.RoomId == roomId);
                hospitalDBContext.Rooms.Remove(room);
                hospitalDBContext.SaveChanges();
                Console.WriteLine("Room deleted Successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
          
        }

        public async Task<Room> GetRoomById()
        {
            Console.WriteLine("Enter any room you want to check");
            int roomVal = int.Parse(Console.ReadLine());
            Room room = await hospitalDBContext.Rooms.FindAsync(roomVal);
            Console.WriteLine();
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
           List<Room> roomList = hospitalDBContext.Rooms.Include(x=>x.Patients).ToList();
            foreach (var room in roomList)
            {
              
                Console.WriteLine($"{room.RoomId} : {room.RoomNumber} :{room.RoomType}");
                List<Patient> patients = room.Patients.ToList();
                foreach (var pat in patients)
                {
                    Console.WriteLine($"patients in this {room.RoomType} are:");
                    Console.WriteLine($"{pat.FirstName}:{pat.LastName}");
                }
            }
            return roomList;
        }

        public async  Task<Room> UpdateRoom()
        {
            Room room = new Room();
            try
            {
                Console.WriteLine("Enter Id of Room you want to update");
                int roomId = int.Parse(Console.ReadLine());
                room =  (Room)hospitalDBContext.Rooms.Where(x=>x.RoomId == roomId);
                room.RoomNumber = "4";
                room.RoomType = "Store";
                hospitalDBContext.SaveChanges();
                Console.WriteLine("Successfuly Updated");
                return room;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return room;
        }
    }
}
