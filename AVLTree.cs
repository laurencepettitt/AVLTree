using System;
using static System.Console;
using static System.Math;

interface ISet<T>
{
  bool Insert(T val); // Add a value. Returns true if added, false if already present.
  bool Delete(T val); // Remove a value. Returns true if removed, false if not present.
  bool Contains(T val); // Return true if a value is present in the set.
}

class AVLTree<T> : ISet<T> where T : IComparable<T>
{
  public class Node : IComparable<Node>
  {
    public T Val;
    public Node Left;
    public Node Right;
    public int Height;
    
    public Node(T val, int height) {
      this.Val = val;
      this.Height = height;
    }
    
    public int CompareTo(Node v) => this.Val.CompareTo(v.Val);
    
    string ToStringUtil(Node t, int height)
    {
      if ( t == null ) return "";
      string s = "";
      s += ToStringUtil(t.Right, height + 2);
      //s += new string (' ', height) + t.Val;
      s += t.Val + " ";
      //s += " (" + BalanceFactor(t) + ")";
      //s += "\n";
      s += ToStringUtil( t.Left, height + 2);
      return s;
    }
    
    public override string ToString()
      => ToStringUtil(this, 0);
  }
  
  Node Root;
  public int Count = 0;
  
  public AVLTree() { Root = null; }
  
  static int Height(Node v) => (v == null) ? 0 : v.Height;
  
  static int BalanceFactor(Node v)
    => (v == null) ? 0 : (Height(v.Left) - Height(v.Right));
  
  
  void UpdateHeightsAfterRotation(Node n) {
    if (n == null) return;
    if (n.Left != null )
      n.Left.Height = 1 + Max(Height(n.Left.Left),
                              Height(n.Left.Right));
    if (n.Right != null)
      n.Right.Height = 1 + Max(Height(n.Right.Left),
                               Height(n.Right.Right));
    n.Height = 1 + Max(Height(n.Left),
                       Height(n.Right));
    
  }
    
  Node RotateRight(Node n) {
    Node newSubRoot = n.Left;
    n.Left = n.Left.Right;
    newSubRoot.Right = n;
    UpdateHeightsAfterRotation(newSubRoot);
    return newSubRoot;
  }
  
  Node RotateLeft(Node n) {
    Node newSubRoot = n.Right;
    n.Right = n.Right.Left;
    newSubRoot.Left = n;
    UpdateHeightsAfterRotation(newSubRoot);
    return newSubRoot;
    
  }
  
  void Rebalance(ref Node root) {
    int bF = BalanceFactor(root);
    // LeftLeft
    if (bF > 1 && BalanceFactor(root.Left) >= 0) {
      root = RotateRight(root);
    }
    // RightRight
    if (bF < -1 && BalanceFactor(root.Right) <= 0) {
      root = RotateLeft(root);
    }
    // LeftRight
    if (bF > 1 && BalanceFactor(root.Left) < 0) {
      root.Left = RotateLeft(root.Left);
      root = RotateRight(root);
    }
    // RightLeft
    if (bF < -1 && BalanceFactor(root.Right) > 0) {
      root.Right = RotateRight(root.Right);
      root = RotateLeft(root);
    }
  }
  
  // Recursive utility to insert val into the Binary Search Tree.
  // Once finished, ref Node currRoot will be the root of BST.
  bool InsertIn(ref Node root, T val)
  {
    bool result = true;
    if ( root == null ) {
      root = new Node(val, 1);
      Count++;
      return true;
    }
    else if ( val.CompareTo(root.Val) < 0 )
      result = InsertIn(ref root.Left, val);
    else if ( val.CompareTo(root.Val) > 0 )
      result = InsertIn(ref root.Right, val);
    else
      return false; // duplicates not allowed
    root.Height = 1 + Max(Height(root.Left),
                          Height(root.Right));
    Rebalance(ref root);
    return result;
  }

  public bool Insert(T theVal) => InsertIn(ref Root, theVal);
  
  // delete and return min val in tree rooted at root
  T DeleteMin(ref Node root) {
    if (root == null) throw new NullReferenceException();
    if (root.Left == null) {
      T min = root.Val;
      root = null;
      return min;
    } else
      return DeleteMin(ref root.Left);
  }
  
  bool DeleteFrom(ref Node root, T val) {
    if ( root == null ) return false; // not found
    bool result = false; // arbitrary initialisation
    if ( val.CompareTo(root.Val) < 0 )
      result = DeleteFrom(ref root.Left, val); // recurse left
    else if ( val.CompareTo(root.Val) > 0 )
      result = DeleteFrom(ref root.Right, val); // recurse right
    else if ( val.CompareTo(root.Val) == 0 ) {
      if (root.Left != null && root.Right != null) {
        root.Val = DeleteMin(ref root.Right); // two children
      } else root = root.Left ?? root.Right; // at most one child
      result = true;
      Count--;
    }
    if (root == null) return true; // deleted node had no children
    root.Height = 1 + Max(Height(root.Left),
                          Height(root.Right));
    Rebalance(ref root);
    return result;
  }
  
  public bool Delete(T val) => DeleteFrom(ref Root, val);
  
  bool ContainsIn(Node root, T val, out Node v) {
    v = root;
    if ( root == null ) 
        return false;
    if ( val.CompareTo(root.Val) == 0 )
        return true;
    if ( val.CompareTo(root.Val) < 0 )
        return ContainsIn(root.Left, val, out v);
    if ( val.CompareTo(root.Val) > 0 )
        return ContainsIn(root.Right, val, out v);
    return false;
  }
  
  public bool Contains(T val) => ContainsIn(Root, val, out Node v);
  
  public override string ToString()
    => (Root == null) ? "" : Root.ToString();
}
