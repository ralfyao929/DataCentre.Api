using DataCentre.Api.Contracts;

namespace DataCentre.Api.Module
{
    public class ModuleBase
    {
        protected IRepositoryWrapper _repositoryWrapper;
        public ModuleBase(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
    }
}
