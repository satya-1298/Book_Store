using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Interface;
using RepoLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AddressBusiness:IAddressBusiness
    {
        private readonly IAddressRepo repo;
        public AddressBusiness(IAddressRepo addressRepo)
        {
            this.repo = addressRepo;
        }
        public Address AddAddress(AddressModel addressModel, int id)
        {
            try
            {
                return repo.AddAddress(addressModel, id);
            }
            catch 
            {
                return null;
            }
        }
        public Address RemoveAddress(int id, int userId)
        {
            try
            {
                return repo.RemoveAddress(id,userId);
            }
            catch
            {
                return null;
            }
        }
        public Address UpdateAddress(int id, int userId, AddressModel addressModel)
        {
            try
            {
                return repo.UpdateAddress(id,userId,addressModel);
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
                return repo.GetAllAddresses(id);
            }
            catch
            {
                return null;
            }
        }

    }
}
