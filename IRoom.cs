using Hospital_Managment_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System
{
    public interface IRoom
    {
        Task<List<Room>> GetRooms();

        Task<Room> GetRoomById();

        Task<Room> AddRoom();

        Task UpdateRoom();

        Task DeleteRoom();
    }
}
