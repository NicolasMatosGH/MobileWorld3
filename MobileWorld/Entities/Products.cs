﻿using MobileWorld.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Domain.Entities
{
    public class Product : Entity
    {
        protected Product() { }
        public Product(string brand,
            string model,
            string name,
            string description,
            bool active,
            decimal price,
            DateTime dateRegister,
            string image,
            int stockQuantity)
        {
            Brand = brand;
            Model = model;
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            DateRegister = dateRegister;
            Image = image;
            StockQuantity = stockQuantity;
        }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DateRegister { get; private set; }
        public string Image { get; private set; }
        public int StockQuantity { get; private set; }

        public void SetStockQuantity(int quantity)
        {
            StockQuantity = quantity;
        }
    }
}
