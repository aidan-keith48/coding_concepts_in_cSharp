using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace disposableObjectExample
{
    [Serializable()]
    public class Employee: ISerializable
    {
        public int empID;
        public string empName;


        public Employee()
        {
            empID = 0;
            empName = null;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //throw new NotImplementedException();
            info.AddValue("EmployeeID", empID);
            info.AddValue("EmployeeName", empName);
        }

        public Employee(SerializationInfo info, StreamingContext context)
        {
            empID = (int)info.GetValue("EmployeeID", typeof(int));
            empName = (String)info.GetValue("EmployeeName", typeof(String));
        }
    }
}
