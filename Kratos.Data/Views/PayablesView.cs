using System.Collections.Generic;

using Kratos.Data.Model;
using Kratos.Data.DAL;

namespace Kratos.Data.Views
{
  public class PayablesView 
  {
    private readonly PayablesDAL _dal;

    public PayablesView(PayablesDAL dal)
    {
      _dal = dal;
    }

    public List<RawPayable> GetAll()
    {
      return _dal.GetAll();
    }
  }
}
