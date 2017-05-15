using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Rope
{
    /// <summary>
    /// Rope Implementation
    /// Adapted from: https://github.com/harymitchell/JavaRope/blob/master/Rope.java
    /// </summary>
    public class Rope : IRope
    {
        RopeNode root;
        int length; // refers to length of all data nodes combined.

        public int Length { get { return length; } }

        public RopeNode Root { get; }

        // Construct Rope

        public Rope()
        {
            this.root = new RopeNode();
        }

        public Rope(string text)
        {
            // Creates a Rope with a single RopeNode containing `text'.
            this.root = new RopeNode(text);
            this.length = text.Length;
        }

        public Rope(string text, int spacing)
        {
            // Creates a Rope from a string with the text split between RopeNodes, split by `spacing'.
            int string_length = text.Length;
            this.root = new RopeNode();
            for (int i = 0; i < string_length; i = i + spacing)
            {
                if (string_length - i < spacing)
                {
                    this.rope_append_from_string(text.Substring(i, string_length));
                    this.length += string_length - i;
                }
                else this.rope_append_from_string(text.Substring(i, i + spacing));
                this.length += spacing;
            }
        }


        public void rope_append_from_string(string new_string)
        {
            // Helper method to add `new_string' to end of Rope
            root = root.string_append(new_string);
        }

        // Modify Rope

        public void rope_append(string new_string)
        {
            // Add `new_string' to end of Rope
            Rope new_rope = new Rope(new_string); // New Rope containing `new_string'.
            RopeNode new_root_node = new RopeNode();                // New empty root RopenNode.
            new_root_node.left = this.root;                         // Set new root's left node to old this.root.
            new_root_node.right = new_rope.root;                    // Set new root's right node to new rope's root
            this.root.parent = new_root_node;
            new_rope.root.parent = new_root_node;
            root = new_root_node;                                   // Set current root to new root.
        }

        public void rope_append(Rope rope)
        {
            RopeNode new_root_node = new RopeNode();                // New empty root RopeNode.
            new_root_node.left = this.root;                         // Set new root's left node to old this.root.
            new_root_node.right = rope.root;                    // Set new root's right node to new rope's root
            this.root.parent = new_root_node;
            rope.root.parent = new_root_node;
            root = new_root_node;									// Set current root to new root.
        }

        public void rope_prepend(string new_string)
        {
            // Add `new_string' to beginning of Rope
            Rope new_rope = new Rope(new_string); // New Rope containing `new_string'.
            RopeNode new_root_node = new RopeNode();                // New empty root RopenNode.
            new_root_node.right = this.root;                        // Set new root's left node to old this.root.
            new_root_node.left = new_rope.root;                     // Set new root's right node to new rope's root
            this.root.parent = new_root_node;
            new_rope.root.parent = new_root_node;
            root = new_root_node;                                   // Set current root to new root.	
        }

        public Rope splitRope(int start, int end)
        {
            // Returns a sub-rope from `start' to end.
            Rope result = new Rope();// = new Rope();
            //		RopeNode new_root = new RopeNode();
            result.root = this.root.trimLeft(start, end, 0);
            return result;
        }

        public Rope insertOnRope(string text, int index)
        {
            // Inserts `text' into Rope at given index.
            Rope new_node = new Rope(text);// = new Rope();
            this.root.resetIterators();
            this.root.insertOnRopeNode(new_node.root, index, 0, false);
            return this;
        }

        public Rope insertOnRope(Rope rope, int index)
        {
            // Inserts `text' into Rope at given index.
            this.root.resetIterators();
            this.root.insertOnRopeNode(rope.root, index, 0, false);
            return this;
        }

        // Access Rope

        public Rope subRope(int start, int end)
        {
            this.root.twin = root;
            this.root.subNode(start, end, 0);
            return this;
        }

        public RopeNode beginning_of_rope()
        {
            // Returns the RopeNode at the beginning of the Rope.
            bool found_beginning = false;
            RopeNode last_node = this.root;
            while (found_beginning == false)
            {
                if (last_node.data != null)
                {
                    return last_node;
                }
                else
                {
                    last_node = last_node.left;
                }
            }
            return last_node;
        }

        public RopeNode end_of_rope()
        {
            // Returns the RopeNode at the end of the Rope.
            bool found_end = false;
            RopeNode current_node = this.root;
            while (found_end == false)
            {
                if (current_node.data != null)
                {
                    found_end = true;
                }
                else
                {
                    current_node = current_node.right;
                }
            }
            return current_node;
        }

        // See Rope

        public string RopeTostring()
        {
            // Starting at the Rode's root, builds a string by recursively traversing Rope.
            StringBuilder sb = new StringBuilder();
            sb.Append(this.root.nodeToString());
            string result = sb.ToString();
            return result;
        }

        public void printRope()
        {
            // Starting at the Rode's root, recursively traverse Rope and print each node's data.
            this.root.printNode();
        }

        public void explainRope()
        {
            // Starting at the Rode's root, recursively traverse Rope and print each node's meta-data.
            this.root.explainNode();
        }

        public Rope self()
        {
            return this;
        }


        // Note: Assumes 1-based indexing.
        private char Index(RopeNode node, int i)
        {
            if (node.length < i)
            {
                return Index(node.left, i - node.length);
            }
            else
            {
                if (node.right != null)
                {
                    return Index(node.right, i);
                }
                else
                {
                    return node.data[i];
                }
            }
        }


        public char Index(int i)
        {
            return Index(root, i);
        }

        public IRope Concatenate(IRope r)
        {
            rope_append((Rope)r);
            return this;
        }

        public IRope Split(int i)
        {
            return splitRope(0, i);
        }

        public IRope Insert(int i, string s)
        {
            insertOnRope(s, i);
            return this;
        }


    }
}
