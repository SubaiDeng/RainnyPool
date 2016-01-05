using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorfulRain
{
    class RainQueue<T>
    {
        //节点个数
        private int _noteCount;
        private MyNode<T> Header { get; set; }
        private MyNode<T> Tail { get; set; }        
        public int NoteCount { get { return _noteCount; } }

        // 构造函数，初始化头结点和结点个数
         public RainQueue()
         {
             // 注意此处default(T)的使用
             Header = new MyNode<T>(default(T));
             Tail = Header;
             _noteCount = 0;
         }

        public T DeQueue()
         {
             // 注意判空，只要一个条件就可以了，将所有的条件都写在这里可以有利于在测试的时候检测出bug
             if ( _noteCount == 0)
             {
                 return default(T);
             } 
             MyNode<T> outNode = Header.next;
             Header.next = Header.next.next;
             _noteCount--;
             return outNode.Data;
         }
        public void EnQueue(T NodeData)
        {             
            MyNode<T> Node = new MyNode<T>(NodeData);
            Tail.next = Node;
            Tail = Node;
            _noteCount++;        
        }
    }

    //节点类
    // 结点类
    // 注意应该使用泛型
    public class MyNode<T>
    {
        // 私有字段
        private T _data;
        private MyNode<T> _next;

        // 存储的数据
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
        // 指向下一个结点
        public MyNode<T> next { get { return _next; } set { _next = value; } }
        //构造函数，不提供无参版本
        public MyNode(T data)
        {
            _data = data;
            _next = null;
        }
    }
}
