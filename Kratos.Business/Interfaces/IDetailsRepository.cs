using System.Collections.Generic;
using Kratos.Business.Model;

namespace Kratos.Business.Interfaces
{
    public interface IDetailsRepository
    {
        List<Detail> GetAll();
    }
}