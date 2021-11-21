using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021221.Logic
{
    interface IClientLogic
    {
        void ChangeStudentMajor(int id, string newMajor);
        void ChangeEmployeeAddress(int id, string newAddress);
        void ChangeEmployeeEmail(int id, string newEmail);
    }
}
