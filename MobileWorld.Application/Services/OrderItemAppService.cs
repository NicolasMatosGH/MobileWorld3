using AutoMapper;
using MediatR;
using MobileWorld.Application.Interfaces;
using MobileWorld.Application.ViewModel;
using MobileWorld.Domain.Entities;
using MobileWorld.Domain.Interfaces;
using MobileWorld.Domain.Shared.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Application.Services
{
    public class OrderItemAppService : BaseService, IOrderItemAppService
    {
        protected readonly IOrderItemRepository _repository;
        protected readonly IMapper _mapper;

        public OrderItemAppService(IOrderItemRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderItemViewModel> AddAsync(OrderItemViewModel viewModel)
        {
            var domain = _mapper.Map<OrderItem>(viewModel);
            domain = await _repository.AddAsync(domain);

            OrderItemViewModel viewModelReturn = _mapper.Map<OrderItemViewModel>(domain);
            return viewModelReturn;
        }

        public OrderItemViewModel GetById(Guid id)
        {
            var domain = _repository.GetById(id);
            var viewModel = _mapper.Map<OrderItemViewModel>(domain);
            return viewModel;
        }

        public async Task<OrderItemViewModel> GetByIdAsync(Guid id)
        {
            var domain = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<OrderItemViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<OrderItem, bool>> expression)
        {
            _repository.Remove(expression);
            Commit();
        }

        public IEnumerable<OrderItemViewModel> Search(Expression<Func<OrderItem, bool>> predicate)
        {
            var domain = _repository.Search(predicate);
            var viewModels = _mapper.Map<IEnumerable<OrderItemViewModel>>(domain);
            return viewModels;
        }

        public IEnumerable<OrderItemViewModel> Search(Expression<Func<OrderItem, bool>> predicate, int pageNumber, int pageSize)
        {
            var domain = _repository.Search(predicate, pageNumber, pageSize);
            var viewModels = _mapper.Map<IEnumerable<OrderItemViewModel>>(domain);
            return viewModels;
        }

        public async Task<IEnumerable<OrderItemViewModel>> SearchAsync(Expression<Func<OrderItem, bool>> predicate)
        {
            var domain = await _repository.SearchAsync(predicate);
            var viewModels = _mapper.Map<IEnumerable<OrderItemViewModel>>(domain);
            return viewModels;
        }

        public OrderItemViewModel Update(OrderItemViewModel viewModel)
        {
            var domain = _mapper.Map<OrderItem>(viewModel);
            domain = _repository.Update(domain);
            Commit();
            OrderItemViewModel viewModelReturn = _mapper.Map<OrderItemViewModel>(domain);
            return viewModelReturn;
        }
    }
}
