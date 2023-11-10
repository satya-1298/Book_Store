using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using RepoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Services
{
    public class AddressRepo:IAddressRepo
    {
        private readonly BookStoreDBContext bookStoreDB;
        private readonly IConfiguration configuration;
        public AddressRepo(BookStoreDBContext bookStoreDB,IConfiguration configuration)
        {
            this.bookStoreDB = bookStoreDB;
            this.configuration = configuration;
        }
        public Address AddAddress(AddressModel addressModel,int id)
        {
            try
            {
                Address address = new Address();
                address.UserId = id;
                address.StreetAddress = address.StreetAddress;
                address.City = addressModel.City;
                address.ZipCode = addressModel.ZipCode;
                address.State=addressModel.State;
                address.Country = addressModel.Country;
                bookStoreDB.Address.Add(address);
                bookStoreDB.SaveChanges();
                return address;
            }
            catch
            {
                throw;
            }

        }
        public Address RemoveAddress(int id , int userId)
        {
            try
            {
                var result = bookStoreDB.Address.Where(x => x.AddressId == id && x.UserId==userId).FirstOrDefault();
                if (result != null)
                {
                    bookStoreDB.Address.Remove(result);
                    bookStoreDB.SaveChanges();
                    return result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Address UpdateAddress(int id,int userId,AddressModel addressModel)
        {
            try
            {
                var result = bookStoreDB.Address.Where(x => x.AddressId == id).FirstOrDefault();
                if (result != null)
                {
                    result.UserId = userId;
                    result.StreetAddress = addressModel.StreetAddress;
                    result.City = addressModel.City;
                    result.ZipCode = addressModel.ZipCode;
                    result.State = addressModel.State;
                    result.Country = addressModel.Country;
                    bookStoreDB.SaveChanges();
                    return result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<Address> GetAllAddresses(int id)
        {
            try
            {
                var result = bookStoreDB.Address.Where(x => x.UserId == id).ToList();
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            catch 
            {
                return null;
            }
        }
    }
}
