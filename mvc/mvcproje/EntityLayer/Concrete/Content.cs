using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Content sınıfında içerikler yer alır.
    public class Content
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)] //maksimum uzunluk
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        public int HeadingID { get; set; } //heading sınfıyla bağlantı.
        public virtual Heading Heading { get; set; }
        public bool ContentStatus { get; set; }
        public int? WriterID { get; set; } //isim boş da olabilir.
        public virtual Writer Writer { get; set; }
    }
}
