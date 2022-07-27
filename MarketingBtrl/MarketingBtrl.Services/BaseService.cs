using MarketingBtrl.DAL.Repositories.Interfaces;
using MarketingBtrl.Services.Interfaces;
using System;

namespace MarketingBtrl.Services
{
    public abstract class BaseService : IBaseService
    {
        public BaseService(IRepositoryWrapper repositoryWrapper)
        {
        }

        private IBaseController _controller;
        protected IBaseController Controller { get { return _controller; } }
        public void Register(IBaseController controller)
        {
            this._controller = controller;
        }
    }
}
