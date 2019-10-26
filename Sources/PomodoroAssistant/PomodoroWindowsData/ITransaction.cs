using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrx.Mobile.Windows.Pomodoro.Data
{
    public interface ITransaction
    {
        void Execute();
    }
}
