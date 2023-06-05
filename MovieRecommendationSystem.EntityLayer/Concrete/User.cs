using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.EntityLayer.Concrete
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string RoleCode { get; set; }
        public bool Status { get; set; }

        public ICollection<MovieComment> Movies { get; set; }

    }
}
