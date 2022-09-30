using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWeb.Shared.Models
{
    public class JoinModel
    {
        public int GameId { get; set; }
        public int CardId { get; set; }
        public string? Name { get; set; }
        public int Games { get; set; }
        public string? ImgName { get; set; }
    }
}
