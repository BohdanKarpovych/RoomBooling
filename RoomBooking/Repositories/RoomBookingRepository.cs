﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoomBooking.Models;
using System.Data.Entity;

namespace RoomBooking.Repositories
{
    public class RoomBookingRepository : IRoomBookingRepository
    {
        private RoomBookingContext db;

        public RoomBookingRepository()
        {
            db = new RoomBookingContext();
        }

        public List<Room> GetRoomList()
        {
            return db.Rooms.ToList();
        }

        public Room GetRoom(int id)
        {
            return db.Rooms.Find(id);
        }

        public List<Booking> GetBookingList()
        {
            return db.Bookings.ToList();
        }

        public Booking GetBooking(int id)
        {
            return db.Bookings.Find(id);
        }

        public bool Create(Room room)
        {
            db.Rooms.Add(room);
            return true;
        }
        public bool Create(Booking booking)
        {
            db.Bookings.Add(booking);
            return true;
        }

        public bool Update(Room room)
        {
            db.Entry(room).State = EntityState.Modified;
            return true;
        }

        public bool Update(Booking booking)
        {
            db.Entry(booking).State = EntityState.Modified;
            return true;
        }

        public bool Delete(Room room)
        {
            db.Rooms.Remove(room);
            return true;
        }

        public bool Delete(Booking booking)
        {
            db.Bookings.Remove(booking);
            return true;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}