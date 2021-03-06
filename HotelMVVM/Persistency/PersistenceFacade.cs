﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HotelMVVM.Model;
using Newtonsoft.Json;

namespace HotelMVVM.Persistency
{
    class PersistenceFacade
    {
        const string ServerUrl = "http://localhost:5645";
        HttpClientHandler handler;

        public PersistenceFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }


        public List<Hotel> GetHotels()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotelList = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        return hotelList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        public void DeleteHotel(Hotel selectedHotel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var hotel = selectedHotel.Hotel_No;
                try
                {
                    string deleteUrl = "api/Hotels/" + hotel;
                    var response = client.DeleteAsync(deleteUrl).Result;

                    
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                
            };
        }

        public void SaveHotel(Hotel hotel)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    string postBody = JsonConvert.SerializeObject(hotel);
                    var response = client.PostAsync("api/Hotels", new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }

                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }

        }

        public List<Room> GetRooms()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Rooms").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var roomList = response.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                        return roomList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        public void DeleteRoom(Room selectedRoom)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var room = selectedRoom.Room_No;
                try
                {
                    string deleteUrl = "api/Rooms/" + room;
                    var response = client.DeleteAsync(deleteUrl).Result;


                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            };
        }

        public void SaveRoom(Room room)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    string postBody = JsonConvert.SerializeObject(room);
                    var response = client.PostAsync("api/Rooms", new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }

                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }

        }

    }
}
