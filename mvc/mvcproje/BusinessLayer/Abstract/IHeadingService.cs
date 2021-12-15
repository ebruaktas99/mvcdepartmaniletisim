using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        void HeadingAdd(Heading heading);

        Heading GetByID(int id);

        void HeadingDelete(Heading heading); //Silme işlemi için seçilen ID'yi almasını sağlayacağız.

        void HeadingUpdate(Heading heading);
    }
}
