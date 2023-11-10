﻿using CommonLayer.Model;
using RepoLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IAddressRepo
    {
        public Address AddAddress(AddressModel addressModel, int id);
        public Address RemoveAddress(int id, int userId);
        public Address UpdateAddress(int id, int userId, AddressModel addressModel);
        public List<Address> GetAllAddresses(int id);
    }
}
