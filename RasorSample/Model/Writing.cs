using System;
using System.ComponentModel.DataAnnotations;

namespace RasorSample.Model
{
    public class Writing
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
