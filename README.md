# AVLTree
A C# implementation of a generic AVL Tree data structure.

## Getting started
A Binary Search Tree is a data structure that borrows from the concept of a decision tree.
A binary tree holds a set of values. A binary tree has zero or more nodes, each of which contains a single value. The tree with no nodes is called the empty tree. Any non-empty tree consists of a root node plus its left and right subtrees, which are also (possibly empty) binary trees.
Here is a picture of a binary tree:

![Example binary search tree](http://ksvi.mff.cuni.cz/~dingle/2017/binary_tree.svg)

In this tree, a is the root node. Node b is the parent of nodes d and e. Node d is the left child of b, and node e is b's right child. Node e has a left child but no right child. Node c has a right child but no left child.

The subtree rooted at b is the left subtree of node a.

The nodes d, f, h and i are leaves: they have no children. Nodes a, b, c, e and g are internal nodes, which are nodes that are not leaves.

The BST always maintains two rules, for any node N with value v,:
- all values in N's left subtree are less than v
- all values in N's right subtree are greater than v

A binary tree is said to be balanced if the Left and Right's subtrees' heights differ by at most one and the Left subtree is balanced and the Right subtree is balanced.

Add, Remove and Delete are performed in O(logn) asymptotic complexity.

### Installing
Just include the AVLTree.cs file as a dependency upon compiling. So, for example, to compile the AVLTreeExample.cs which has the static void main() method and uses the AVLTree class in AVLTree.cs you would run the following command in Unix:
```
csc /target:exe AVLTreeExample.cs AVLTree.cs
```
Or in Windows:
```
csc.exe /target:exe AVLExample.cs AVLTree.cs
```
### Usage
See the AVLTreeExample.cs source code for an example which provides a command line utility to Add, Remove and Delete integers in a BST, as well as print the BST in a readable format. The command line utility accepts four commands:
P - Prints the tree, sideways, such that the root is on the left and higher values are above lower ones.
I <int> - Inserts <int> into tree. For example: I 4 
Q <int> - Queries the tree and returns "Present" if found or "Absent" if not. Example: Q 4 (would return "Present)
D <int> - Deletes an element from the tree, if Present. Example: D 4 (now the tree is empty)

### Issues
Permission denied when running AVLTreeExample.exe, you may need to run `chmod u+x AVLTreeExample.exe` to grant execute permissions.
