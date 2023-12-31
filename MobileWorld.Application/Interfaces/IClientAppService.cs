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
    public interface IClientAppService
    {
        Task<Client> AddAsync(ClientViewModel client);
        ClientViewModel Update(ClientViewModel client);

        void Remove(Guid id);
        void Remove(Expression<Func<Client, bool>> expression);

        ClientViewModel GetById(Guid id);
        Task<ClientViewModel> GetByIdAsync(Guid id);

        IEnumerable<ClientViewModel> Search(Expression<Func<Client, bool>> predicate);
        Task<IEnumerable<ClientViewModel>> SearchAsync(Expression<Func<Client, bool>> predicate);
        IEnumerable<ClientViewModel> Search(Expression<Func<Client, bool>> predicate,
            int pageNumber,
            int pageSize);
    }
}
