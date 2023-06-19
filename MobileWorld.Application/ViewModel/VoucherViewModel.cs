﻿using MobileWorld.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Application.ViewModel
{
    public class VoucherViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Código é obrigatório")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Quantidade de caracteres inválidos")]
        public string Code { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? DiscountValue { get; set; }
        public int Amount { get; set; }
        public DiscountTypeVoucher DiscountType { get; set; }
        public DateTime? UsedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Active { get; set; }
        public bool Used { get; set; }
    }
}
