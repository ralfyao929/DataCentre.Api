using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Contracts
{
    public interface IRepositoryWrapper
    {
        ILoginDataRepository loginData { get; }
        //TO-DO Add Data Repository here...
        void Save();
    }
}
