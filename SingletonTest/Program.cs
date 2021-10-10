using System;
using System.Threading;

namespace Singletontest
{
    class Program
    {
        static void Main( string [ ] args )
        {
            // [追加]初期化。ここでコンストラクタを呼ぶことでシングルトンのオブジェクトが作成される
            Console.WriteLine( "Main Initialize Start" );
            Singleton.Instance.Initialize();
            Console.WriteLine( "Main Initialize End" );

            Thread thread = new Thread( new ThreadStart( () =>
            {
                thread_func();
            } ) );

            thread.Start();

            Console.WriteLine( "Main InstanceName Start" );

            // スリーブしてスレッド側でコンストラクタを呼ぶ
            Thread.Sleep( 100 );

            string str = Singleton.Instance.getInstanceName();
            Console.WriteLine( "Main InstanceName:{0}", str );
            Console.WriteLine( "Main InstanceName End" );

            thread.Join();
        }

        static void thread_func()
        {
            Console.WriteLine( "Thread Start" );

            string str = Singleton.Instance.getInstanceName();
            Console.WriteLine( "Thread Instance Name:{0}", str );

            Console.WriteLine( "Thread Sleep Start" );
            Thread.Sleep( 3000 );
            Console.WriteLine( "Thread Sleep End" );

            Console.WriteLine( "Thread End" );
        }
    }
}
