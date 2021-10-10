using System;

namespace Singletontest
{
    public sealed class Singleton
    {
        private static Singleton _instance;

        private static readonly object _syncRoot = new object();

        public static Singleton Instance
        {
            get
            {
                Console.WriteLine( "get start Instance" );

                lock ( _syncRoot )
                {
                    if ( _instance == null )
                    {
                        Console.WriteLine( "初期インスタンス作成につき名前を入力してください" );
                        var str = Console.ReadLine();

                        _instance = new Singleton( str );
                    }
                    else
                    {
                        Console.WriteLine( "Instance:Exist" );
                    }
                }

                return _instance;
            }
        }

        private string m_instanceName;

        private Singleton( string name) : this()
        {
            m_instanceName = name;
            Console.WriteLine( "Singleton:{0}", m_instanceName );
        }

        private Singleton()
        {
            m_instanceName = nameof( Singleton );
        }

        ~Singleton()
        {
            Console.WriteLine( "Del" );
        }

        public void Initialize()
        {

        }

        public string getInstanceName()
        {
            Console.WriteLine( "getInstanceeName:{0}", m_instanceName );
            return m_instanceName;
        }
    }
}
