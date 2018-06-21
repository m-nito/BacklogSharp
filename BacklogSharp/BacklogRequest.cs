using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklogSharp
{
    public enum RequestType {
        Task,
        Error
    }
    public interface BacklogRequest<T> {
        bool Post();
        // T Get(BacklogProject proj);
    }
}
