using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11.Model
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Data { get; set; }
        public string Task { get; set; }
        public override string ToString()
        {
            return $"{Task}";
        }
    }
}
