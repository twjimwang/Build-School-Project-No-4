using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Build_School_Project_No_4.DataModels;

namespace Build_School_Project_No_4.Repositories
{
    public class DetailRepository
    {
        private readonly EPalContext _ctx;
        public DetailRepository()
        {
            _ctx = new EPalContext();
        }

        

    }
}