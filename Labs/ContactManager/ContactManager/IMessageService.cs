using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public abstract interface IMessageService
    {
        string Message
        {
            get;
            set;
        }

        string Subject
        {
            get;
            set;
        }
    }
}
