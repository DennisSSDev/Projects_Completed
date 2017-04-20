using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE_for_Trees__talent_tree_
{
    class TalentTreeNode
    {
        public string Name { get; set; }
        public bool Learned { get; set; }
        public TalentTreeNode Left { get; set; }
        public TalentTreeNode Right { get; set; }
        public TalentTreeNode(string pName, bool pLearned)
        {
            Name = pName;
            Learned = pLearned;
        }

        public void ListKnownAblilities(TalentTreeNode node)
        {
            if(node!= null)
            {
                if (node.Learned)
                {
                    ListKnownAblilities(node.Left);
                    Console.WriteLine(node.Name);
                    ListKnownAblilities(node.Right);
                }

            }
        }
        public void ListPossibleKnowAbilities(TalentTreeNode node)
        {
            if(node!= null)
            {
                if(node.Learned == false)
                {
                    Console.WriteLine(node.Name);
                }
                else 
                {
                    ListPossibleKnowAbilities(node.Left);
                    ListPossibleKnowAbilities(node.Right);
                }
            }
        }

        
    }
}
