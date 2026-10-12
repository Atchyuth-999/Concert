using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ConcertRepository.Interfaces;
using ConcertRepository.Model;

namespace ConcertRepository.Services
{
    public class UserService : IUserInterface
    {
        private readonly string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool RegisterUser(UserDTO user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand("sp_InsertVirtualConcertRegistration", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    cmd.Parameters.AddWithValue("@HomeAddress", user.HomeAddress);
                    cmd.Parameters.AddWithValue("@StreetAddress", user.StreetAddress);
                    cmd.Parameters.AddWithValue("@City", user.City);
                    cmd.Parameters.AddWithValue("@State", user.State); 
                    cmd.Parameters.AddWithValue("@PinCode", user.PinCode);
                    cmd.Parameters.AddWithValue("@HeardAboutConcert", user.HeardAboutConcert);
                    //cmd.Parameters.AddWithValue("@VirtualConcertFee",user.VirtualConcertFee); 
                    cmd.Parameters.AddWithValue("@Quantity", user.Quantity);
                    cmd.Parameters.AddWithValue("@TotalAmount", user.TotalAmount);
                    cmd.Parameters.AddWithValue("@PaymentMethod",user.PaymentMethod
);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> users = new List<UserDTO>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd =
                    new SqlCommand("sp_GetAllVirtualConcertRegistrations", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new UserDTO
                            {
                                RegistrationId = Convert.ToInt32(reader["RegistrationId"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Age = Convert.ToInt32(reader["Age"]),
                                Gender = reader["Gender"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                EmailAddress = reader["EmailAddress"].ToString(),
                                HomeAddress = reader["HomeAddress"].ToString(),
                                StreetAddress = reader["StreetAddress"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                PinCode = reader["PinCode"].ToString(),  
                                HeardAboutConcert = reader["HeardAboutConcert"].ToString(),
                                //VirtualConcertFee = Convert.ToDecimal(reader["VirtualConcertFee"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                PaymentMethod = reader["PaymentMethod"].ToString()
                            });
                        }
                    }
                }
            }

            return users;
        }
        public UserDTO GetUserById(int registrationId)
        {
            UserDTO user = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd =
                new SqlCommand("sp_GetVirtualConcertRegistrationById", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RegistrationId",registrationId);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserDTO
                        {
                            RegistrationId =Convert.ToInt32(reader["RegistrationId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName =reader["LastName"].ToString(),
                            Age =Convert.ToInt32(reader["Age"]),
                            Gender = reader["Gender"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            EmailAddress = reader["EmailAddress"].ToString(),
                            HomeAddress =reader["HomeAddress"].ToString(),
                            StreetAddress = reader["StreetAddress"].ToString(),
                            City  = reader["City"].ToString(),
                            State = reader["State"].ToString(),
                            PinCode = reader["PinCode"].ToString(),
                            HeardAboutConcert = reader["HeardAboutConcert"].ToString(),
                            //VirtualConcertFee = Convert.ToDecimal(reader["VirtualConcertFee"]),
                            Quantity =Convert.ToInt32(reader["Quantity"]),
                            TotalAmount =Convert.ToDecimal(reader["TotalAmount"]),
                            PaymentMethod = reader["PaymentMethod"].ToString()
                        };
                    }
                }
            }

            return user;
        }

        public bool UpdateUser(UserDTO user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateVirtualConcertRegistration", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RegistrationId", user.RegistrationId);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    //cmd.Parameters.AddWithValue("@AreaCode", user.AreaCode);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    cmd.Parameters.AddWithValue("@HomeAddress", user.HomeAddress);
                    cmd.Parameters.AddWithValue("@StreetAddress", user.StreetAddress);
                    cmd.Parameters.AddWithValue("@City", user.City);
                    cmd.Parameters.AddWithValue("@State", user.State);
                    cmd.Parameters.AddWithValue("@PinCode", user.PinCode);
                    cmd.Parameters.AddWithValue("@HeardAboutConcert", user.HeardAboutConcert);
                    //cmd.Parameters.AddWithValue("@OtherSource", user.OtherSource ?? "");
                    //cmd.Parameters.AddWithValue("@VirtualConcertFee", user.VirtualConcertFee);
                    cmd.Parameters.AddWithValue("@Quantity", user.Quantity);
                    cmd.Parameters.AddWithValue("@TotalAmount", user.TotalAmount);
                    cmd.Parameters.AddWithValue("@PaymentMethod", user.PaymentMethod);
                    //cmd.Parameters.AddWithValue("@UpdatedDate", user.UpdatedDate);
                    con.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteUser(int registrationId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteVirtualConcertRegistration", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RegistrationId", registrationId);

                    con.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}