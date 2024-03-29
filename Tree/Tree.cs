using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Tree
    {
        public Tree(int data)
        {
            this._data = data;
            _childs = new List<Tree>();
        }

        public void addChild(Tree child)
        {
            _childs.Add(child);
        }

        private List<Tree> _childs;
        private int _data;

        private string nodeToString(int index)
        {
            StringBuilder sb = new StringBuilder();

            for(int i =0;i<index;++i)
                sb.Append(" |");
            sb.Append(this._data);
            foreach(Tree child in _childs)
            {
                sb.Append('\n');
                sb.Append(child.nodeToString(index + 1));
            }

            return sb.ToString();
        }
        public override string ToString()
        {
            return nodeToString(0);
        }
    }
}
