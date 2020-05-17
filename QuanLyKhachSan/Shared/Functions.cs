using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Shared
{
     class Functions
    {
        public bool isNumber(string str)
        {
            bool result;
            Regex rg = new Regex(@"^\d+$");
            if (rg.IsMatch(str))
                result = true;
            else
                result = false;
            return result;
        }
    
    }
}
