﻿using API.DTOs.Employee;
using API.DTOs.Rooms;
using API.Models;
using Client.Contracts;

namespace Client.Repositories
{
    public class RoomRepository : GeneralRepository<Room, Guid>, IRoomRepository
    {
        public RoomRepository(string request="rooms/") : base(request)
        {
        }
    }
}
