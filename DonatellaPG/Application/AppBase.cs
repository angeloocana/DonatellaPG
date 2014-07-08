using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application
{
    public class AppBase
    {
        private IUnityOfWork _unityOfWork;
        public void BeginTransaction()
        {
            _unityOfWork = ServiceLocator.Current.GetInstance<IUnityOfWork>();
            _unityOfWork.BeginTransaction();
        }

        public void Commint()
        {
            _unityOfWork.Commit();
        }
    }
}
