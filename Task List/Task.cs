using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_List
{
    class Task
    {
        //These are my fields
        public string username { get; set; }
        public string description { get; set; }
        public DateTime duedate { get; set; }
        public bool completed { get; set; }
        


        public Task (string UserName, string Desciption, DateTime DueDate)
        {
            username = UserName;
            description = Desciption;
            duedate = DueDate;
            completed = false;
        }





        
    }
}
