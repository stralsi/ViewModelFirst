using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModelFirst
{

    public class NavigationMap
    {
        private Dictionary<string,Dictionary<string,Func<object[],ViewModelBase>>> _map = new Dictionary<string,Dictionary<string,Func<object[],ViewModelBase>>>();

        public void RegisterNavigation(string sourceTypeName, string actionName, Func<object[], ViewModelBase> viewModelFactory)
        {
            if (!_map.ContainsKey(sourceTypeName) || _map[sourceTypeName] == null)
            {
                _map[sourceTypeName] = new Dictionary<string, Func<object[], ViewModelBase>>();
            }

            _map[sourceTypeName][actionName] = viewModelFactory;
        }

        public ViewModelBase GetDestinationViewModel(string sourceTypeName, string actionName, params object[] actionParameters)
        {
            if (_map[sourceTypeName] == null || _map[sourceTypeName][actionName] == null)
            {
                throw new InvalidOperationException("There is no mapping from "+sourceTypeName+" for action "+actionName);
            }

            ViewModelBase result = _map[sourceTypeName][actionName].Invoke(actionParameters);
            return result;
        }
    }
}
