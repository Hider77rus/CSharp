﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TuiWebService.Common.Models
{
    /// <summary>
    /// Ценовое предложение с учетом кол-ва людей
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// Отель
        /// </summary>
        public Hotel Hotel { get; set; }

        /// <summary>
        /// Название номера. Пусть пока строка. Вообще надо бы в отдельный класс выносить
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// Город отправление
        /// </summary>
        public City DepartureCity { get; set; }

        /// <summary>
        /// Дата вылета
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Дата прилёта
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Дата заселения
        /// </summary>
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// Кол-во ночей
        /// </summary>
        public int Nights { get; set; }

        /// <summary>
        /// Цена за одного человека
        /// </summary>
        public decimal PricePerPerson { get; set; }

        /// <summary>
        /// Авиокомпания
        /// </summary>
        public string Airline { get; set; }

        /// <summary>
        /// Максимальное кол-во человек в номере 
        /// </summary>
        public int MaxRoomPeople { get; set; }

        /// <summary>
        /// Кол-во человек
        /// </summary>
        public int PeopleCount { get; set; }

        /// <summary>
        /// Цена тура
        /// </summary>
        public decimal Price { get; set; }
    }
}
