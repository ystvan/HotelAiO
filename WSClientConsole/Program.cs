using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebServiceDemo;

namespace WSClientConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {


            Console.Write(
                "1.List hotels\n2.Select a hotel\n3.List all hotels in Roskilde\n4.List all single rooms for hotels in Roskilde\n5.Update holtel_No 3\n6.Insert a new hotel");
            Console.Write("\n7.Delete a hotel\n8.Update Room prices\n0.End\nPlease enter your choice:");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        Exercise1();
                        break;
                    case 2:
                        Exercise2();
                        break;
                    case 3:
                        Exercise3();
                        break;
                    case 4:
                        Exercise4();
                        break;
                    case 5:
                        Exercise5();
                        break;
                    case 6:
                        Exercise6();
                        break;
                    case 7:
                        Exercise7();
                        break;
                    case 8:
                        Exercise8();
                        break;
                }
                Console.Write(
                    "1.List hotels\n2.Select a hotel\n3.List all hotels in Roskilde\n4.List all single rooms for hotels in Roskilde\n5.Update holtel_No 3\n6.Insert a new hotel");
                Console.Write("\n7.Delete a hotel\n8.Update Room prices\n0.End\nPlease enter your choice:");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();



        }

        private static void Exercise8()
        {
            throw new NotImplementedException();
        }

        private static void Exercise7()
        {
            Console.WriteLine("Exercise 7");
            const string ServerUrl = "http://localhost:5645";
            Console.WriteLine("Enter Hotel_No to delete:");
            int deleteHotelNo = int.Parse(Console.ReadLine());
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string deleteUrl = "api/hotels/" + deleteHotelNo;
                    var response = client.DeleteAsync(deleteUrl).Result;

                    Console.WriteLine("Delete Async " + deleteUrl);
                    Console.WriteLine(response.StatusCode);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Succcesfull delete");
                    }
                    else
                    {
                        Console.WriteLine("Someting went wrong, hotel not deleted");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error exercise 7" + ex.Message);
                }
                Console.ReadLine();
            }
        }



        private static void Exercise6()
        {
            Console.WriteLine("Exercise 6");
            const string ServerUrl = "http://localhost:5645";
            
            Console.Write("Enter number of new hotel:");
            int myNewHotelNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name of the ID {0} hotel", myNewHotelNo);
            string myNewHotelName = Console.ReadLine();

            Console.WriteLine("Enter the address of the {0} hotel", myNewHotelName);
            string myNewHotelAddress = Console.ReadLine();

            Console.Clear();

            //First we create the new hotel object
            var myNewHotel = new Hotel()
            {
                Hotel_No = myNewHotelNo,
                Hotel_Address = myNewHotelAddress,
                Hotel_Name = myNewHotelName,
                
            };

            //The we need to serialize it
            string newHoteljson = JsonConvert.SerializeObject(myNewHotel);

            //Create the content we will send in the Http post request 

            var content = new StringContent(newHoteljson, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync("api/Hotels", content).Result;
                Console.WriteLine("PostAsync");
                Console.WriteLine("Status code " + response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    //Success , Now we can get the hotel by a Http post
                    var responseHotel = client.GetAsync("api/Hotels/" + myNewHotelNo).Result;
                    Console.WriteLine("GetAsync");
                    Console.WriteLine("Status code " + response.StatusCode);

                    if (responseHotel.IsSuccessStatusCode)
                    {
                        var hotel200 = responseHotel.Content.ReadAsAsync<Hotel>().Result;
                        Console.WriteLine(hotel200.ToString());
                    }
                }
            }


        }

        private static void Exercise5()
        {
            // Update (change the name) hotelNo: 3

            const string ServerUrl5 = "http://localhost:5645/";

            HttpClientHandler handler5 = new HttpClientHandler();
            handler5.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler5))
            {
                client.BaseAddress = new Uri(ServerUrl5);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Console.WriteLine("Select number three (if you like): ");

                    int selection = int.Parse(Console.ReadLine());
                    var response = client.GetAsync("api/Hotels/" + selection).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Hotel hotels = response.Content.ReadAsAsync<Hotel>().Result;

                        Console.WriteLine("Give a new name\n");
                        hotels.Hotel_Name = Console.ReadLine();

                        string json = JsonConvert.SerializeObject(hotels);
                        Console.WriteLine("json file: " + json);

                        StringContent MyContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                        var response2 = client.PutAsync("api/Hotels/" + selection, MyContent).Result;
                        Console.WriteLine("{0}", hotels.Hotel_Name);

                        Console.Clear();

                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
        }

        private static void Exercise4()
        {
            // List all single rooms in Roskilde

            //TODO: conditional statement for success responseCode!!!!

            const string ServerUrl4 = "http://localhost:5645/";

            HttpClientHandler handler4 = new HttpClientHandler();
            handler4.UseDefaultCredentials = true;


            using (var client = new HttpClient(handler4))
            {
                client.BaseAddress = new Uri(ServerUrl4);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Console.WriteLine("All single rooms in Roskilde: ");
                    var response = client.GetAsync("api/Rooms").Result;
                    var response2 = client.GetAsync("api/Hotels").Result;

                    if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode)
                    {
                        IEnumerable<Hotel> hotels = response2.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        IEnumerable<Room> rooms = response.Content.ReadAsAsync<IEnumerable<Room>>().Result;


                        var singleRooms = from r in rooms
                                          join s in hotels on r.Hotel_No equals s.Hotel_No
                                          where s.Hotel_Address.Contains("Roskilde") && r.Room_Type.Equals("S")
                                          select new { n = s.Hotel_Name, type = r.Room_No };


                        foreach (var s in singleRooms)
                        {
                            Console.WriteLine("Hotel Name: {0} -- room number {1}", s.n, s.type);
                        }
                    }



                }
                catch (Exception)
                {

                    Console.WriteLine("Error");
                }
            }
            Console.ReadLine();
            Console.Clear();

        }

        private static void Exercise3()
        {
            //List all hotels at Roskilde:

            //TODO: conditional statement for success responseCode!!!!

            const string ServerUrl3 = "http://localhost:5645/";

            HttpClientHandler handler3 = new HttpClientHandler();
            handler3.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler3))
            {
                client.BaseAddress = new Uri(ServerUrl3);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    Console.WriteLine("All hotels in Roskilde: ");

                    var response = client.GetAsync("api/Hotels").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        IEnumerable<Hotel> rskhtls = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        // instead of foreach use a LINQ query

                        var rskQuery = from r in rskhtls
                                       where r.Hotel_Address.Contains("Roskilde")
                                       select r;

                        foreach (var h in rskQuery)
                        {
                            Console.WriteLine(h);
                        }

                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
            Console.ReadLine();
            Console.Clear();
        }

        private static void Exercise2()
        {

            // Select a hotel:

            const string ServerUrl2 = "http://localhost:5645/";

            HttpClientHandler handler2 = new HttpClientHandler();
            handler2.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler2))
            {


                client.BaseAddress = new Uri(ServerUrl2);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    //readline variable

                    Console.WriteLine("Please select hotel ID: ");
                    int selected = int.Parse(Console.ReadLine());

                    //make the right call

                    var response = client.GetAsync("api/Hotels/" + selected).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //change type
                        Hotel hotel = response.Content.ReadAsAsync<Hotel>().Result;

                        //no loop pls
                        if (hotel != null)
                        {
                            Console.WriteLine(hotel);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }

            }
            Console.ReadLine();
            Console.Clear();
        }

        private static void Exercise1()
        {
            //List all hotels:

            const string ServerUrl = "http://localhost:5645/";

            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

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
                        IEnumerable<Hotel> hotelData = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        foreach (var hotel in hotelData)
                        {
                            Console.WriteLine(hotel);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }

            }
            Console.ReadLine();
            Console.Clear();


        }
    }
}

