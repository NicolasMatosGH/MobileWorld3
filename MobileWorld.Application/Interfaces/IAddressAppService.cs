﻿using MobileWorld.Application.ViewModel;
using MobileWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Application.Interfaces
{
    public interface IAddressAppService
    {
        Task<AddressViewModel> AddAsync(AddressViewModel address);
        AddressViewModel Update(AddressViewModel address);

        void Remove(Guid id);
        void Remove(Expression<Func<Address, bool>> expression);

        AddressViewModel GetById(Guid id);
        Task<AddressViewModel> GetByIdAsync(Guid id);

        IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> predicate);
        Task<IEnumerable<AddressViewModel>> SearchAsync(Expression<Func<Address, bool>> predicate);
        IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> predicate,
            int pageNumber,
            int pageSize);
    }
}
