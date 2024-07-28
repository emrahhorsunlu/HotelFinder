﻿using HotelFinder.DataAccess;
using HotelFinder.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Reservation.Business.Abstract;
using Reservation.DataAccess;
using Reservation.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private IReservationRepository _reservationRepository;
        private IHotelRepository _hotelRepository;

        public ReservationManager(IReservationRepository reservationRepository, IHotelRepository hotelRepository)
        {
            _reservationRepository = reservationRepository;
            _hotelRepository = hotelRepository;
        }
        public Entities.Reservation CreateReservation(Entities.Reservation reservation)
        {
            var hotel = _hotelRepository.GetHotelById(reservation.HotelId);
            if(hotel != null) {
                return _reservationRepository.CreateReservation(reservation);
            }
            return null;
        }

        public void DeleteReservation(int id)
        {
            _reservationRepository.DeleteReservation(id);
        }

        public List<Entities.Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }

        public Entities.Reservation GetReservationById(int id)
        {
            return _reservationRepository.GetReservationById(id);
        }

        public List<Entities.Reservation> GetReservationByStatus(bool status)
        {
            return _reservationRepository.GetReservationByStatus(status);
        }

        public List<Entities.Reservation> GetReservationsByHotelId(int id)
        {
            return _reservationRepository.GetReservationsByHotelId(id);
        }

        public Entities.Reservation UpdateReservation(Entities.Reservation reservation)
        {
            return _reservationRepository.UpdateReservation(reservation);
        }
    }
}
