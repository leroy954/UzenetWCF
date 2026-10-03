using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UzenetKuldo.Models;


namespace UzenetKuldo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUzenetService
    {

        [OperationContract]

        List<Uzenet> GetAllUzenet();

        [OperationContract]

        string PostUzenet(Uzenet uzenet);

        [OperationContract]

        string PutUzenet(Uzenet uzenet);

        [OperationContract]

        string DeleteUzenet(int id);

    }

}
