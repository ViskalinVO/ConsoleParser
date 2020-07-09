using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMusic
{
    //todo реализовать возможность вывода резултата запроса различными вариантами (консоль, файл, печать)
    interface IPrinter
    {
        void Print(string text);
    }
}
