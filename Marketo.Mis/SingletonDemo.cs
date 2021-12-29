using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Marketo.Mis
{
    /// <summary>
    /// Singleton class with no thread safe
    /// </summary>
    public sealed class SingletonDemo
    {
        private static SingletonDemo _instance = null;

        private SingletonDemo()
        {

        }

        public static SingletonDemo GetSingletonDemoInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonDemo();
                }
                return _instance;
            }
            
        }
    }
    /// <summary>
    /// thread safe singleton class
    /// </summary>
    public sealed class SingletonDemoThreadSafe
    {
        private SingletonDemoThreadSafe() {}
        private static readonly object Threadlock = new object();
        private static SingletonDemoThreadSafe _instance = null;

        public static SingletonDemoThreadSafe GetSingletonDemoThreadSafeInstance
        {
            get
            {
                lock (Threadlock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonDemoThreadSafe();
                    }

                    return _instance;
                }
            }
        }

    }
    /// <summary>
    /// Singleton class with double-checking-locking
    /// 
    /// </summary>
    public sealed class SingletonDemoDCL
    {
        private SingletonDemoDCL(){}
        private static readonly object ThreadLock = new object();
        private static SingletonDemoDCL _instance = null;

        public static SingletonDemoDCL GetSingletonDemoDclInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (ThreadLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonDemoDCL();
                        }
                    }
                }

                return _instance;
            }
        }

    }
    /// <summary>
    /// Singleton class without lazy loading
    /// </summary>
    public sealed class SingletonDemoNoLazy
    {
        private static readonly SingletonDemoNoLazy _instance = new SingletonDemoNoLazy();

        static SingletonDemoNoLazy()
        {

        }

        private SingletonDemoNoLazy()
        {

        }

        public static SingletonDemoNoLazy GetSingletonDemoNoLazy
        {
            get
            {
                return _instance;
            }
        }
        
    }

    public sealed class SingletonDemoLazy
    {
        private SingletonDemoLazy()
        {

        }

        private static readonly Lazy<SingletonDemoLazy> lazy =
            new Lazy<SingletonDemoLazy>(() => new SingletonDemoLazy());

        public static SingletonDemoLazy GetSingletonDemoLazyInstance
        {
            get
            {
                return lazy.Value;
            }
        }
    }

    
}
