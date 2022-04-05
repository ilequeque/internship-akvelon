using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Interfaces
{
    public interface IStudent : IGeneralInfo
    {
        List<ICourse> Courses { get; set; }
        Dictionary<string, int> Scores (ICourse course);
    }
}
