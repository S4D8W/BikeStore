﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BikeStore.core.Domain {
 public class Address {
    
    [Key]
    public int IdxAddress { get; protected set; }
    public string ZipCode { get; protected set; }
    public string City { get; protected set; }
    public string Street { get; protected set; }
    public string HouseNumber { get; protected set; }
    public string Phone { get; protected set; }
    public string Country { get; protected set; }

    public Address() {

    }
    public Address( string xZipCode, string xCity, string xStreet, string xHouseNumber, string xPhone, string xCountry) {
      ZipCode = xZipCode;
      City = xCity;
      Street = xStreet;
      HouseNumber = xHouseNumber;
      Phone = xPhone;
      Country = xCountry;
    }
  }
}
