using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UzenetKuldo.Models;
using UzenetKuldo.Services;  

namespace UzenetKuldo
{
    public class UzenetWCFService : IUzenetService
    {
        private readonly UzenetKuldo.Services.UzenetService _crudService;

        public UzenetWCFService()
        {
            _crudService = new UzenetKuldo.Services.UzenetService();
        }

        public string DeleteUzenet(int id)
        {
            return _crudService.Delete(id);
        }

        public List<Uzenet> GetAllUzenet()
        {
            List<Uzenet> uzenetList = new List<Uzenet>();
            List<Tablazat> tablazatList = _crudService.Read();

            foreach (var tablazat in tablazatList)
            {
                uzenetList.Add((Uzenet)tablazat);
            }

            return uzenetList;
        }

        public string PostUzenet(Uzenet uzenet)
        {
            return _crudService.Create(uzenet);
        }

        public string PutUzenet(Uzenet uzenet)
        {
            return _crudService.Update(uzenet);
        }
    }
}