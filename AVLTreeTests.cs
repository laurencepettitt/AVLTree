using static System.Console;

static class AVLTreeTests {
  // tests single right rotation
  static public void LeftLeft() {
    AVLTree<int> t = new AVLTree<int>();
    t.Insert(15);
    t.Insert(6);
    t.Insert(20);
    t.Insert(4);
    t.Insert(10);
    t.Insert(16);
    t.Insert(2);
    t.Insert(5);
    WriteLine(t);
    // right rotation after next insert..
    t.Insert(1);
    WriteLine(t);
  }
  // tests double rotation (left, then right) 
  static public void LeftRight() {
    AVLTree<int> t = new AVLTree<int>();
    
  }
  // tests single left rotation
  static public void RightRight() {
    AVLTree<int> t = new AVLTree<int>();
    t.Insert(0);
    t.Insert(2);
    t.Insert(-2);
    t.Insert(-1);
    t.Insert(3);
    t.Insert(-3);
    WriteLine(t);
    // left rotation after next insert..
    t.Insert(4);
    WriteLine(t);
  }
  // tests double rotation (right, then left)
  static public void RightLeft() {
    AVLTree<int> t = new AVLTree<int>();
    
  }
  
  static void Main() {
    AVLTreeTests.LeftLeft();
    AVLTreeTests.RightRight();
  }
}
