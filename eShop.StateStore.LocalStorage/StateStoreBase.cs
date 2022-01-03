using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.StateStore.LocalStorage
{
    public class StateStoreBase
    {
        protected Action listeners;

        public void AddStateChangeListeners(Action listener) => listeners += listener;


        public void RemoveStateChangeListeners(Action listener) => listeners -= listener;


        public void BroadCastStateChange()
        {
            if (listeners != null) listeners.Invoke();
        }

    }
}
