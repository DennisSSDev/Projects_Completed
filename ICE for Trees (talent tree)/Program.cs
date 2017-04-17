using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE_for_Trees__talent_tree_
{
    class Program
    {
        static void Main(string[] args)
        {
            TalentTreeNode newTree = new TalentTreeNode("Javascript", true);
            newTree.Left = new TalentTreeNode("C#", true);
            newTree.Right = new TalentTreeNode("C++", true);
            newTree.Left.Left = new TalentTreeNode("Processing", false);
            newTree.Left.Right = new TalentTreeNode("P5.js", false);
            newTree.Right.Left = new TalentTreeNode("Machine Learning", false);
            newTree.Right.Right = new TalentTreeNode("Ethical Hacking", true);
            newTree.ListKnownAblilities(newTree);
            newTree.ListPossibleKnowAbilities(newTree);

        }
    }
}
